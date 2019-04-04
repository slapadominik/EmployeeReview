import React, { Component } from 'react';
import { BrowserRouter } from 'react-router-dom';
import Navbar from './components/Navbar';
import { Route } from 'react-router-dom';
import LoginForm from './components/LoginForm';
import './components/Navbar.css';
import Logout from './components/Logout';
import Main from './components/Main';
import Profile from './components/Profile';
import RegisterForm from './components/RegisterForm';
import ProfileEditForm from './components/ProfileEditForm';


class App extends Component {
    render(){
        return (
        <BrowserRouter>
            <Navbar/>
            <Route exact path="/" component={Main} />
            <Route exact path="/login" component={LoginForm} />
            <Route exact path="/logout" component={Logout} />
            <Route exact path="/profile" component={Profile} />
            <Route exact path="/register" component={RegisterForm} />
            <Route exact path="/profile/edit" component={ProfileEditForm} />
        </BrowserRouter>);
    }
}

export default App;