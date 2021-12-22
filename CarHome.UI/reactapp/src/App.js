import './App.scss';
import React, {useState, useEffect, useCallback} from 'react';
import {
  HashRouter,
  Routes,
  Route,
} from "react-router-dom";
import Home from './pages/Home';
import Settings from './pages/Settings';
import Music from './pages/ListView';
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

  const handleAction = (command, commandType, api) => {
    setLoading(true);
    console.log(command, commandType, api)
    let url = `http://backend/${api}/${commandType}`
    console.log(api)
    if (api == "Music") 
    {
      console.log("a")
      url = `http://backend/${api}`
    }
    axios.get(url, {params: {command: command, commandType: commandType}})
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
        return <Music data={data} handleAction={handleAction}/>
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
