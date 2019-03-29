import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../constants';
import { connect } from 'react-redux';
import jwt_decode from 'jwt-decode'

class MainComposite extends Component {

    componentDidMount(){

    }
    
    render() {
        return (
            <div className="container">

            </div>
        );
    }
}
const mapStateToProps = state => ({
    token: state.auth.token
});

export default connect(mapStateToProps, null)(Main)
