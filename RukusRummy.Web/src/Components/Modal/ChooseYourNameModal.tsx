import { useContext, useState } from 'react';

import { Api } from '../../Contexts/ApiContext';
import TextInput from '../TextInput/TextInput';
import Toggle from '../Toggle/Toggle';

import './ChooseYourNameModal.scss';
import { App } from '../../Contexts/AppContext';
import { IPlayer } from '../../Models/Player';

interface IProps { 
    didCreatePlayer?: (player: IPlayer) => void;
}

// TODO: Rename this to ChooseUserModal
export const ChooseYourNameModal: React.FC<React.PropsWithChildren<IProps>> = ({ didCreatePlayer }) => {
    const api = useContext(Api);
    const app = useContext(App);

    const [name, setName] = useState<string | undefined>();
    const [isSpectator, setIsSpectator] = useState<boolean | undefined>();

    async function handleContinue() {
        if(!name)
            return; // TODO: Add proper validation here

        const player = await api.player.createNewPlayer(
            name,
            isSpectator ?? false
        );

        app.setPlayer(player);

        if(didCreatePlayer)
            didCreatePlayer(player);
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