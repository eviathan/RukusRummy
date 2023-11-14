import { useContext, useEffect, useState } from "react";
import { Navigate, useParams } from "react-router-dom";

import { IGame, IPlayer } from "../Models/Game";
import { Api } from "../Contexts/ApiContext";
import ChooseYourNameModal from "../Components/Modal/ChooseYourNameModal";
import Modal from "../Components/Modal/Modal";
import { GameHubContext } from "../Contexts/GameHubContext";
import Hand from "../Components/Hand/Hand";
import IDeck from "../Models/Deck";

import "./SessionPage.scss"
import Table from "../Components/Table/Table";
import { AppState } from "../Contexts/AppContext";

// TODO: Move this guff into the App Context
export const SessionPage: React.FC<React.PropsWithChildren<{}>> = () => {
    const api = useContext(Api);
    const app = useContext(AppState);

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

    console.log('CurrentPlayer: ', app.currentPlayer);

    const players: Array<IPlayer> = [
        {
            name: 'Test',
            isSpectator: false
        },
    ];

    return (
        <div className="session">
            {app?.currentPlayer !== undefined
                ? 
                <>
                    <div className="body">
                        {/* <p>{JSON.stringify(game, null, 4)}</p> */}
                        <Table players={game.players} /> 
                    </div>
                    <div className="footer">
                        <Hand deck={testDeck} onSelectCard={(card) => connection?.invoke("UpdateCard", "00000000-0000-0000-0000-000000000000", card)} />
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
  
  