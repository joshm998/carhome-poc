import {
    withFocusable,
} from "@noriginmedia/react-spatial-navigation";

const styles = {
    focused: {
        background: "red"
    }
};

const Button = ({ text, focused }) => {
    return (
        <div className="item" onClick={() => alert("HELLO")} style={focused ? styles.focused : {}}>
            <div className="text">{text}</div>
        </div>
    );
};

export default withFocusable()(Button);
