import {
    withFocusable,
} from "@noriginmedia/react-spatial-navigation";

const styles = {
    focused: {
        background: "red"
    }
};

const Button = ({ text, focused, icon }) => {
    return (
        <div className="item" onClick={() => alert("HELLO")} style={focused ? styles.focused : {}}>
            {icon}
            <div className="text">{text}</div>
        </div>
    );
};

export default withFocusable()(Button);
