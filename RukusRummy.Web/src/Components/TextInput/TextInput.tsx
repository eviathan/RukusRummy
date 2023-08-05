import { ChangeEvent } from 'react';
import './TextInput.scss';

interface IProps {
    placeholder?: string;
    label?: string;
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;
}

export const TextInput: React.FC<React.PropsWithChildren<IProps>> = ({ placeholder, label, onChange }) => {
    return (
        <div className="text-input">
            <input type="text" required={true} placeholder={placeholder} onChange={onChange} /><span className="highlight"></span><span className="bar"></span>
            <label>{label}</label>
        </div>
    );
}
  
export default TextInput;
  
  