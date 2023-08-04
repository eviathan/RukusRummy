import React from "react";
import DeckApi from "../Api/DeckApi";
import GameApi from "../Api/GameApi";
import TestApi from "../Api/TestApi";

export interface IApiFactory {
	game: GameApi;
	deck: DeckApi;
	test: TestApi;
}

export interface IApiProviderProps { }

export const Api = React.createContext<IApiFactory | undefined>(undefined);

export const ApiProvider: React.FC<React.PropsWithChildren<IApiProviderProps>> = ({ children }) => {
	return (
		<Api.Provider
			value={{
				game: new GameApi(),
				deck: new DeckApi(),
				test: new TestApi()
			}}>
			{children}
		</Api.Provider>
	);
};