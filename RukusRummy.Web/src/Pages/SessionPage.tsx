import { useParams } from "react-router-dom";
import { useContext, useEffect } from "react";

import ChooseYourNameModal from "../Components/Modal/ChooseYourNameModal";
import Modal from "../Components/Modal/Modal";
import Hand from "../Components/Hand/Hand";
import Loading from "../Components/Loading/Loading";
import Table, { TablePlayer } from "../Components/Table/Table";
import { App } from "../Contexts/AppContext";
import { Api } from "../Contexts/ApiContext";

import "./SessionPage.scss"
import { IPlayer } from "../Models/Player";

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

                    if(game) {
                        app.setGame(game);   
                    }
                }
            } catch (e) { }
        };

        load();
    }, [id]);

    if(!app.game) {
        return <Loading />
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
                label: value,
                decks: []
            } ;
        });
    }

    function getSelectedCard(): number | undefined{
        const game = app?.game;
        const rounds = game?.rounds ?? [];
        const lastRound = rounds?.[rounds.length - 1];

        return app.player?.id 
            ? lastRound.votes[app.player?.id]
            : undefined;
    }

    function onDidCreatePlayer(player: IPlayer) {
        if(app.game) {
            api.game.addPlayer(app.game.id, player.id);
        }
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
                        <Hand 
                            selectedCard={getSelectedCard()}
                            deck={app.game.deck}
                            onSelectCard={ (card) => app.playCard(card) }
                        />
                    </div>
                </>
                : 
                <Modal>
                    <ChooseYourNameModal didCreatePlayer={onDidCreatePlayer} />
                </Modal>
            }
            
        </div>
    );
}
  
export default SessionPage;
  
  