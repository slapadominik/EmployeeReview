import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../constants';
import { connect } from 'react-redux';
import jwt_decode from 'jwt-decode'

class Main extends Component {

    componentDidMount(){
        var decoded = jwt_decode(this.props.token);
        if (decoded.role==='Administrator'){
            axios.get(BASE_URL+'/api/employees', { headers: {"Authorization" : `Bearer ${this.props.token}`}})
        .then(response => {
            if (response.status===200){
                console.log(response.data);
            }
        }).catch(error => {
            if (error.response) {
                alert('Unauthorized');
            }
            else{
                console.log(error);
            }
        });
        }
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
