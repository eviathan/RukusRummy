import Header from "./Header";

export const Layout: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
      <div className="App">
        <header className="App-header">
          <Header />
          {children}
        </header>
      </div>
    );
  }
  
  export default Layout;
  
  