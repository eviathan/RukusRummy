import { Route, Routes } from "react-router-dom";
import './Header.scss';

export const Header: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
      <header>
        <Routes>
          <Route path="/" element={
            <div className="main">
              <img src="" alt="logo" />
              <p>Dropdown: GameSettings & voting history</p>
              <p>Personal Settings Dropdown</p>
              <button>Invite Players</button>
              <button>Show issues</button>
              <button>Timer</button>
            </div>} />
          <Route path="/:id" element={<h1>Session Header</h1>} />
          <Route path="/create-game" element={<h1>Create Game Header</h1>} />
        </Routes>
      </header>
    );
  }
  
  export default Header;
  
  