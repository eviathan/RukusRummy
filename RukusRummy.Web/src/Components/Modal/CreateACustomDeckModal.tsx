import { useContext, useState } from 'react';

import { Api } from '../../Contexts/ApiContext';
import TextInput from '../TextInput/TextInput';
import Toggle from '../Toggle/Toggle';
import { IGame } from '../../Models/Game';

import './CreateACustomDeckModal.scss';

interface IProps {
    onContinue: () => void;
    onCancel: () => void;
}

export const CreateACustomDeckModal: React.FC<React.PropsWithChildren<IProps>> = ({ onCancel, onContinue }) => {

    async function handleCancel() {
        onCancel();
    }

    async function handleContinue() {
        onContinue();
    }

    return (
        <div className="create-a-custom-deck-modal">
            <h1>Choose your display name</h1>
            <button className='primary' onClick={handleCancel}>Cancel</button>
            <button className='primary' onClick={handleContinue}>Continue</button>
        </div>
    );
}
  
export default CreateACustomDeckModal;