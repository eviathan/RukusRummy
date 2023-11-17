import { useState } from 'react';

import './Hand.scss';
import Deck from '../../Models/Deck';

interface IProps {
    type?: "simple"| "normal";
    deck: Deck;
    onSelectCard: (value?: number) => void;
}

export const Hand: React.FC<React.PropsWithChildren<IProps>> = ({ type, deck, onSelectCard }) => {
    const [selectedCard, setSelectedCard] = useState<number |undefined>(undefined);

    const cards = deck?.values?.split(',') ?? [];

    const handleOnClick = (card: number) => {
        debugger;
        if(card === selectedCard) {
            setSelectedCard(undefined);
            onSelectCard(undefined);
        } else {
            setSelectedCard(card);
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
                        ?
                        <></>
                        :
                        <p>Choose your card 👇</p>
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
  
  