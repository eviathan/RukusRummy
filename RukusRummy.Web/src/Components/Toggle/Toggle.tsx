import './Toggle.scss';

interface IProps {
    label?: string;
}

export const Toggle: React.FC<React.PropsWithChildren<IProps>> = ({ label }) => {
    return (
        <div className="toggle">
            <p>{label}</p>
            <label className="switch">
                <input type="checkbox" />
                <span className="slider round"></span>
            </label>
        </div>
    );
}
  
export default Toggle;
  
  