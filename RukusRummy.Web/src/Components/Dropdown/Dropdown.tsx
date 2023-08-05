import { useState } from 'react';

import { BiSolidChevronDown } from 'react-icons/bi';

import './Dropdown.scss';

export interface IDropdownOption {
    label: string;
    value: string;
    cssClass?: string;
}

interface IProps {
    options: Array<IDropdownOption>;
    label?: string;
    onChange: (value: string) => void;
}

export const Dropdown: React.FC<React.PropsWithChildren<IProps>> = ({ options, label, onChange }) => {
    const [selectedOption, setSelectedOption] = useState("");

    var optionCssClass = (option: IDropdownOption) => {
        return `option${option.cssClass ? ` ${option.cssClass}` : ''}`;
    }

    const handleOnChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setSelectedOption(event.target.value);
        onChange(event.target.value);
    };

    return (
        <div className="dropdown">
            <p className='label'>{label}</p>
            <div className="selection">
                {options.map((option, index) => {
                    return (
                        <div className={optionCssClass(option)} key={index}>
                            <input                                
                                className="backing-field"
                                type="radio" id={`${index}`}
                                value={option.value}
                                name={label}
                                checked={selectedOption === option.value}
                                onChange={handleOnChange} />
                            <p className="label">{option.label}</p>
                        </div>
                    );
                })}
                <BiSolidChevronDown size={40} />
            </div>
            <ul className="list">
                {options.map((option, index) => { 
                    return (
                        <li key={index}>
                            <label className="option" htmlFor={`${index}`} >{option.label}</label>
                        </li>
                    );
                })}
            </ul>
        </div>
    );
}
  
export default Dropdown;
  
  