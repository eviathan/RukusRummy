import Header from "./Header";

export const Layout: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
      <div className="layout">
          <Header />
          {children}
      </div>
    );
  }
  
  export default Layout;
  
  