import { useContext, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { Api } from '../Contexts/ApiContext';
import IDeck from '../Models/Deck';
import TextInput from '../Components/TextInput/TextInput';
import Dropdown, { IDropdownOption } from '../Components/Dropdown/Dropdown';
import Toggle from '../Components/Toggle/Toggle';
import { ICreateGameRequest } from '../Models/Game';

import './CreateGame.scss';

export const CreateGamePage: React.FC<React.PropsWithChildren<{}>> = () => {
  const api = useContext(Api);
  const navigate = useNavigate();

  const [decks, setDecks] = useState<Array<IDeck>>([]);
  const [formData, setFormData] = useState<ICreateGameRequest | undefined>();
  const [loading, setLoading] = useState(true);

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
            label: `${deck.name}: ${deck.values}`,
            value: deck.id
        }
    }

    return (
        <div className="create-game">
            {/* <h1>Create Game</h1> */}

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
                    value: "Create a custom Deck",
                    cssClass: "bold"
                }]}
                onChange={(value) => {
                    handleChange({                
                        deck: value
                    });
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

            <Toggle label='Auto-reveal cards' onChange={(value) => handleChange({ autoReveal: value })} />
            <Toggle label='Enable fun features' onChange={(value) => handleChange({ enableFunFeatures: value})} />
            <Toggle label='Show average in the results' onChange={(value) => handleChange({ showAverage: value})} />
            <Toggle label='Autoclose session when empty' onChange={(value) => handleChange({ autoCloseSession: value})} />

            <button className="primary submit" onClick={handleSubmit}>Create Game</button>
        </div>
    );
}
  
export default CreateGamePage;