import Timer from '../Timer/Timer';

import './Header.scss';

export const LandingPageHeader: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
  return (
    <>
      <button className="secondary">Sign up</button>
      <button className="secondary">Login</button>
      <button>Start new game</button>
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