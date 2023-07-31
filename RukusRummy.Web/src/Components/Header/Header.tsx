import { ReactNode } from "react";
import { Route, Routes } from "react-router-dom";
import { LandingPageHeader, LandingPageSubheader } from "./LandingPageHeader";
import SessionPageHeader from "./SessionPageHeader";
import CreateGamePageHeader from "./CreateGamePageHeader";
import { ReactComponent as Logo } from '../../assets/logo-black.svg';

import './Header.scss';

const HeaderWrapper: React.FC<React.PropsWithChildren<{ header: ReactNode, subheader?: ReactNode }>> = ({ header, subheader }) => {
  return (
    <div className="wrapper">
      <div className="main">
        <Logo className="logo" height={120} />
        {header}
      </div>
      <div>
        {subheader}
      </div>
    </div>
  )
}

export const Header: React.FC<React.PropsWithChildren<{}>> = () => {
    return (
      <header>
        <Routes>
          <Route path="/" element={
              <HeaderWrapper header={<LandingPageHeader />} subheader={<LandingPageSubheader />} />
          }/>
          <Route path="/:id" element={
              <HeaderWrapper header={<SessionPageHeader />} />
          }/>
          <Route path="/create-game" element={
              <HeaderWrapper header={<CreateGamePageHeader />} />
          }/>
        </Routes>
      </header>
    );
  }
  
  export default Header;
  
  