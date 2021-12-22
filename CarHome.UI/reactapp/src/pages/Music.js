import React, {useState} from 'react';
import axios from 'axios';
import { useNavigate } from "react-router-dom";
import Button from '../components/Button';
import Container from '../components/Container';

function Music(props) {

    const [loading, setLoading] = useState(true);
    const [data, setData] = useState([]);

    const loadMusic = (event) => {
        axios.get('http://backend/music/load', {params: {path: "C:\\Users\\Josh\\Desktop\\"}})
        .then(response => {
            console.log(response.data);
            setData(response.data);
            setLoading(false);
        })
        .catch(error => {
            console.log(error);
        });
    }

    const pauseMusic = (event) => {
        axios.get('http://backend/music/pause')
        .then(response => {
            console.log(response.data);
            setData(response.data);
        })
        .catch(error => {
            console.log(error);
        });
    }

    const playMusic = (event) => {
        axios.get('http://backend/music/play')
        .then(response => {
            console.log(response.data);
            setData(response.data);
        })
        .catch(error => {
            console.log(error);
        });
    }

    const listDrives = (event) => {
        axios.get('http://backend/drives/list')
        .then(response => {
            console.log(response.data);
        })
        .catch(error => {
            console.log(error);
        });
    }

    const getScreen = (event) => {
        axios.get('http://backend/screen')
        .then(response => {
            console.log(response.data);
        })
        .catch(error => {
            console.log(error);
        });
    }

    return (
        <>
            <h2 className='header'>Home</h2>
            {!loading && (
                <div>
                    {data.Title}
                    {data.State}
                    {data.Volume}
                    {data.Duration}
                    {data.Position}
                </div>
            )}
            <Container>
                <>
                    <div className='row'>
                        <Button text='List Drives' onEnterPress={getScreen} />
                        <Button text='Open File' onEnterPress={loadMusic} />
                        <Button text='Play' onEnterPress={playMusic} />
                        <Button text='Pause' onEnterPress={pauseMusic} />
                        <Button text='Back' onEnterPress={() => alert('/')} />
                    </div>
                </>
            </Container>
        </>
    );
}
export default Music;