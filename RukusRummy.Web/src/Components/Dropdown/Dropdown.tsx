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
    const [selectedOption, setSelectedOption] = useState(options[0].value);
    const [menuOpen, setMenuOpen] = useState(false);

    var optionCssClass = (option: IDropdownOption) => {
        return `option${option.cssClass ? ` ${option.cssClass}` : ''}`;
    }

    const handleOnChange = (value: string) => {

        const label = options.find(x => x.value === value)?.label;

        if(label === 'Create a custom Deck') {
            console.log('Create a custom deck');
        } else {
            setSelectedOption(value);
            onChange(value);
        }

        setMenuOpen(false);
    };

    return (
        <div className="dropdown" onMouseLeave={() => setMenuOpen(false)}>
            <p className='label'>{label}</p>
            <div className="selection" onClick={() => setMenuOpen(!menuOpen)}>
                <label>{options.find(x => x.value === selectedOption)?.label}</label>
                <BiSolidChevronDown size={24} />
            </div>
            <ul className={`list${menuOpen ? ' visible' : ''}`}>
                {options.filter(x => x.value !== selectedOption).map((option, index) => {
                    return (
                        <li key={index} onClick={() => handleOnChange(option.value) }>
                            <label className={`option${ selectedOption === option.value ? ' selected' : ''}`} htmlFor={`${index}`}>{option.label}</label>
                        </li>
                    );
                })}
            </ul>
        </div>
    );
}
  
export default Dropdown;
  
  