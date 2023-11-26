import { useContext, useState } from 'react';

import './Loading.scss';

interface IProps { 
}

// TODO: Rename this to ChooseUserModal
export const Loading: React.FC<React.PropsWithChildren<IProps>> = () => {

    return (
        <div className="loading">
            <h1>Loading!</h1>
        </div>
    );
}
  
export default Loading;