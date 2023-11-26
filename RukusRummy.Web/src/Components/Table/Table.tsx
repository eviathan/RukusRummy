import PlayedCard from "../PlayedCard/PlayedCard";
import { IPlayer } from "../../Models/Player";

import "./Table.scss";
import { App } from "../../Contexts/AppContext";
import { useContext, useEffect, useState } from "react";
import { GameStateType } from "../../Models/Game";

export type TablePlayer = {

} & IPlayer

interface IProps {
    players: Array<TablePlayer>
    flipped: boolean;
}

export const Table: React.FC<React.PropsWithChildren<IProps>> = ({ players, flipped }) => {
    const app = useContext(App);

    // ------------------------------------------------------------------------------
    // TODO: This (and related guff) should probably be moved up onto the SessionPage
    // ------------------------------------------------------------------------------
    const [isCountingDown, setIsCountingDown] = useState<boolean>(false);
    const [countdownText, setCountdownText] = useState<string>("Ready?");
    
    useEffect(() => {
        const roundFinished = app.game?.state === GameStateType.RoundFinished;

        if(!roundFinished) {
            setIsCountingDown(false);
            setCountdownText("Ready?");
            app.setCountdownFinished(false);
        }
        
        setIsCountingDown(roundFinished);
    }, [app.game?.state])
    
    useEffect(() => {
        let countdown = 3;
        
        if (isCountingDown) {
            const intervalId = setInterval(() => {
                setCountdownText(`${countdown}`);
                countdown -= 1;
                
                if (countdown < 0) {
                    clearInterval(intervalId);
                    setCountdownText('Go!');
                    app?.setCountdownFinished(true);
                }
            }, 1000);
            
            // Cleanup interval on component unmount
            return () => {
                clearInterval(intervalId);
            }
        }
    }, [isCountingDown]);

    function getCtaText() {
        return isCountingDown ? countdownText : "Pick your cards!";
    }
    // ------------------------------------------------------------------------------
    
    function getPlayedCard(index: number) {
        if(players.length > index)
        {
            const player = players[index];
            const game = app?.game;
            const rounds = game?.rounds ?? [];
            const lastRound = rounds?.[rounds.length - 1];
            const deckValues = game?.deck.values.split(',') ?? [];
            const vote = lastRound.votes[player.id];
            
            const value = vote !== undefined ? deckValues[vote] : "";

            return <PlayedCard 
                        name={player.name}
                        value={value} 
                        flipped={app?.countdownFinished && app.game?.state === GameStateType.RoundFinished}
                        spectator={player.isSpectator} 
                    />
        }
        
        return null;
    }

    function revealCards() {
        app.revealCards();
    }

    function hasVotes(): boolean {
        const rounds = app.game?.rounds ?? [];
        var lastRound = rounds.at(-1);
        const votes = Object.entries(lastRound?.votes ?? {});

        const hasVotes = votes.filter(([playerId, value]) => value !== undefined).length > 0;
        return hasVotes;
    }

    function renderCTO() {
        if(!app?.countdownFinished && (!hasVotes() || isCountingDown))
            return <p className="cta">{getCtaText()}</p>

        const gameState: GameStateType = app.game?.state ?? GameStateType.RoundActive;

        switch(gameState) {
            default:
            case GameStateType.RoundActive: {
                return <button className="primary" onClick={revealCards}>Reveal cards</button>;
            }
            case GameStateType.RoundFinished: {
                return <button className="tertiary" onClick={() => app.startNewRound()}>New voting</button>
            }
        }
    }

    function isActive() {
        return app.game?.state === GameStateType.RoundActive;
    }

    return (
        <div className="table">
            <div className="left-side">
                {getPlayedCard(10)}
                {getPlayedCard(6)}
                {getPlayedCard(15)}
                {getPlayedCard(3)}
            </div>
            <div className="middle-side">
                <div className="top-side">
                    {getPlayedCard(5)}
                    {getPlayedCard(14)}
                    {getPlayedCard(1)}
                    {getPlayedCard(7)}
                </div>
                {/* TODO: Add this to center "cards-on-table" when you have placed your card  */}
                <div className={`center ${isActive() && hasVotes() ? "cards-on-table" : ""}`}>
                    { renderCTO() }
                </div>
                <div className="bottom-side">
                    {getPlayedCard(13)}
                    {getPlayedCard(0)}
                    {getPlayedCard(11)}
                    {getPlayedCard(8)}
                </div>
            </div>
            <div className="right-side">
                {getPlayedCard(12)}
                {getPlayedCard(9)}
                {getPlayedCard(2)}
                {getPlayedCard(4)}
            </div>
        </div>
    );
}
  
export default Table;
  
  