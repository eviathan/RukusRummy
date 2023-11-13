
import { useState } from 'react';

import './Table.scss';

interface IProps {
}

export const Table: React.FC<React.PropsWithChildren<IProps>> = () => {
    return (
        <div className="table">
            <div className='left-side'></div>
            <div className='middle-side'>
                <div className='top-side'></div>
                <div className='center'>
                    <button className='primary'>Reveal cards</button>
                </div>
                <div className='bottom-side'></div>
            </div>
            <div className='right-side'></div>
        </div>
    );
}
  
export default Table;
  
  