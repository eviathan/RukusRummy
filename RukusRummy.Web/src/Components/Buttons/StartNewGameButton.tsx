import { useNavigate } from 'react-router-dom';

import './StartNewGameButton.scss';

export const StartNewGameButton: React.FC<React.PropsWithChildren<{}>> = () => {
    const navigate = useNavigate();

    const handleClick = () => {
        // TODO: This needs to call create session endpont then redirect to the session page with the id as the route
        navigate('/iuakhsdjkusahdjkash');
    }

    return (
        <button className='primary' onClick={handleClick}>Start new game</button>
    );
}
  
export default StartNewGameButton;
  
  