import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import Button from '../components/Button';
import Container from '../components/Container';

function ListView(props) {
    const { data, handleAction } = props;
    return (
        <>
            <h2 className='header'>Home</h2>
            <Container>
                <>
                    <div className='row'>
                        {data.menuItems.map((item, i) => (
                            <Button text={item.title}
                                icon={item.icon}
                                onEnterPress={() => props.handleAction(item.command, item.commandType, item.api)}
                                onClick={() => props.handleAction(item.command, item.commandType, item.api)}

                            />
                        ))}
                    </div>
                </>
            </Container>
        </>
    );
}
export default ListView;