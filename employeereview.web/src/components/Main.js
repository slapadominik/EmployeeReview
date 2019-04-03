import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../constants';
import { connect } from 'react-redux';

class Main extends Component {
    componentDidMount(){
        console.log(this.props.user)
        if (this.props.user.role==="Administrator"){
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
       
    }

    render() {
        return (
            <div className="container">

            </div>
        );
    }
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}
export default connect(mapStateToProps, null)(Main)
