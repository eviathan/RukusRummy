import React from "react";
import DeckApi from "../Api/DeckApi";
import GameApi from "../Api/GameApi";
import PlayerApi from "../Api/PlayerApi";

export interface IApiFactory {
	game: GameApi;
	deck: DeckApi;
	player: PlayerApi;
}

export interface IApiProviderProps { }

export const Api = React.createContext<IApiFactory>({
	game: new GameApi(),
	deck: new DeckApi(),
	player: new PlayerApi()
});

export const ApiProvider: React.FC<React.PropsWithChildren<IApiProviderProps>> = ({ children }) => {
	const apiFactoryValue = React.useMemo(() => ({
		game: new GameApi(),
		deck: new DeckApi(),
		player: new PlayerApi(),
	}), []);

	return (
		<Api.Provider
			value={apiFactoryValue}>
			{children}
		</Api.Provider>
	);
};