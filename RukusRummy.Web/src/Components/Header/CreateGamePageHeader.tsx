import './Header.scss';

const CreateGamePageHeader: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
      <div className='create-game-header'>
        <h1>Create Game</h1>
      </div>
    );
  }
  
export default CreateGamePageHeader;