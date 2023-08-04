import StartNewGameButton from '../Buttons/StartNewGameButton';
import './HeroSection.scss';

interface IProps {
  title?: string;
  subTitle?: string;
}

export const HeroSection: React.FC<React.PropsWithChildren<IProps>> = ({ children, title, subTitle }) => {
    return (
      <section className="hero">
        <h1>{title}</h1>
        <p>{subTitle}</p>
        <StartNewGameButton />
      </section>
    );
  }
  
  export default HeroSection;
  
  