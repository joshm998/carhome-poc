import './App.scss';
import React, {useState, useEffect, useCallback} from 'react';
import {
  HashRouter,
  Routes,
  Route,
} from "react-router-dom";
import Home from './pages/Home';
import Settings from './pages/Settings';
import Music from './pages/Music';
import { initNavigation } from '@noriginmedia/react-spatial-navigation';
import axios from 'axios';

initNavigation();

function App() {

  const [loading, setLoading] = useState(true);
  const [data, setData] = useState([]);

  useEffect(() => {
    if (loading) {
      axios.get('http://backend/screen/get')
        .then(response => {
          console.log(response.data);
          setData(response.data);
          setLoading(false);
        })
        .catch(error => {
          console.log(error);
        });
    }
  });

  const handleAction = (command, commandType) => {
    console.log(command, commandType)
    axios.get('http://backend/screen/navigate', {params: {path: "media"}})
        .then(response => {
            console.log(response.data);
            setData(response.data);
            setLoading(false);
        })
        .catch(error => {
            console.log(error);
        });
  };

  const getView = ((screenType) => {
    switch(screenType) {
      case 'HomeScreen':
        return <Home data={data} handleAction={handleAction}/>
      default: 
        return <Music/>
    }
  })

  return (
    <div className="App">
      {!loading && getView(data.screenType)}
      {/* <HashRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="music" element={<Music />} />
          <Route path="settings" element={<Settings />} />
        </Routes>
      </HashRouter> */}
    </div>
  );
}

export default App;
