import React, { Component } from 'react';
import { BrowserRouter } from 'react-router-dom';
import Navbar from './components/Navbar';
import { Route } from 'react-router-dom';
import LoginForm from './components/LoginForm';
import './components/Navbar.css';
import Logout from './components/Logout';
import MainContainer from './components/Main/MainContainer';
import Profile from './components/Profile';
import RegisterForm from './components/RegisterForm';
import ProfileEditForm from './components/ProfileEditForm';
import UserDetailContainer from './components/User/UserDetailContainer';
import WithAuthorization from './helpers/WithAuthorization';
import EditRoleForm from './components/User/Roles/EditRoleForm';

class Routing extends Component {
    render(){
        return (
        <BrowserRouter>
            <Navbar/>
            <Route exact path="/" component={WithAuthorization(MainContainer)} />
            <Route exact path="/login" component={LoginForm} />
            <Route exact path="/logout" component={Logout} />
            <Route exact path="/profile" component={Profile} />
            <Route exact path="/register" component={RegisterForm} />
            <Route exact path="/profile/edit" component={ProfileEditForm} />
            <Route exact path="/user/:id" component={UserDetailContainer} />
            <Route exact path="/user/:id/roles" component={EditRoleForm} />
        </BrowserRouter>);
    }
}

export default Routing;