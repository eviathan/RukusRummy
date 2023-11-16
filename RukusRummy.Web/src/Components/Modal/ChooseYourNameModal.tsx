import { useContext, useState } from 'react';

import { Api } from '../../Contexts/ApiContext';
import TextInput from '../TextInput/TextInput';
import Toggle from '../Toggle/Toggle';
import { IGame } from '../../Models/Game';

import './ChooseYourNameModal.scss';

interface IProps {
    game: IGame;
    onContinue: (playerId: string) => void;
}

// TODO: Rename this to ChooseUserModal
export const ChooseYourNameModal: React.FC<React.PropsWithChildren<IProps>> = ({ game, onContinue }) => {
    const api = useContext(Api);

    const [name, setName] = useState<string | undefined>();
    const [isSpectator, setIsSpectator] = useState<boolean | undefined>();

    async function handleContinue() {
        if(!game || !name)
            return;

        const playerId = await api.player.add({
            gameId: game.id,
            name,
            isSpectator: isSpectator ?? false
        });

        onContinue(playerId);
    }

    return (
        <div className="choose-your-name-modal">
            <h1>Choose your display name</h1>
            <TextInput label="Display Name" onChange={(event) => setName(event.target.value)} />
            <Toggle label="Join as spectator" onChange={(value) => setIsSpectator(value)} />
            <button className='primary' onClick={handleContinue}>Continue</button>
            
            {/* TODO: THIS IS FOR WHEN WE IMPLENT AUTH */}
            {/* <div>
                <button>Login</button>
                <button>Sign Up</button>
            </div> */}
        </div>
    );
}
  
export default ChooseYourNameModal;