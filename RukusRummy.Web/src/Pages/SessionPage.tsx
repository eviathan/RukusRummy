import { useContext, useEffect, useState } from "react";
import { Navigate, useParams } from "react-router-dom";

import { IGame } from "../Models/Game";
import { Api } from "../Contexts/ApiContext";
import ChooseYourNameModal from "../Components/Modal/ChooseYourNameModal";
import Modal from "../Components/Modal/Modal";
import { GameHubContext } from "../Contexts/GameHubContext";
import Hand from "../Components/Hand/Hand";
import IDeck from "../Models/Deck";

import "./SessionPage.scss"
import Table from "../Components/Table/Table";

// TODO: Move this guff into the App Context
export const SessionPage: React.FC<React.PropsWithChildren<{}>> = () => {
    const api = useContext(Api);
    const params = useParams();

    const { connection } = useContext(GameHubContext);

    useEffect(() => {
        // debugger;
        if(connection) {
            connection.on("UserConnected", (user: any) => {
                // debugger;
                // Handle messages
                console.log(`User ${JSON.stringify(user)}`);
            });
        }

        // Clean up
        return () => {
            if(connection) {
                connection.off("ReceiveMessage");
            }
        };
    }, [connection]);

    const [game, setGame] = useState<IGame | undefined>();

    useEffect(() => {
        const load = async () => {
            try {
                if(params?.id) {
                    const game = await api.game.get(params.id);
                    setGame(game);
                }
            } catch (e) {
            }
        };

        load();
    }, [api]);

    async function getGame() {
        if(params?.id) {
            const game = await api.game.get(params.id);
            setGame(game);
        }
    }

    async function handleContinue() {
        await getGame()
    }

    if(!game) {
        return <h1>Loading</h1>// <Navigate to={"/"} />
    }

    let testDeck: IDeck = {
        "id": "59f03b02-8337-4e91-81c8-8cb1fea5a0a0",
        "name": "T-Shirt Sizes",
        "values": "XS, S, M, L, XL, ?, ☕️"
      }

    return (
        <div className="session">
            {game.players && game.players.length > 0 
                ? 
                <>
                    <div className="body">
                        {/* <p>{JSON.stringify(game, null, 4)}</p> */}
                        <Table /> 
                    </div>
                    <div className="footer">
                        <Hand deck={testDeck} onSelectCard={(card) => connection?.send("UpdateCard", card)} />
                    </div>
                </>
                : 
                <Modal>
                    <ChooseYourNameModal game={game} onContinue={handleContinue} />
                </Modal>
            }
            
        </div>
    );
}
  
export default SessionPage;
  
  