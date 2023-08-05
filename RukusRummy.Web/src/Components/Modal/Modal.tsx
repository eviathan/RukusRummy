import './Modal.scss';

export const Modal: React.FC<React.PropsWithChildren<{}>> = ({ children }) => {
    return (
        <div className="modal">
            <div className='container'>
                {children}
            </div>
        </div>
    );
}
  
export default Modal;