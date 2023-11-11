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
        <div className='advocates'>
          <p>Trusted by teams at</p>
          <ul>
            <li>
              <img src="https://www.lbresearch.com/wp-content/themes/lbr/assets/images/LBR_Logo_Black.svg" alt="" />
            </li>
          </ul>
        </div>
      </section>
    );
  }
  
  export default HeroSection;
  
  