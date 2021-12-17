import {
    withFocusable,
} from "@noriginmedia/react-spatial-navigation";
import { useEffect } from "react";

const Container = ({ children, setFocus }) => {
    useEffect(() => {
        setFocus();
    }, [setFocus]);

    return <div className="container">{children}</div>;
};

export default withFocusable()(Container); 