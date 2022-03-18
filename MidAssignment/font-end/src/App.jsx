
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
import 'bootstrap/dist/css/bootstrap.min.css';
import { Nav, Navbar, Container, NavbarBrand } from "react-bootstrap";
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
    <BrowserRouter >
      <Navbar bg="dark" variant="dark">
        <Container >
          <Navbar.Brand as={Link} to="/">Home</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link as={Link} to="/category">Category</Nav.Link>
            <Nav.Link as={Link} to="/request">Request</Nav.Link>
          </Nav>
          <Nav>
          {!token ? <Nav.Link as={Link} to="/login">Login</Nav.Link>
              : <Nav.Link onClick={onLogoutClicked}>Log out</Nav.Link>
            }
          </Nav>
        </Container>
      </Navbar>
      <Routes>
        <Route path="/" element={<HomePage />} />
        {/* <Route path="/posts" element={<PostPage />} />
        <Route path="/post/:id" element={<PostDetailPage />} />
        <Route path="/profile" element={<ProfilePage />} /> */}
        <Route path="/login" element={<LoginPage />} />
      </Routes>
    </BrowserRouter>
    
  );
}
