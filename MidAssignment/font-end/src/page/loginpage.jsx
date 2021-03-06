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
        method: "POST",
      })
        .then(function (response) {
          return response.json();
        })
        .then(function (json) {
          const { token, userId } = json;
          localStorage.setItem('token', token);
          localStorage.setItem('userId', userId);
          navigatge('/');
          window.location.reload();
        });
    }
  }

  return (

    <div class="container">
      <div class="row">
        <div class="col-md-5 mx-auto">
          <div id="first">
            <div class="myform form ">
              <div class="logo mb-3">
                <div class="col-md-12 text-center">
                  <h1>Login</h1>
                </div>
              </div>
              <div  class="login">
                <div class="form-group">
                  <label for="exampleInputEmail1">Email address</label>
                  <input value={email} type="text" name="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email" onChange={(e) => onEmailChange(e.target.value)} />
                {emailError && <div style={{ color: "red" }}>{emailError}</div>}
                </div>
                <div class="form-group">
                  <label for="exampleInputEmail1">Password</label>
                  <input value={password} type="password" name="password" id="password" class="form-control" aria-describedby="emailHelp" placeholder="Enter Password" onChange={(e) => onPasswordChange(e.target.value)} />
                {passwordError && <div style={{ color: "red" }}>{passwordError}</div>}
                </div>
                <br/>
                <div class="col-md-12 text-center ">
                  <button class=" btn btn-block mybtn btn-primary tx-tfm" onClick={onSubmit} >Login</button>
                </div>
                <div class="col-md-12 ">
                  <div class="login-or">
                    <hr class="hr-or"/>
                      <span class="span-or">or</span>
                  </div>
                </div>
                <div class="col-md-12 mb-3">
                  <p class="text-center">
                    <a href="javascript:void();" ><i class="fa fa-google-plus">
                    </i> Signup using Google
                    </a>
                  </p>
                </div>
                <div class="form-group">
                  <p class="text-center">Don't have account? <a href="../register" id="signup">Sign up here</a></p>
                </div>
              </div>

            </div>
          </div>

        </div>
      </div>
    </div>
    
  );

}
