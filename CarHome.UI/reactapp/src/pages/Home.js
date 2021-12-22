import React, {useEffect, useState} from 'react';
import { useNavigate } from "react-router-dom";
import Button from '../components/Button';
import Container from '../components/Container';

export default function Home(props) {
    const {data, handleAction} = props;

    return (
        <>
            <div className="home-menu">
                <Container>
                    <>
                        {data.menuItems.map((item, i) => (
                            <Button text={item.title} 
                                    icon={item.icon} 
                                    onEnterPress={() => props.handleAction(item.command, item.commandType)} 
                                    onClick={() => props.handleAction(item.command, item.commandType)} 

                            />
                        ))}
                    </>
                </Container>
            </div>
        </>
    )
};