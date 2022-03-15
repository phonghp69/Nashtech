import React, { useState } from 'react';
import { useNavigate } from "react-router-dom";

export default function HomePage() {
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [emailError, setEmailError] = useState();
  const [passwordError, setPasswordError] = useState();

  const navigatge = useNavigate();

  function onEmailChange(newEmail) {
    setEmail(newEmail);

    if (newEmail === '' || newEmail === undefined) {
      setEmailError('Required');
      return false;
    } else if (
      !String(newEmail)
        .toLowerCase()
        .match(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$/g)
    ) {
      setEmailError('Must be a valid email');
      return false;
    } else {
      setEmailError('');
      return true;
    }
  }

  function onPasswordChange(newPassword) {
    setPassword(newPassword);

    if (newPassword === '' || password === undefined) {
      setPasswordError('Required');
      return false;
    } else if (newPassword.length < 8) {
      setPasswordError('At least 8 characters');
      return false;
    } else {
      setPasswordError('');
      return true;
    }
  }

  function onSubmit() {
    if (onEmailChange(email) && onPasswordChange(password)) {
      fetch('https://60dff0ba6b689e001788c858.mockapi.io/token', {
        method: 'GET',
      })
        .then(function (response) {
          return response.json();
        })
        .then(function (json) {
          const { token, userId } = json;
          localStorage.setItem('token', token);
          localStorage.setItem('userId', userId);
          navigatge('/profile');
          window.location.reload();
        });
    }
  }

  return (
    <div>
      <input
        value={email}
        onChange={(e) => onEmailChange(e.target.value)}
        type="text"
        placeholder="Email"
      />
      <br />
      {emailError && <div style={{ color: 'red' }}>{emailError}</div>}
      <br />
      <input
        value={password}
        onChange={(e) => onPasswordChange(e.target.value)}
        type="password"
        placeholder="Pasword"
      />
      {passwordError && <div style={{ color: 'red' }}>{passwordError}</div>}
      <br />
      <br />
      <button onClick={onSubmit}>Submit</button>
    </div>
  );
}