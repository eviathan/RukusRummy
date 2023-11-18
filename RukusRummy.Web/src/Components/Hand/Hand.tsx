import Deck from '../../Models/Deck';

import './Hand.scss';

interface IProps {
    type?: "simple"| "normal";
    deck: Deck;
    selectedCard?: number;
    onSelectCard: (value?: number) => void;
}

export const Hand: React.FC<React.PropsWithChildren<IProps>> = ({ type, deck, selectedCard, onSelectCard }) => {
    const cards = deck?.values?.split(',') ?? [];

    function handleOnClick(card: number) {
        if(card === selectedCard) {
            onSelectCard(undefined);
        } else {
            onSelectCard(card);
        }
    };

    return (
        <>
        {
            deck.values === "" 
            ?
                <></>
            :
                <div className="hand">
                    {
                        type === "simple"
                        ? <></>
                        : <p>Choose your card 👇</p>
                    }
                    <div className='wrapper'>
                        <div className='cards'>
                            {cards.map((card, index) => 
                                <div 
                                    key={index}
                                    className={`card${ selectedCard === index ? ' selected' : '' }`} 
                                    onClick={() => handleOnClick(index)}>
                                    {card}                        
                                </div>
                            )}
                        </div>
                    </div>
                </div>
        }
        </>
    );
}
  
export default Hand;
  
  