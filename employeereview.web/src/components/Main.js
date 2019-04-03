import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../constants';
import { connect } from 'react-redux';

class Main extends Component {

    componentDidMount(){
        axios.get(BASE_URL+'/employees')
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

    render() {
        return (
            <div className="container">

            </div>
        );
    }
}



export default connect(null, null)(Main)
