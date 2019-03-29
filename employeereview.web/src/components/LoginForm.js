import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../constants';
import '../App.css';
import { login } from '../actions/auth';
import { connect } from 'react-redux';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email: '',
            password: ''
        };
    }

    submit = (e) => {
        e.preventDefault();
        axios.post(BASE_URL+'/api/security/login', {
            email: this.state.email,
            password: this.state.password
        })
        .then(response => {
            if (response.status===200){
                localStorage.setItem('jwtToken', response.data);
                console.log('Login successful');          
                this.props.history.push('/')
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

    passwordOnChange = (e) => {
        this.setState({password: e.target.value});
    }

    loginOnChange = (e) => {
        this.setState({email: e.target.value});
    }

    render() {
        return (
            <div className="container h-100">
                <div className="row h-100 justify-content-center align-items-center">
                    <form className="col-4">
                        <div className="form-group">
                            <label htmlFor="formGroupExampleInput">E-mail</label>
                            <input type="text" className="form-control" placeholder="E-mail" value={this.state.email} onChange={this.loginOnChange}/>
                        </div>
                        <div className="form-group">
                            <label htmlFor="formGroupExampleInput2">Password</label>
                            <input type="password" className="form-control"  placeholder="Password" value={this.state.password} onChange={this.passwordOnChange}/>
                        </div>
                         <input type="submit" value="Login" onClick={this.submit} />
                    </form>
            </div>
        </div>
        )
    }
}