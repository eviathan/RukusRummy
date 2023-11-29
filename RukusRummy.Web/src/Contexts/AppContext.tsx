import React, { useContext, useEffect, useState } from "react";

import { Api } from "./ApiContext";
import { GameStateType, IGame } from "../Models/Game";
import { IPlayer, IPlayerPreferencesCache } from "../Models/Player";
import { GameHubContext } from "./GameHubContext";
import Loading from "../Components/Loading/Loading";

export interface IAppFactory {
    revealCards(): unknown;
    joinGame(playerId: string, gameId: string): unknown;
	loading: boolean;
	game?: IGame;
	player?: IPlayer;
	updatePreferencesCache: (preferences: IPlayerPreferencesCache) => void;
	setGame: (game: IGame) => void;
    setPlayer:(player: IPlayer) => void;
    playCard:(card?: number) => void;
	joinGame: (playerId: string, gameId: string) => unknown;
	revealCards: () => unknown;
	countdownFinished: boolean;
	setCountdownFinished: (value: boolean) => void;
	startNewRound: () => void;
}

export interface IAppProviderProps { }

export const App = React.createContext<IAppFactory>({
	loading: false,	
	setGame: (game: IGame) => {},
	updatePreferencesCache: (preferences: IPlayerPreferencesCache) => {},
	setPlayer: (player: IPlayer) => {},
	playCard:(card?: number) => {},
	joinGame: (playerId: string, gameId: string) => {},
	revealCards: () => { },
	countdownFinished: false,
	setCountdownFinished: (value: boolean) => { },
	startNewRound: () => { }
});

export const AppProvider: React.FC<React.PropsWithChildren<IAppProviderProps>> = ({ children }) => {
	const api = useContext(Api);
	
	const { connection } = useContext(GameHubContext);
	
	const [loading, setLoading] = useState<boolean>(true);
	const [game, setGame] = useState<IGame | undefined>();
	const [playerId, setPlayerId] = useState<string | undefined>();
	const [player, setPlayer] = useState<IPlayer | undefined>();
	const [preferencesCache, setPreferencesCache] = useState<IPlayerPreferencesCache>({
		decks: []
	});
	const [countdownFinished, setCountdownFinished] = useState<boolean>(false);

	useEffect(() => {
        const load = async () => {
            try {
                var currentPlayer = await api.player.getCurrentPlayer();
				setPlayer(currentPlayer);
            } catch (e) { }
			setLoading(false);
        };

        load();
    }, [api, playerId]);

	
	
	useEffect(() => {
        if(connection) {
            connection.on("UserConnected", (user: any) => {
                console.log(`User ${JSON.stringify(user)}`);
            });

            connection.on("GameUpdated", async (gameId: string) => {
				var game = await api.game.get(gameId);
				setGame(game);
            });

            connection.on("PlayerUpdated", async (playerId: string) => {
				console.log("Player updated:", playerId);
				var player = await api.player.get(playerId);
				setPlayer(player);
            });

            connection.on("RevealCards", async (gameId: string) => {
				var game = await api.game.get(gameId);
				setGame(game);
            });

            connection.on("StartedNewRound", async (gameId: string) => {
				console.log("Working started new round event?");
				
				var game = await api.game.get(gameId);
				setGame(game);
            });
        }

        // Clean up
        return () => {
            if(connection) {
                connection.off("ReceiveMessage");
            }
        };
    }, [connection]);

	function updatePreferencesCache(preferences: IPlayerPreferencesCache) {
		setPreferencesCache(preferences);
	}

	function playCard(card?: number) {

		if(!player || !game || game.state === GameStateType.RoundFinished)
			return;

		const updatedGame = { ...game };
		const latestRoundIndex = game.rounds.length - 1;

		if(latestRoundIndex < 0)
			return;
		
		const updatedLatesRound = {...updatedGame.rounds[latestRoundIndex]};

		updatedLatesRound.votes = {
			...updatedLatesRound.votes,
			[player.id]: card
		};
		
		updatedGame.rounds[latestRoundIndex] = updatedLatesRound;

		setGame(updatedGame);
		connection?.invoke("UpdateCard", game.id, player.id, card);
	}
	
	async function revealCards() {
		if(!!game) {
			await api.game.revealCards(game.id);
		}
	}

	async function joinGame(playerId: string, gameId: string): Promise<void> {
		await api.game.addPlayer(gameId, playerId);
		connection?.invoke("JoinGame", gameId);
	}

	function startNewRound() {
		if(!game || game.state === GameStateType.RoundActive)
			return;

		api.game.startNewRound({
			gameId: game.id
		})
	}
	
	return (
		<App.Provider
			value={{
				loading,
				game,
				player,
				updatePreferencesCache,
				setGame,
				setPlayer,
				playCard,
				joinGame,
				revealCards,
				countdownFinished,
				setCountdownFinished,
				startNewRound
			}}>
				<>
					{ loading 
						? <Loading />
						: <>{children}</>
					}
				</>
		</App.Provider>
	);
};