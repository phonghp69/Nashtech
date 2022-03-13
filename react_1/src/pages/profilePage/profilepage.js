import React, { useEffect, useState } from 'react';
import LoginPage from '../loginPage/loginpage';

export default function HomePage() {
  const [userInfo, setUserInfo] = useState();
  const token = localStorage.getItem('token');
  const userId = localStorage.getItem('userId');

  useEffect(() => {
    if (token && userId) {
      fetch(`https://60dff0ba6b689e001788c858.mockapi.io/users/${userId}`, {
        method: 'GET',
        headers: {
          Authorization: token,
        },
      })
        .then(function (response) {
          return response.json();
        })
        .then(function (json) {
          setUserInfo(json);
        });
    }
  }, [token, userId]);

  return token ? (
    <div>
      <h3>Profile </h3>
      Name: {userInfo?.name}<br />
      User ID: {userInfo?.id}
    </div>
  ) : (
    <div>
      <b style={ { color: 'red' }}>You need to login to continue</b>
      
      <LoginPage />
    </div>
  );
}
