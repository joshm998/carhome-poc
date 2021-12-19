import React from 'react';
import { useNavigate } from "react-router-dom";
import Button from '../components/Button';
import Container from '../components/Container';
import { PlayCircle } from 'react-ionicons'

export default function Home() {
    let navigate = useNavigate();
    const handleClick = event => {
        navigate("/settings", { replace: true });
        //window.api.runCommand("explorer.exe")
    }

    return (
        <>
            <div className="home-menu">
                <Container>
                    <>
                        <Button text="Android Auto" icon={<PlayCircle/>} />
                        <Button text="Media" icon={<PlayCircle/>} onEnterPress={() => navigate("/music")} />
                        <Button text="Bluetooth" icon={<PlayCircle/>} onEnterPress={() => navigate("/settings")} />
                        <Button text="Car" icon={<PlayCircle/>} onEnterPress={() => navigate("/settings")} />
                        <Button text="More" icon={<PlayCircle/>} onEnterPress={() => navigate("/settings")} />
                    </>
                </Container>
            </div>
        </>
    )
};