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

export const Api = React.createContext<IApiFactory>({
	game: new GameApi(),
	deck: new DeckApi(),
	test: new TestApi()
});

export const ApiProvider: React.FC<React.PropsWithChildren<IApiProviderProps>> = ({ children }) => {
	const apiFactoryValue = React.useMemo(() => ({
		game: new GameApi(),
		deck: new DeckApi(),
		test: new TestApi()
	}), []);

	return (
		<Api.Provider
			value={apiFactoryValue}>
			{children}
		</Api.Provider>
	);
};