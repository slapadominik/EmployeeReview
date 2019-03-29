import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../constants';

export default class Main extends Component {

    componentDidMount(){
        axios.get(BASE_URL+'/api/employees')
        .then(response => {
            if (response.status===200){
                console.log(response.data);
            }
        }).catch(error => {
            if (error.response) {
                alert(error.response.data);
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
