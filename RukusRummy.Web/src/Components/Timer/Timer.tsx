import './Timer.scss';
import { BsFillStopwatchFill } from 'react-icons/bs';

export const Timer: React.FC<React.PropsWithChildren<{}>> = () => {
    return (
        <div className="timer">
            <button><BsFillStopwatchFill fill='#469ada;' size={40}/></button>
        </div>
    );
  }
  
  export default Timer;
  
  