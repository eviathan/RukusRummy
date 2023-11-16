import { ChangeEvent, useState } from 'react';
import './TextInput.scss';

interface IProps {
    placeholder?: string;
    label?: string;
    maxLength?: number;
    onChange: (event: ChangeEvent<HTMLInputElement>) => void;
    validate?: (value: string) => boolean;
}

export const TextInput: React.FC<React.PropsWithChildren<IProps>> = ({ placeholder, label, maxLength, onChange, validate }) => {
    const [inputValue, setInputValue] = useState('');

    function handleOnChange(event: ChangeEvent<HTMLInputElement>) {
        const value = event.target.value;

        if (value === "" || !validate || (validate && validate(value))) {
            setInputValue(value);
            onChange(event);
        }
    }

    return (
        <div className="text-input">
            <input 
                type="text" 
                value={inputValue}
                required={true} 
                placeholder={placeholder}
                maxLength={maxLength}
                onChange={handleOnChange} />
                <span className="highlight"></span>
                <span className="bar"></span>
            <label>{label}</label>
        </div>
    );
}
  
export default TextInput;
  
  