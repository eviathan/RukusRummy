import React, { useContext, useEffect, useState } from "react";

import { Api } from "./ApiContext";
import { IGame, IPlayer } from "../Models/Game";

export interface IAppFactory {
	loading: boolean;
	game?: IGame;
	currentPlayer?: IPlayer;
}

export interface IAppProviderProps { }

export const App = React.createContext<IAppFactory>({
	loading: false,	
});

export const AppProvider: React.FC<React.PropsWithChildren<IAppProviderProps>> = ({ children }) => {
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
		<App.Provider
			value={{
				loading,
				game,
				currentPlayer
			}}>
			{children}
		</App.Provider>
	);
};