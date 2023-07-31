import Timer from '../Timer/Timer';
import StartNewGameButton from '../Buttons/StartNewGameButton';

import './Header.scss';

export const LandingPageHeader: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
  return (
    <>
      <button className="secondary">Sign up</button>
      <button className="secondary">Login</button>
      <StartNewGameButton />
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