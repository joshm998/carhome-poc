import React from 'react';
import { useNavigate } from "react-router-dom";

import Button from '../components/Button';
import Container from '../components/Container';


export default function Settings() {
    let navigate = useNavigate();
    const handleClick = () => {
        navigate("/settings", { replace: true });
        //window.api.runCommand("explorer.exe")
    }

    return (
        <>
            <h2 className='header'>Settings</h2>
            <Container>
                <>
                    <Button
                        focusKey="1"
                        text="Back"
                        onEnterPress={() => navigate("/")}
                    />
                    <Button text="Bluetooth" />
                    <Button text="Android Auto" />
                </>
            </Container>
        </>
    );
}