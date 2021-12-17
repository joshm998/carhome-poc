import React from 'react';
import { useNavigate } from "react-router-dom";
import Button from '../components/Button';
import Container from '../components/Container';


export default function Home() {
    let navigate = useNavigate();
    const handleClick = event => {
        navigate("/settings", { replace: true });
        //window.api.runCommand("explorer.exe")
    }

    return (
        <>
            <h2 className='header'>Home</h2>
            <Container>
                <>
                    <div className="row">
                        <Button text="Test" />
                        <Button text="Music Player" onEnterPress={() => navigate("/music")} />
                        <Button text="Settings" onEnterPress={() => navigate("/settings")} />
                    </div>
                </>
            </Container>
        </>
    )
};