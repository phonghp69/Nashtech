import React from 'react';
import {
  BrowserRouter,
  Route,
  Routes,
  Link,
  useNavigate,
} from 'react-router-dom';

import HomePage from './pages/homePage/homepage';
import PostPage from './pages/postPage/postpage';
import ProfilePage from './pages/profilePage/profilepage';
import LoginPage from './pages/loginPage/loginpage';
import PostDetailPage from './pages/detailsPage/detailspage';

import './style.css';

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
        <Link style={{ marginRight: '10px' }} to="/posts">
          Posts
        </Link>
        <Link style={{ marginRight: '10px' }} to="/profile">
          Profile
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
        <Route path="/posts" element={<PostPage />} />
        <Route path="/post/:id" element={<PostDetailPage />} />
        <Route path="/profile" element={<ProfilePage />} />
        <Route path="/login" element={<LoginPage />} />
      </Routes>
    </BrowserRouter>
  );
}
