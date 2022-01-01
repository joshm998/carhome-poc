import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import Button from '../components/Button';
import Container from '../components/Container';
import Header from '../components/Header';

function ListView(props) {
    const { data, handleAction } = props;
    return (
        <>
            <Header title={data.screenTitle} time="3:30PM"/>
            <div className="list-view">
                <Container>
                    <>
                            {data.menuItems.map((item, i) => (
                                <Button text={item.title}
                                    icon={item.icon}
                                    onEnterPress={() => props.handleAction(item.command, item.commandType, item.api)}
                                    onClick={() => props.handleAction(item.command, item.commandType, item.api)}

                                />
                            ))}
                    </>
                </Container>
            </div>
        </>
    );
}
export default ListView;