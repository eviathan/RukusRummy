import Timer from '../Timer/Timer';
import './Header.scss';

const SessionPageHeader: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
  return (
    <>
      <h1>SessionPageHeader</h1>       
      <p>Dropdown: GameSettings & voting history</p>
      <p>Personal Settings Dropdown</p>
      <button>Invite Players</button>
      <button>Show issues</button> 
    </>
  );
}

export const SessionPageSubheader: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
  return (
    <>
      <Timer />
    </>
  );
}
  
export default SessionPageHeader;