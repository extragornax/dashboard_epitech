import React from 'react';
import { Switch, Route } from 'react-router-dom';

import Dashboard from './components/Dashboard';
import Connection from './components/Connection/index'
import './App.css';

const App = () => (
  <main>
    <Switch>
      <Route exact path="/dashboard" component={ Dashboard } />
      <Route path="/connection" component={ Connection } />
    </Switch>
  </main>
);

export default App;
