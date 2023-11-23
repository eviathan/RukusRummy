import { useEffect, useState } from 'react';

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
    placeholder?: string;
    useDefault?: boolean;
    onChange: (value: string) => void;
}

export const Dropdown: React.FC<React.PropsWithChildren<IProps>> = ({ options, label, placeholder, useDefault, onChange }) => {
    const [selectedOption, setSelectedOption] = useState<string | undefined>();
    const [menuOpen, setMenuOpen] = useState(false);

    useEffect(() => {
        setSelectedOption(useDefault 
            ? options.filter(x => x.value !== 'button')[0]?.value 
            : undefined
        );
    }, []);

    var optionCssClass = (option: IDropdownOption) => {
        return `option${option.cssClass ? ` ${option.cssClass}` : ''}`;
    }

    const handleOnChange = (value: string) => {
        if(value !== 'button') {
            setSelectedOption(value);
        }
        
        onChange(value);
        setMenuOpen(false);
    };

    return (
        <div className="dropdown" onMouseLeave={() => setMenuOpen(false)}>
            <p className='label'>{label}</p>
            <div className="selection" onClick={() => setMenuOpen(!menuOpen)}>
                <label>{options.find(x => x.value === selectedOption)?.label ?? placeholder}</label>
                <BiSolidChevronDown size={24} />
            </div>
            <div className='list-wrapper'>
                <ul className={`list${menuOpen ? ' visible' : ''}`}>
                    {options.filter(x => x.value !== selectedOption).map((option, index) => {
                        return (
                            <li key={index} onClick={() => handleOnChange(option.value) }>
                                <label className={`option${ selectedOption === option.value ? ' selected' : ''} ${option.cssClass}`} htmlFor={`${index}`}>{option.label}</label>
                            </li>
                        );
                    })}
                </ul>
            </div>
        </div>
    );
}
  
export default Dropdown;
  
  