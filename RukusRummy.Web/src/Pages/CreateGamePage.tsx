import { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { Api } from '../Contexts/ApiContext';
import IDeck from '../Models/Deck';
import TextInput from '../Components/TextInput/TextInput';
import Dropdown, { IDropdownOption } from '../Components/Dropdown/Dropdown';
import Toggle from '../Components/Toggle/Toggle';
import { ICreateGameRequest } from '../Models/Game';

import './CreateGame.scss';
import Modal from '../Components/Modal/Modal';
import CreateACustomDeckModal from '../Components/Modal/CreateACustomDeckModal';

export const CreateGamePage: React.FC<React.PropsWithChildren<{}>> = () => {
  const api = useContext(Api);
  const navigate = useNavigate();

  const [decks, setDecks] = useState<Array<IDeck>>([]);
  const [formData, setFormData] = useState<ICreateGameRequest | undefined>();
  const [loading, setLoading] = useState(true);
  const [isCreatingDeck, setIsCreatingDeck] = useState(false);

    useEffect(() => {
        const load = async () => {
            try {
                const decks = await api.deck.getAll();
                setDecks(decks);
                setLoading(false);
            } catch (e) {
                setLoading(false);
            }
        };

        load();
    }, [api]);


    function handleChange(data: any) {
        var newData = {
            ...formData,
            ...data
        }

        console.log(JSON.stringify(newData, null, 4))
        setFormData(newData)
    }

    async function handleSubmit(event: any) {
        if(formData) {
            var gameId = await api.game.create(formData);
            navigate(`/session/${gameId}`)
        }
    }

    function mapDeckToOption(deck: IDeck): IDropdownOption {
        return {
            label: `${deck.name}: ${deck.values.split(',').join(', ')}`,
            value: deck.id
        }
    }

    function isFormDataValid(): boolean{
        return formData !== null    
            && formData !== undefined
            && formData.name !== ''
            && formData.deck !== undefined
            && formData.deck !== ""
            && formData.deck !== "button";
    }

    return (
        <>
        { isCreatingDeck 
            ? 
                <Modal>
                    <CreateACustomDeckModal 
                        onCancel={() => setIsCreatingDeck(false)} 
                        onContinue={async (deck) => { 
                            await api.deck.create(deck.name, deck.values);                     
                            setIsCreatingDeck(false);
                        }} 
                    />
                </Modal>
            :
                <div className="create-game">
                    <TextInput 
                        label="Game's name" 
                        onChange={(event) => {
                            handleChange({                
                                name: event.target.value
                            });
                        }} 
                    />

                    <Dropdown 
                        label='Deck' 
                        options={[...decks?.map(mapDeckToOption), {
                            label: "Create a custom Deck",
                            value: "button",
                            cssClass: "bold"
                        }]}
                        onChange={(value) => {
                            if(value === 'button'){
                                setIsCreatingDeck(true);
                            } else {
                                handleChange({                
                                    deck: value
                                });
                            }
                        }} 
                    />

                    <Dropdown 
                        label='Who can reveal cards'
                        options={[
                            {
                                label: "All Players",
                                value: "AllPlayers"
                            },
                            {
                                label: "Just me",
                                value: "JustMe"
                            },
                        ]}
                        onChange={(value) => {
                            handleChange({                
                                revealCardsPermission: value
                            });
                        }}
                    />

                    <Dropdown 
                        label='Who can manage issues' 
                        options={[
                            {
                                label: "All Players",
                                value: "AllPlayers"
                            },
                            {
                                label: "Just me",
                                value: "JustMe"
                            },
                        ]}
                        onChange={(value) => {
                            handleChange({                
                                manageIssuesPermission: value
                            });
                        }}
                    />

                    <Toggle 
                        label='Auto-reveal cards' 
                        onChange={(value) => handleChange({ autoReveal: value })} 
                    />
                    <Toggle 
                        label='Enable fun features'
                        onChange={(value) => handleChange({ enableFunFeatures: value})} 
                    />
                    <Toggle 
                        label='Show average in the results'
                        onChange={(value) => handleChange({ showAverage: value})}
                    />
                    <Toggle
                        label='Autoclose session when empty'
                        onChange={(value) => handleChange({ autoCloseSession: value})}
                    />

                    <button 
                        className="primary submit"
                        disabled={!isFormDataValid()}
                        onClick={handleSubmit}>
                        Create Game
                    </button>
                </div>
        }
        </>
    );
}
  
export default CreateGamePage;