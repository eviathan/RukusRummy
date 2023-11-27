import './PlayedCard.scss';

interface IProps {
    flipped?: boolean;
    name?: string;
    value?: string;
    spectator: boolean;
    hidden?: boolean;
}

export const PlayedCard: React.FC<React.PropsWithChildren<IProps>> = ({ flipped, name, value, spectator, hidden }) => {

    const getCSSClass = (): string => {

        let style = ''
        
        if(value !== undefined && value !== "") {
            style = flipped ? 'front' : 'backside';
        }

        return `card ${style}`;
    }

    return (
        <>
        { !hidden  
            ?
                <div className='played-card'>
                    <div className={getCSSClass()}>
                        {value}
                    </div>
                    { !!name 
                        ? <p>{name}</p>
                        : <></>
                    }
                </div>
            : 
                null
        }
        </>
    );
}
  
export default PlayedCard;
  
  