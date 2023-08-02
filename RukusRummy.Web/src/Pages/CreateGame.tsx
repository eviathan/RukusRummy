import { useContext } from 'react';
import { Api } from '../Contexts/ApiContext';

import './CreateGame.scss';

export const CreateGame: React.FC<React.PropsWithChildren<{}>> = () => {
  const api = useContext(Api);

  return (
    <div className="create-game">
      <input placeholder="Game name"></input>
      <select>
        <option>Deck</option>
      </select>
      <select>
        <option>Who can reveal cards: All Players</option>
        <option>Who can manage issues: Just me</option>
      </select>
      <select>
        <option>Who can manage issues: All players</option>
        <option>Who can manage issues: Just me</option>
      </select>
      <p>Auto-reveal cards</p>
      <input type="checkbox" />
      <p>Enable fun features</p>
      <input type="checkbox" />
      <p>Show average in the results</p>
      <input type="checkbox" />
      <button className="primary">Create Game</button>
    </div>
  );
}
  
export default CreateGame;