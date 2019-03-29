import React, { Component } from 'react';
import './Navbar.css';
import { Link } from 'react-router-dom';
import { logout } from '../actions/auth';
import { connect } from 'react-redux';

class Navbar extends Component {
    logout = (e) => {
        localStorage.removeItem('jwtToken');
        this.props.logout();
    }

    render() {    
        return (
                <nav className="navbar navbar-dark">
                    <a className="navbar-brand" href="/">System oceny pracowników</a>
                    <ul className="nav">
                            {this.props.token === null && <li className="nav-item">
                                <Link to="/login" className="nav-link">Zaloguj się</Link>
                            </li>}
                            {this.props.token !== null && <li className="nav-item">
                                <Link to="/profile" className="nav-link">Profil</Link>
                            </li>}
                            {this.props.token !== null && <li className="nav-item" onClick={this.logout}>
                                <Link to="/logout" className="nav-link">Wyloguj się</Link>
                            </li>}
                    </ul>
                </nav>
        )
    }
}

const mapStateToProps = state => ({
    token: state.auth.token
});

export default connect(mapStateToProps, { logout })(Navbar)
