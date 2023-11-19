import React, { useContext, useEffect, useState } from "react";

import { Api } from "./ApiContext";
import { IGame } from "../Models/Game";
import { IPlayer, IPlayerPreferencesCache } from "../Models/Player";
import { GameHubContext } from "./GameHubContext";

export interface IAppFactory {
    joinGame(playerId: string, gameId: string): unknown;
	loading: boolean;
	game?: IGame;
	player?: IPlayer;
	updatePreferencesCache: (preferences: IPlayerPreferencesCache) => void;
	setGame: (game: IGame) => void;
    setPlayer:(player: IPlayer) => void;
    playCard:(card?: number) => void;
	joinGame: (playerId: string, gameId: string) => unknown;
}

export interface IAppProviderProps { }

export const App = React.createContext<IAppFactory>({
	loading: false,	
	setGame: (game: IGame) => {},
	updatePreferencesCache: (preferences: IPlayerPreferencesCache) => {},
	setPlayer: (player: IPlayer) => {},
	playCard:(card?: number) => {},
	joinGame: (playerId: string, gameId: string) => {}
});

export const AppProvider: React.FC<React.PropsWithChildren<IAppProviderProps>> = ({ children }) => {
	const api = useContext(Api);
	
	const { connection } = useContext(GameHubContext);
	
	const [loading, setLoading] = useState<boolean>(false);
	const [game, setGame] = useState<IGame | undefined>();
	const [playerId, setPlayerId] = useState<string | undefined>();
	const [player, setPlayer] = useState<IPlayer | undefined>();
	const [preferencesCache, setPreferencesCache] = useState<IPlayerPreferencesCache>({
		decks: []
	});

	useEffect(() => {
        const load = async () => {
            try {
				// debugger
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
		// debugger;
		connection?.invoke("UpdateCard", game?.id, player?.id, card);
	}

	async function joinGame(playerId: string, gameId: string): Promise<void> {
		await api.player.addPlayerToGame(playerId, gameId);
		connection?.invoke("JoinGame", gameId);
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
				joinGame
			}}>
			{children}
		</App.Provider>
	);
};