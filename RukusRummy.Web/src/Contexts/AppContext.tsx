import React, { useContext, useEffect, useState } from "react";

import { Api } from "./ApiContext";
import { IGame } from "../Models/Game";
import { IPlayer, IPlayerPreferencesCache } from "../Models/Player";
import { GameHubContext } from "./GameHubContext";

export interface IAppFactory {
	loading: boolean;
	game?: IGame;
	currentPlayer?: IPlayer;
	updatePreferencesCache: (preferences: IPlayerPreferencesCache) => void;
	setGame: (game: IGame) => void;
	setPlayerId: (playerId: string) => void;
}

export interface IAppProviderProps { }

export const App = React.createContext<IAppFactory>({
	loading: false,	
	setGame: (game: IGame) => {},
	updatePreferencesCache: (preferences: IPlayerPreferencesCache) => {},
	setPlayerId: (playerId: string) => {}
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
                // debugger;
                // Handle messages
                console.log(`User ${JSON.stringify(user)}`);
            });

            connection.on("PlayerUpdated", (player: IPlayer) => {
				setPlayer(player);
            });

            connection.on("GameUpdated", (game: IGame) => {
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

	 // connection?.invoke("UpdateCard", "00000000-0000-0000-0000-000000000000", card)

	function updatePreferencesCache(preferences: IPlayerPreferencesCache) {
		setPreferencesCache(preferences);
	}
	
	return (
		<App.Provider
			value={{
				loading,
				game,
				currentPlayer: player,
				updatePreferencesCache,
				setGame,
				setPlayerId
			}}>
			{children}
		</App.Provider>
	);
};