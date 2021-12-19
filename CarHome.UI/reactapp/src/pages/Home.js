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
            <div className="home-menu">
                <Container>
                    <>
                        <Button text="Android Auto" icon="bi-play-circle-fill" />
                        <Button text="Media" icon="bi-play-circle-fill" onEnterPress={() => navigate("/music")} />
                        <Button text="Bluetooth" icon="bi-play-circle-fill" onEnterPress={() => navigate("/settings")} />
                        <Button text="Car" icon="bi-play-circle-fill" onEnterPress={() => navigate("/settings")} />
                        <Button text="More" icon="bi-play-circle-fill" onEnterPress={() => navigate("/settings")} />
                    </>
                </Container>
            </div>
        </>
    )
};