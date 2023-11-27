
import PlayedCard from '../PlayedCard/PlayedCard';
import './Results.scss';

interface IProps {
    visible?: boolean;
}

export const Results: React.FC<React.PropsWithChildren<IProps>> = ({ visible }) => {

    function getCssClass() {
        const hiddenCss = !visible ? " hidden" : "";

        return `results ${hiddenCss}`;
    }

    return (
        <div className={getCssClass()}>
            <div className='wrapper'>
                <div className='top-section'>
                    <div className='average'>
                        <p>Average:</p>
                        <p><strong>35</strong></p>
                    </div>
                    <div>
                        <p>Agreement:</p>
                        <p>chart goes here</p>
                    </div>
                </div>
                <ul>
                    <li>
                        <PlayedCard 
                            flipped
                            value='1'
                            spectator
                        />
                        <p>1 Vote</p>
                    </li>
                </ul>
            </div>
        </div>
    );
}
  
export default Results;
  
  