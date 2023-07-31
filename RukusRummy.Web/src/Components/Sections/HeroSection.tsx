import StartNewGameButton from '../Buttons/StartNewGameButton';
import './HeroSection.scss';

export const HeroSection: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
      <section className="hero">
        <h1>Scrum Poker for agile development teams</h1>
        <p>Have fun while being productive with our simple and complete tool.</p>
        <StartNewGameButton />
      </section>
    );
  }
  
  export default HeroSection;
  
  