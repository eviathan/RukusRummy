import { useContext, useEffect } from "react";

import ChooseYourNameModal from "../Components/Modal/ChooseYourNameModal";
import Modal from "../Components/Modal/Modal";
import Hand from "../Components/Hand/Hand";
import Table from "../Components/Table/Table";
import { App } from "../Contexts/AppContext";
import { useParams } from "react-router-dom";
import { Api } from "../Contexts/ApiContext";

import "./SessionPage.scss"

// TODO: Move this guff into the App Context
export const SessionPage: React.FC<React.PropsWithChildren<{}>> = () => {
    const api = useContext(Api);
    const app = useContext(App);
    const { id } = useParams();

    useEffect(() => {
        const load = async () => {
            try {
                if(id) {
                    const game = await api.game.get(id);
                    app.setGame(game);
                }
            } catch (e) {
            }
        };

        load();
    }, [id]);

    async function handleContinue() {
        // await getGame()
    }

    if(!app.game) {
        return <h1>Loading</h1>// <Navigate to={"/"} />
    }

    return (
        <div className="session">
            {app?.currentPlayer !== undefined
                ? 
                <>
                    <div className="body">
                        <Table players={app.game.players} flipped={false} /> 
                    </div>
                    <div className="footer">
                        <Hand deck={app.game.deck} onSelectCard={(card) => {
                            // TODO: Update card
                            // connection?.invoke("UpdateCard", "00000000-0000-0000-0000-000000000000", card)
                        }} />
                    </div>
                </>
                : 
                <Modal>
                    <ChooseYourNameModal game={app.game} onContinue={handleContinue} />
                </Modal>
            }
            
        </div>
    );
}
  
export default SessionPage;
  
  