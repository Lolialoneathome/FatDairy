import React, { Component } from 'react';
import logo from './logo.svg';
import * as authActions from './actions/authActions.js'
import LoginForm from './components/LoginForm'
import ReactDOM from 'react-dom';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
        </header>
        <div class="container" id="container">

        </div>
      </div>
    );
  }

  async componentDidMount() {
    const currentUser = await authActions.GetCurrentUser();
    if (currentUser == null){
      this.showLoginPage()
    }
    else {
      this.showMainProfilePage()
    }
  }

  showLoginPage() {
    ReactDOM.render(<LoginForm />, document.getElementById("container"))
  }

  showMainProfilePage() {

  }
}

export default App;