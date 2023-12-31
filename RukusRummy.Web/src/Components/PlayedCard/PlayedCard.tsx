import './PlayedCard.scss';

interface IProps {
    flipped?: boolean;
    name?: string;
    value?: string;
    spectator: boolean;
}

export const PlayedCard: React.FC<React.PropsWithChildren<IProps>> = ({ flipped, name, value, spectator }) => {

    const getCSSClass = (): string => {

        let style = ''
        
        if(value !== undefined && value !== "") {
            style = flipped ? 'front' : 'backside';
        }

        return `card ${style}`;
    }

    return (
        <>
        { !!name  
            ?
                <div className='played-card'>
                    <div className={getCSSClass()}>
                        {value}
                    </div>
                    <p>{name}</p>
                </div>
            : 
                null
        }
        </>
    );
}
  
export default PlayedCard;
  
  