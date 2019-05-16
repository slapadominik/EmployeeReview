import React, { Component } from 'react';
import './Navbar.css';
import { Link } from 'react-router-dom';
import { logout } from '../actions/authActions';
import { connect } from 'react-redux';
import PropTypes from "prop-types";

class Navbar extends Component {

    logout = e => {
        e.preventDefault();
        this.props.logout();
    };

    render() {    
        return (
                <nav className="navbar navbar-dark">
                    <Link to="/" className="navbar-brand display-4">System oceny pracowników</Link>
                    <ul className="nav">
                            {!this.props.auth.isAuthenticated && <li className="nav-item">
                                <Link to="/login" className="nav-link">Zaloguj się</Link>
                            </li>}
                            {this.props.auth.isAuthenticated && <li className="nav-item">
                                <Link to="/profile" className="nav-link">Profil</Link>
                            </li>}
                            {this.props.auth.isAuthenticated && <li className="nav-item" onClick={this.logout}>
                                <Link to="/logout" className="nav-link">Wyloguj się</Link>
                            </li>}
                    </ul>
                </nav>
        )
    }
}


Navbar.propTypes = {
  auth: PropTypes.object.isRequired,
  logout: PropTypes.func.isRequired
};

function mapStateToProps(state) {
  return {
    auth: state.auth
  };
};

export default connect(mapStateToProps, { logout })(Navbar)
