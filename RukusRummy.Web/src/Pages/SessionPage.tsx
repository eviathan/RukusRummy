import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import { IGame } from "../Models/Game";
import { Api } from "../Contexts/ApiContext";
import ChooseYourNameModal from "../Components/Modal/ChooseYourNameModal";
import Modal from "../Components/Modal/Modal";
import { SignalRContext } from "../Contexts/SignalRContext";


export const SessionPage: React.FC<React.PropsWithChildren<{}>> = () => {
    const api = useContext(Api);
    const params = useParams();

    const { connection } = useContext(SignalRContext);

    useEffect(() => {
        // debugger;
        if(connection) {
            connection.on("UserConnected", (user: string) => {
                // debugger;
                // Handle messages
                console.log(`User ${user}`);
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
        return <h1>Loading</h1> // TODO: ADD SPINNER HERE
    }

    return (
        <div className="Session">
            {game.players && game.players.length > 0 
                ? 
                <div>
                    <h1>Session</h1>
                    <p>{JSON.stringify(game, null, 4)}</p>
                </div>
                : 
                <Modal>
                    <ChooseYourNameModal game={game} onContinue={handleContinue} />
                </Modal>
            }
            
        </div>
    );
}
  
export default SessionPage;
  
  