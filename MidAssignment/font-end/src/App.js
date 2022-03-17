
import React from 'react';
import {
  BrowserRouter,
  Route,
  Routes,
  Link,
  useNavigate,
} from 'react-router-dom';

import HomePage from './page/homepage';
import LoginPage from './page/loginpage';

import './style.css';
<link href="../../dist/css/bootstrap.min.css" rel="stylesheet"></link>
export default function App() {
  const token = localStorage.getItem('token');

  function onLogoutClicked() {
    localStorage.setItem('token', '');
    localStorage.setItem('userId', '');
    window.location.reload();
  }

  return (
    
    <BrowserRouter>
      <div>
        <Link style={{ marginRight: '10px' }} to="/">
          Home
        </Link>
        <Link style={{ marginRight: '10px' }} to="/category">
          Category
        </Link>
        <Link style={{ marginRight: '10px' }} to="/request">
          Request
        </Link>
        {!token ? (
          <Link style={{ marginRight: '10px' }} to="/login">
            Login
          </Link>
        ) : (
          <button onClick={onLogoutClicked} style={{ marginRight: '10px' }}>
            Logout
          </button>
        )}
      </div>
      <Routes>
        <Route path="/" element={<HomePage />} />
       
        <Route path="/login" element={<LoginPage />} />
      </Routes>
    </BrowserRouter>
  );
}
