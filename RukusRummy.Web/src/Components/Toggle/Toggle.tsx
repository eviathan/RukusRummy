import './Toggle.scss';

interface IProps {
    label?: string;
    onChange: (value: boolean) => void;
}

export const Toggle: React.FC<React.PropsWithChildren<IProps>> = ({ label, onChange }) => {
    return (
        <div className="toggle">
            <p>{label}</p>
            <label className="switch">
                <input type="checkbox" onChange={(event) => onChange(event.target.checked)} />
                <span className="slider round"></span>
            </label>
        </div>
    );
}
  
export default Toggle;
  
  