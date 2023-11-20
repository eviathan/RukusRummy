import PlayedCard from "../PlayedCard/PlayedCard";
import { IPlayer } from "../../Models/Player";

import "./Table.scss";
import { App } from "../../Contexts/AppContext";
import { useContext } from "react";

export type TablePlayer = {

} & IPlayer

interface IProps {
    players: Array<TablePlayer>
    flipped: boolean;
}

export const Table: React.FC<React.PropsWithChildren<IProps>> = ({ players, flipped }) => {
    const app = useContext(App);
    
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

            // debugger;

            // debugger;
            return <PlayedCard 
                        name={player.name}
                        value={value} 
                        flipped={flipped}
                        spectator={player.isSpectator} 
                    />
        }
        
        return null;
    }

    function revealCards() {
        app.revealCards();
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
                <div className="center cards-on-table">
                    <button className="primary" onClick={revealCards}>Reveal cards</button>
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
  
  