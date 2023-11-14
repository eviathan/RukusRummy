import PlayedCard from "../PlayedCard/PlayedCard";
import { IPlayer } from "../../Models/Game";

import "./Table.scss";

export type TablePlayer = {
    value?: string;

} & IPlayer

interface IProps {
    players: Array<TablePlayer>
    flipped: boolean;
}

export const Table: React.FC<React.PropsWithChildren<IProps>> = ({ players, flipped }) => {
    
    function getPlayedCard(index: number) {
        if(players.length > index)
        {
            const player = players[index];
            return <PlayedCard 
                        name={player.name}
                        value={player.value} 
                        flipped={flipped}
                        spectator={player.isSpectator} 
                    />
        }
        
        return null;
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

                    <button className="primary">Reveal cards</button>
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
  
  