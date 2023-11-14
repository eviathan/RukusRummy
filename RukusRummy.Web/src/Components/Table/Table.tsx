import { useContext, useEffect, useState } from "react";
import PlayedCard from "../PlayedCard/PlayedCard";

import "./Table.scss";
import { GameHubContext } from "../../Contexts/GameHubContext";

interface IProps {
}

export const Table: React.FC<React.PropsWithChildren<IProps>> = () => {
    const { connection } = useContext(GameHubContext);

    useEffect(() => {
        if(connection) {
            connection.on("UserUpdatedCard", (user: string, card: string) => {
                // debugger;
                console.log(`User ${JSON.stringify(user)} Card: ${card}`);
            });
        }

        // Clean up
        return () => {
            if(connection) {
                connection.off("ReceiveMessage");
            }
        };
    }, [connection]);
    return (
        <div className="table">
            <div className="left-side">
                <PlayedCard name="Brian" value="1" />
                <PlayedCard name="John" value=""  />
                <PlayedCard name="Alice" value="1" flipped />
                <PlayedCard name="Alice" value="1" flipped />
            </div>
            <div className="middle-side">
                <div className="top-side">
                    <PlayedCard name="Brian" value="1" />
                    <PlayedCard name="John" value=""  />
                    <PlayedCard name="some" value="" flipped />
                    <PlayedCard name="Jane" value="1" flipped />
                </div>
                {/* TODO: Add this to center "cards-on-table" when you have placed your card  */}
                <div className="center cards-on-table">
                    <button className="primary">Reveal cards</button>
                </div>
                <div className="bottom-side">
                    <PlayedCard name="Brian" value="1" />
                    <PlayedCard name="James" value="1" />
                    <PlayedCard name="John" value=""  />
                    <PlayedCard name="Alice" value="1" flipped />
                </div>
            </div>
            <div className="right-side">
                <PlayedCard name="Brian" value="1" />
                <PlayedCard name="John" value=""  />
                <PlayedCard name="Alice" value="1" flipped />
                <PlayedCard name="Alice" value="1" flipped />
            </div>
        </div>
    );
}
  
export default Table;
  
  