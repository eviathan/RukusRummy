import React, { useContext, useState } from "react";

import { Api } from "./ApiContext";
import { IGame } from "../Models/Game";

export interface IAppStateFactory {
	loading: boolean;
	game?: IGame;
}

export interface IAppStateProviderProps { }

export const AppState = React.createContext<IAppStateFactory>({
	loading: false,	
});

export const AppSateProvider: React.FC<React.PropsWithChildren<IAppStateProviderProps>> = ({ children }) => {
	const api = useContext(Api);
	
	const [loading, setLoading] = useState<boolean>(false);
	const [game, setGame] = useState<IGame | undefined>();
	
	return (
		<AppState.Provider
			value={{
				loading,
				game
			}}>
			{children}
		</AppState.Provider>
	);
};