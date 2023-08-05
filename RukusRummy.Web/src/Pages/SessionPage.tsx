import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";

import { IGame } from "../Models/Game";
import { Api } from "../Contexts/ApiContext";
import ChooseYourNameModal from "../Components/Modal/ChooseYourNameModal";
import Modal from "../Components/Modal/Modal";


export const SessionPage: React.FC<React.PropsWithChildren<{}>> = () => {
    const api = useContext(Api);
    const params = useParams();

    const [game, setGame] = useState<IGame | undefined>();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const load = async () => {
            try {
                if(params?.id) {
                    const game = await api.game.get(params.id);
                    setGame(game);
                    setLoading(false);
                }
            } catch (e) {
                setLoading(false);
            }
        };

        load();
    }, [api]);

    return (
        <div className="Session">
            {game?.players 
                ? 
                <div>
                    <h1>Session</h1>
                    <p>{JSON.stringify(game, null, 4)}</p>
                </div>
                : 
                <Modal>
                    <ChooseYourNameModal />
                </Modal>
            }
            
        </div>
    );
}
  
export default SessionPage;
  
  