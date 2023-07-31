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
  
export default SessionPageHeader;