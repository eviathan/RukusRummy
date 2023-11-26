import React, { createContext, useState, useEffect, ReactNode } from 'react';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

interface GameHubContextType {
    connection: HubConnection | null;
}

export const GameHubContext = createContext<GameHubContextType>({ connection: null });

interface GameHubProviderProps {
    children: ReactNode;
}

export const GameHubProvider: React.FC<GameHubProviderProps> = ({ children }) => {
    const [connection, setConnection] = useState<HubConnection | null>(null);

    useEffect(() => {
        const hubConnection = new HubConnectionBuilder()
            .withUrl("http://localhost:5001/hubs/gamehub")
            .configureLogging(LogLevel.Information)
            .build();

        setConnection(hubConnection);

        hubConnection.start()
            .then(() => console.log('SignalR Connected'))
            .catch(err => console.error('SignalR Connection Error: ', err));

        hubConnection.on("error", (message) => console.error(message));

        return () => {
            hubConnection.stop();
        };
    }, []);

    return (
        <GameHubContext.Provider value={{ connection }}>
            {children}
        </GameHubContext.Provider>
    );
};