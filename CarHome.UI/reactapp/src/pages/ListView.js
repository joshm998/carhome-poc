import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import Button from '../components/Button';
import Container from '../components/Container';

function ListView(props) {
    const { data, handleAction } = props;
    return (
        <>
            <h2 className='header'>{data.screenTitle}</h2>
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