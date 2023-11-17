import { useContext, useEffect } from "react";

import ChooseYourNameModal from "../Components/Modal/ChooseYourNameModal";
import Modal from "../Components/Modal/Modal";
import Hand from "../Components/Hand/Hand";
import Table, { TablePlayer } from "../Components/Table/Table";
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

    if(!app.game) {
        // TODO: Add a prettier loader here, maybe centralise the loading 
        return <h1>Loading</h1>
    }

    function getTablePlayers(): Array<TablePlayer> {
        const game = app?.game;
        const players = game?.players ?? [];
        const rounds = game?.rounds ?? [];
        const lastRound = rounds?.[rounds.length - 1];
        const deckValues = game?.deck.values.split(',') ?? [];

        return players.map(x => {
            const vote = lastRound?.votes[x.id] ?? 0;
            const value = vote ? deckValues[vote] : '';
            return {
                id: x.id,
                name: x.name,
                isSpectator: x.isSpectator,
                label: value
            } ;
        });
    }

    return (
        <div className="session">
            {app?.player !== undefined
                ? 
                <>
                    <div className="body">
                        <Table players={getTablePlayers()} flipped={false} /> 
                    </div>
                    <div className="footer">
                        <Hand deck={app.game.deck} onSelectCard={ (card) => app.playCard(card) } />
                    </div>
                </>
                : 
                <Modal>
                    <ChooseYourNameModal game={app.game} />
                </Modal>
            }
            
        </div>
    );
}
  
export default SessionPage;
  
  