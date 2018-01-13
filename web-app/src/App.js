import React, { Component } from 'react';
import logo from './logo.svg';
import * as authActions from './actions/authActions.js'
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Food Tracker</h1>
        </header>
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
        </p>
      </div>
    );
  }

  async componentDidMount() {
    const x = await authActions.GetCurrentUser();
    //this.setState({ x });
  }  
}

export default App;