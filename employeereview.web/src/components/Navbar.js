import React, { Component } from 'react';
import './Navbar.css';

export default class Navbar extends Component {
    render() {
        return (
            <div>
                <nav className="navbar navbar-dark">
                    <a className="navbar-brand" href="/">System oceny pracowników</a>
                </nav>
            </div>
        )
    }
}