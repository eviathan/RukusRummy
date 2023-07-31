import { Route, Routes } from "react-router-dom";
import Header from "./Header/Header";

import CreateGame from '../Pages/CreateGame';
import LandingPage from '../Pages/LandingPage';
import Session from '../Pages/Session';

export const Layout: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
      <div className="layout">
          <Header />
          {children}
          <main className="wrapper">
            <Routes>
              <Route path="/" element={<LandingPage />} />
              <Route path="/:id" element={<Session />} />
              <Route path="/create-game" element={<CreateGame />} />
            </Routes>
          </main>
      </div>
    );
  }
  
  export default Layout;
  
  