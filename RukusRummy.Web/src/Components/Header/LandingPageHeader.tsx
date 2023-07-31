import Timer from '../Timer/Timer';
import './Header.scss';

export const LandingPageHeader: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
  return (
    <>
      <p>Dropdown: GameSettings & voting history</p>
      <p>Personal Settings Dropdown</p>
      <button>Invite Players</button>
      <button>Show issues</button>
    </>
  );
}
  
export const LandingPageSubheader: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
  return (
    <>
      <Timer />
    </>
  );
}