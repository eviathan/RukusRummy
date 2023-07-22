import { RouterProvider, createBrowserRouter } from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element:
    <>
      <div>
        <h1>Header</h1>
        <p>Dropdown: GameSettings & voting history</p>
        <p>Personal Settings Dropdown</p>
        <button>Invite Players</button>
        <button>Show issues</button>
      </div>
      <div>
        <h2>Subheader</h2>
        <button>Timer</button>
      </div>
    </>,
  },
  {
    path: "/:id",
    element: <h1>Session Header</h1>,
  },
  {
    path: "/create-game",
    element: <h1>test</h1>
  },
]);

export const Header: React.FC<{}> = () => {
    return (
      <div className="App">
        <header className="App-header">
          <RouterProvider router={router} />
        </header>
      </div>
    );
  }
  
  export default Header;
  
  