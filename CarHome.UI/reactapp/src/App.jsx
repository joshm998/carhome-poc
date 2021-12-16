import React, { Component } from 'react';
import { BrowserRouter as Router, Switch, Route, Link } from 'react-router-dom';
import Home from './components/Home';
import MediaPlayer from './components/MediaPlayer';
import './App.css';

function App() {
  return (
    <Router>
      <div>

        <nav className="navbar navbar-expand-sm navbar-light bg-faded">
          <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#nav-content" aria-controls="nav-content" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>

          <a className="navbar-brand text-muted" href="#">Demos</a>

          <div className="collapse navbar-collapse justify-content-end">
            <ul className="nav nav-pills">
              <li className="nav-item"><Link to={'/'} className="nav-link"> home </Link></li>
              <li className="nav-item"><Link to={'/music'} className="nav-link"> Music Player </Link></li>
            </ul>
          </div>
        </nav>

        <hr />

        <Switch>
          <Route exact path='/' component={Home} />
          <Route path='/music' component={MediaPlayer} />
          <Route path="*" component={Home} />
        </Switch>
      </div>
    </Router>
  );
}

export default App;