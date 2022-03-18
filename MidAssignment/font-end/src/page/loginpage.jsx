import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import '../style.css';
export default function HomePage() {
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [emailError, setEmailError] = useState();
  const [passwordError, setPasswordError] = useState();

  const navigatge = useNavigate();

  function onEmailChange(newEmail) {
    setEmail(newEmail);

    if (newEmail === "" || newEmail === undefined) {
      setEmailError("Required");
      return false;
    } else if (
      !String(newEmail)
        .toLowerCase()
        .match(/^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$/g)
    ) {
      setEmailError("Must be a valid email");
      return false;
    } else {
      setEmailError("");
      return true;
    }
  }

  function onPasswordChange(newPassword) {
    setPassword(newPassword);

    if (newPassword === "" || password === undefined) {
      setPasswordError("Required");
      return false;
    } else if (newPassword.length < 8) {
      setPasswordError("At least 8 characters");
      return false;
    } else {
      setPasswordError("");
      return true;
    }
  }

  function onSubmit() {
    if (onEmailChange(email) && onPasswordChange(password)) {
      fetch("https://60dff0ba6b689e001788c858.mockapi.io/token", {
        method: "GET",
      })
        .then(function (response) {
          return response.json();
        })
        .then(function (json) {
          const { token, userId } = json;
          localStorage.setItem("token", token);
          localStorage.setItem("userId", userId);
          navigatge("/profile");
          window.location.reload();
        });
    }
  }

  return (
   
      <div class="container">
        <div class="login-form">
          <div class="main-div">
            <div class="panel">
              <h1> Login</h1>
              <p>Please enter your email and password</p>
            </div>
            <form id="Login">
              <div className="form-group">
                <input autoFocus type="email" className="form-control" placeholder="Enter email" onChange={(e) => onEmailChange(e.target.value)} />
                {emailError && <div style={{ color: "red" }}>{emailError}</div>}
              </div>
              <div className="form-group">
                <input type="password" className="form-control" placeholder="Enter password" onChange={(e) => onPasswordChange(e.target.value)} />
                {passwordError && <div style={{ color: "red" }}>{passwordError}</div>}
              </div>
              <div className="form-group">
                <div className="custom-control custom-checkbox">
                  <input type="checkbox" className="custom-control-input" id="customCheck1" />
                  <label className="custom-control-label" htmlFor="customCheck1">Remember me</label>
                </div>
              </div>
              <button type="submit" className="btn btn-primary btn-block" onClick={onSubmit}>Submit</button>
              <p className="forgot-password text-right">
                Forgot <a href="#">password?</a>
              </p>
            </form>
          </div>
        </div>
        <p>Hêlo</p>
      </div>
   
  );

}
