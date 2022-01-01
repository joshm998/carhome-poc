const Header = ({ title, time }) => {
    return (
        <div className='header'>
            <div className="title">{title}</div>
            <div className="time">{time}</div>
        </div>
    );
};

export default Header;
