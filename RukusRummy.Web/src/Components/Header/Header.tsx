import { ReactNode } from "react";
import { Route, Routes } from "react-router-dom";

import { ReactComponent as Logo } from '../../assets/logo-black.svg';

import { LandingPageHeader } from "./LandingPageHeader";
import SessionPageHeader, { SessionPageSubheader } from "./SessionPageHeader";
import CreateGamePageHeader from "./CreateGamePageHeader";

import './Header.scss';

const HeaderWrapper: React.FC<React.PropsWithChildren<{ header: ReactNode, subheader?: ReactNode }>> = ({ header, subheader }) => {
  return (
    <div className="wrapper">
      <div className="main">
        <Logo className="logo" height={120} />
        <div>
          {header}
        </div>
      </div>
      {subheader ?
        <div className="sub-header">
          {subheader}
        </div> : null }
    </div>
  )
}

export const Header: React.FC<React.PropsWithChildren<{}>> = () => {
    return (
      <header>
        <Routes>
          <Route path="/" element={
              <HeaderWrapper header={<LandingPageHeader />} />
          }/>
          <Route path="/session/:id" element={
              <HeaderWrapper 
                header={<SessionPageHeader />} 
                // subheader={<SessionPageSubheader />} 
              />
          }/>
          <Route path="/create-game" element={
              <HeaderWrapper header={<CreateGamePageHeader />} />
          }/>
        </Routes>
      </header>
    );
  }
  
  export default Header;
  
  