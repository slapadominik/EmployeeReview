import React, { Component } from 'react';
import './Navbar.css';
import { Link } from 'react-router-dom';
import { isUserLoggedIn } from '../helpers/authorization';


export default class Navbar extends Component {
    logout = () => {
        localStorage.setItem('jwtToken', null);
    }

    render() {
        return (
            <div>
                <nav className="navbar navbar-dark">
                    <a className="navbar-brand" href="/">System oceny pracowników</a>
                    <ul className="nav navbar-nav">
                        {isUserLoggedIn() && <li className="nav-item" onClick={this.logout}>
                            <Link to="/logout" className="nav-link">Logout</Link>
                        </li>}

                    </ul>
                </nav>
            </div>
        )
    }
}
