import './PlayedCard.scss';

interface IProps {
    flipped?: boolean;
    name: string;
    value?: string;
}

export const PlayedCard: React.FC<React.PropsWithChildren<IProps>> = ({ flipped, name, value }) => {

    const getCSSClass = (): string => {

        let style = ''
        
        if(value) {
            style = flipped ? 'front' : 'backside';
        }

        return `card ${style}`;
    }

    return (
        <div className='played-card'>
            <div className={getCSSClass()}>
                {value}
            </div>
            <p>{name}</p>
        </div>
    );
}
  
export default PlayedCard;
  
  