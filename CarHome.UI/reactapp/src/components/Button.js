import {
    withFocusable,
} from "@noriginmedia/react-spatial-navigation";

const styles = {
    focused: {
        background: "red"
    }
};

const Button = ({ text, focused, icon, onClick }) => {
    return (
        <div className={focused ? "item focused" : "item"} onClick={onClick}>
            <i className={`icon ${icon}`}></i>     
            <div className="text">{text}</div>
        </div>
    );
};

export default withFocusable()(Button);
