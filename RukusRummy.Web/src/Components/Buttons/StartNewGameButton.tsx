import { useNavigate } from 'react-router-dom';

import './StartNewGameButton.scss';

export const StartNewGameButton: React.FC<React.PropsWithChildren<{}>> = () => {
    const navigate = useNavigate();

    const handleClick = () => {
        navigate('/create-game');
    }

    return (
        <button className='primary' onClick={handleClick}>Start new game</button>
    );
}
  
export default StartNewGameButton;
  
  