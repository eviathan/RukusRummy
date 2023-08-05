import React from "react";

export interface IAppStateFactory {
}

export interface IAppStateProviderProps { }

export const AppState = React.createContext<IAppStateFactory>({
});

export const AppSateProvider: React.FC<React.PropsWithChildren<IAppStateProviderProps>> = ({ children }) => {
	const appStateFactoryValue = React.useMemo(() => ({
	}), []);

	return (
		<AppState.Provider
			value={appStateFactoryValue}>
			{children}
		</AppState.Provider>
	);
};