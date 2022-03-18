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
  function onConfirmPasswordChange(newPassword) {
    setPassword(newPassword);

    if (newPassword === "" || confirmpassword === undefined) {
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
    if (onEmailChange(email) && onPasswordChange(password) && onConfirmPasswordChange(confirmpassword)) {
        
          navigatge("/category");
          window.location.reload();
     
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
                  <h1>Register</h1>
                </div>
              </div>
              <form action="" method="post" name="login">
                <div class="form-group">
                  <label for="exampleInputEmail1">Email address</label>
                  <input value={email} type="email" name="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter email"onChange={(e) => onEmailChange(e.target.value)} />
                {emailError && <div style={{ color: "red" }}>{emailError}</div>}
                </div>
                <div class="form-group">
                  <label for="exampleInputEmail1">Password</label>
                  <input value={password} type="password" name="password" id="password" class="form-control" aria-describedby="emailHelp" placeholder="Enter Password"onChange={(e) => onPasswordChange(e.target.value)} />
                {passwordError && <div style={{ color: "red" }}>{passwordError}</div>}
                </div>
                <div class="form-group">
                  <label for="exampleInputEmail1">Confirm Password</label>
                  <input value={confirmpassword} type="password" name="password" id="password" class="form-control" aria-describedby="emailHelp" placeholder="Enter Password"onChange={(e) => onConfirmPasswordChange(e.target.value)} />
                {passwordError && <div style={{ color: "red" }}>{passwordError}</div>}
                </div>
                <div class="col-md-12 text-center ">
                  <button type="submit" class=" btn btn-block mybtn btn-primary tx-tfm">Login</button>
                </div>
                
                <div class="col-md-12 mb-3">
                  <p class="text-center">
                    <a href="../login" class="google btn mybtn"><i class="fa-google-plus">
                    </i>Back to Login
                    </a>
                  </p>
                </div>
               
              </form>

            </div>
          </div>

        </div>
      </div>
    </div>
    
  );

}
