import React from 'react';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import Navbar from './components/Navbar';
import { Route } from 'react-router-dom';
import LoginForm from './components/LoginForm';
import './components/Navbar.css';
import Logout from './components/Logout';
import Main from './components/Main';
import WithAuthorization from './helpers/WithAuthorization';
import Profile from './components/Profile';
const Root = ({ store }) => (
    <Provider store={store}>
        <BrowserRouter>
            <Navbar/>
            <Route exact path="/" component={WithAuthorization(Main)} />
            <Route exact path="/login" component={LoginForm} />
            <Route exact path="/logout" component={Logout} />
            <Route exact path="/profile" component={Profile} />
        </BrowserRouter>
    </Provider>
)

export default Root;