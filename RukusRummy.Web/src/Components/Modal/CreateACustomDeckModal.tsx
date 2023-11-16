import { useContext, useEffect, useState } from 'react';

import { ICreateDeckRequest } from '../../Models/Game';
import Hand from '../Hand/Hand';
import IDeck from '../../Models/Deck';
import TextInput from '../TextInput/TextInput';

import './CreateACustomDeckModal.scss';
import { Api } from '../../Contexts/ApiContext';

interface IProps {
    onContinue: (deck: IDeck) => void;
    onCancel: () => void;
}

export const CreateACustomDeckModal: React.FC<React.PropsWithChildren<IProps>> = ({ onCancel, onContinue }) => {

    const api = useContext(Api);

    const [formData, setFormData] = useState<ICreateDeckRequest | undefined>();
    const [deck, setDeck] = useState<IDeck | undefined>();

    useEffect(() => {
        setDeck({
            id : '',
            name: formData?.name ?? '',
            values: formData?.values ?? ''
        })
        
    }, [formData, setDeck]);

    function handleChange(data: any) {
        var newData = {
            ...formData,
            ...data
        }
        setFormData(newData)
    }

    async function handleCancel() {
        onCancel();
    }

    async function handleContinue() {
        if(deck)
            onContinue(deck);
    }

    function validateValues(values: string): boolean {
        return values.split(',').every(x => x.length <= 3);
    }

    function isFormDataValid() {
        return !!formData 
            && !!formData.name
            && formData.name !== ""
            && !!formData.values
            && formData.values !== "";
    }

    return (
        <div className="create-a-custom-deck-modal">
            <h2>Create a custom Deck</h2>
            <TextInput 
                label="Name"
                onChange={(event) => {
                    handleChange({                
                        name: event.target.value
                    });
                }} 
            />
            <TextInput 
                label="Values" 
                onChange={(event) => {
                    handleChange({                
                        values: event.target.value
                    });
                }}
                validate={validateValues} 
            />
            <p>Enter up to 3 characters per value, separated by commas.</p>
            { !!deck && deck.values !== ""
                ?
                    <>
                        <h3>Preview</h3>
                        <Hand 
                            type='simple'
                            deck={deck}
                            onSelectCard={() => {}}
                        />
                    </>
                :
                    <></>
            }
            <div className='footer'>
                <button className='primary' onClick={handleCancel}>Cancel</button>
                <button className='primary' onClick={handleContinue} disabled={!isFormDataValid()}>Continue</button>
            </div>
        </div>
    );
}
  
export default CreateACustomDeckModal;