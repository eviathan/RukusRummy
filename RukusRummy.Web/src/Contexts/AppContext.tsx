import React, { useContext, useEffect, useState } from "react";

import { Api } from "./ApiContext";
import { IGame, IPlayer } from "../Models/Game";

export interface IAppStateFactory {
	loading: boolean;
	game?: IGame;
	currentPlayer?: IPlayer;
}

export interface IAppStateProviderProps { }

export const AppState = React.createContext<IAppStateFactory>({
	loading: false,	
});

export const AppSateProvider: React.FC<React.PropsWithChildren<IAppStateProviderProps>> = ({ children }) => {
	const api = useContext(Api);
	
	const [loading, setLoading] = useState<boolean>(false);
	const [game, setGame] = useState<IGame | undefined>();
	const [currentPlayer, setCurrentPlayer] = useState<IPlayer | undefined>();

	useEffect(() => {
        const load = async () => {
            try {
                var currentPlayer = await api.player.getCurrentPlayer();
				setCurrentPlayer(currentPlayer);
                setLoading(false);
            } catch (e) {
                setLoading(false);
            }
        };

        load();
    }, [api]);
	
	return (
		<AppState.Provider
			value={{
				loading,
				game,
				currentPlayer
			}}>
			{children}
		</AppState.Provider>
	);
};