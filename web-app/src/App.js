import React, { Component } from 'react';
import logo from './logo.svg';
import * as authActions from './actions/authActions.js'
import LoginForm from './components/LoginForm'
import ReactDOM from 'react-dom';
import './App.css';

class App extends Component {
  state = {isAuth: false}
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
        </header>
        <div class="container" id="container">
          { //Check auth
          (!this.state.isAuth)
          ? <LoginForm />
          : console.log("Eee, authenticated!") }
        </div>
      </div>
    );
  }

  async componentDidMount() {
    const currentUser = await authActions.GetCurrentUser();
    if (currentUser == null){
      this.setState({isAuth: false})
    }
    else {
      this.setState({isAuth: true})
    }
  }
}

export default App;