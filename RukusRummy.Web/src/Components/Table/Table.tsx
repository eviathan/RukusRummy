import { useContext} from "react";
import { GameHubContext } from "../../Contexts/GameHubContext";
import PlayedCard from "../PlayedCard/PlayedCard";
import { IPlayer } from "../../Models/Game";

import "./Table.scss";

interface IProps { }

export const Table: React.FC<React.PropsWithChildren<IProps>> = () => {
    const players: Array<IPlayer> = [
        {
            name: 'Test',
            isSpectator: false
        },
    ];

    function getPlayerCard(index: number) {
        if(players.length > index)
        {
            return <PlayedCard name="Brian" value="1" />
        }
        
        return null;
    }

    return (
        <div className="table">
            <div className="left-side">
                {getPlayerCard(10)}
                {getPlayerCard(6)}
                {getPlayerCard(15)}
                {getPlayerCard(3)}
            </div>
            <div className="middle-side">
                <div className="top-side">
                    {getPlayerCard(5)}
                    {getPlayerCard(14)}
                    {getPlayerCard(1)}
                    {getPlayerCard(7)}
                </div>
                {/* TODO: Add this to center "cards-on-table" when you have placed your card  */}
                <div className="center cards-on-table">

                    <button className="primary">Reveal cards</button>
                </div>
                <div className="bottom-side">
                    {getPlayerCard(13)}
                    {getPlayerCard(0)}
                    {getPlayerCard(11)}
                    {getPlayerCard(8)}
                </div>
            </div>
            <div className="right-side">
                {getPlayerCard(12)}
                {getPlayerCard(9)}
                {getPlayerCard(2)}
                {getPlayerCard(4)}
            </div>
        </div>
    );
}
  
export default Table;
  
  