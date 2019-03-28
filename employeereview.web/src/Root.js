import React from 'react';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import Navbar from './components/Navbar';
import { Route } from 'react-router-dom';
import LoginForm from './components/LoginForm';
import './components/Navbar.css';

const Root = ({ store }) => (
    <Provider store={store}>
        <BrowserRouter>
            <Navbar />
            <Route exact path="/" component={LoginForm} />
        </BrowserRouter>
    </Provider>
)

export default Root;