import React, { createContext, useState, useEffect, ReactNode } from 'react';
import { HubConnection, HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

interface SignalRContextType {
    connection: HubConnection | null;
}

export const SignalRContext = createContext<SignalRContextType>({ connection: null });

interface SignalRProviderProps {
    children: ReactNode;
}

export const SignalRProvider: React.FC<SignalRProviderProps> = ({ children }) => {
    const [connection, setConnection] = useState<HubConnection | null>(null);

    useEffect(() => {
        const createConnection = new HubConnectionBuilder()
            .withUrl("http://localhost:5001/hubs/gamehub") // Your Hub URL
            .configureLogging(LogLevel.Information)
            .build();

        setConnection(createConnection);

        createConnection.start()
            .then(() => console.log('SignalR Connected'))
            .catch(err => console.error('SignalR Connection Error: ', err));

        return () => {
            createConnection.stop();
        };
    }, []);

    return (
        <SignalRContext.Provider value={{ connection }}>
            {children}
        </SignalRContext.Provider>
    );
};