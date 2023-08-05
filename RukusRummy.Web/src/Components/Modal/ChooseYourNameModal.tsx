import TextInput from '../TextInput/TextInput';
import Toggle from '../Toggle/Toggle';

import './ChooseYourNameModal.scss';

export const ChooseYourNameModal: React.FC<React.PropsWithChildren<{}>> = ({ }) => {
    return (
        <div className="choose-your-name-modal">
            <h1>Choose your display name</h1>
            <TextInput label="Display Name" onChange={(event) => console.log(event.target.value)} />
            <Toggle label="Join as spectator" />
            <button className='primary'>Continue</button>
            
            {/* TODO: THIS IS FOR WHEN WE IMPLENT AUTH */}
            {/* <div>
                <button>Login</button>
                <button>Sign Up</button>
            </div> */}
        </div>
    );
}
  
export default ChooseYourNameModal;