import React, { Component } from 'react';
import './LoginForm.css';

class LoginForm extends Component {
  render() {
    return (
      <div className="login-form-container">
        <h3>Постить чужие фоточки, смотреть чужие фоточки!</h3>
        <form>
          <div class="text-inputs">
            <input type="text" id="userName" placeholder="Ваше имя"></input>
            <input type="text" id="userEmail" placeholder="Ваш email"></input>
            <input type="password" id="userPassword" placeholder="Ваш пароль"></input>
          </div>
          <div class="sign-container">
            <label>Начать жить и перестать жрать</label>
            <button type="button">Регистрация</button>
          </div>
          <div class="sign-container">
          <label>Уже начали жить с сервисом? Залогиньтесь</label>
          <button type="button">Войти</button>
          </div>
        </form>
      </div>
    );
  }
}

export default LoginForm;