import React, {useState} from 'react';
import axios from 'axios';

function MediaPlayer(props) {
    const [loading, setLoading] = useState(true);
    const [data, setData] = useState([]);

    const loadMusic = (event) => {
        event.preventDefault()
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
        event.preventDefault()
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
        event.preventDefault()
        axios.get('http://backend/music/play')
        .then(response => {
            console.log(response.data);
            setData(response.data);
        })
        .catch(error => {
            console.log(error);
        });
    }

    return (
        <div className="container-fluid">
            <div className="row">
                <h1 onClick={loadMusic}>Open File</h1>
                <h2 onClick={playMusic}>Play</h2>
                <h2 onClick={pauseMusic}>Pause</h2>
                {!loading && (
                    <div>
                        {data.Title}
                        {data.State}
                        {data.Volume}
                        {data.Duration}
                        {data.Position}
                    </div>
                )}
            </div>
        </div>
    );
}
export default MediaPlayer;