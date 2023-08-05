import { Route, Routes } from "react-router-dom";
import Header from "./Header/Header";

import CreateGamePage from '../Pages/CreateGamePage';
import LandingPage from '../Pages/LandingPage';
import SessionPage from '../Pages/SessionPage';

import './Layout.scss';

export const Layout: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
      <div className="layout">
          <Header />
          {children}
          <main className="wrapper">
            <Routes>
              <Route path="/" element={<LandingPage />} />
              <Route path="/session/:id" element={<SessionPage />} />
              <Route path="/create-game" element={<CreateGamePage />} />
            </Routes>
          </main>
      </div>
    );
  }
  
  export default Layout;
  
  