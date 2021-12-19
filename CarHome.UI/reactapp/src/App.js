import './App.scss';
import React from 'react';
import {
  HashRouter,
  Routes,
  Route
} from "react-router-dom";
import Home from './pages/Home';
import Settings from './pages/Settings';
import Music from './pages/Music';
import { initNavigation } from '@noriginmedia/react-spatial-navigation';

initNavigation();

function App() {
  return (
    <div className="App">

      <HashRouter>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="music" element={<Music />} />
          <Route path="settings" element={<Settings />} />
        </Routes>
      </HashRouter>
    </div>
  );
}

export default App;
