import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../constants';
import '../App.css';

export default class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email: '',
            password: ''
        };
    }

    submit = (e) => {
        axios.post(BASE_URL+'/api/security', {
            email: this.state.email,
            password: this.state.password
        })
        .then(response => {
            if (response.status===200){
                this.props.login(response.data);
                this.props.history.push('/')
            }
        }).catch(error => {
            if (error.response) {
                alert(error.response.data);
            }
            else{
                alert(error + '. Probably problem with CORS on the server side.')
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
                        <div class="form-group">
                            <label for="formGroupExampleInput">E-mail</label>
                            <input type="text" className="form-control" placeholder="E-mail" value={this.state.email} onChange={this.loginOnChange}/>
                        </div>
                        <div class="form-group">
                            <label for="formGroupExampleInput2">Password</label>
                            <input type="password" className="form-control"  placeholder="Password" value={this.state.password} onChange={this.passwordOnChange}/>
                        </div>
                         <input type="submit" value="Login" onClick={this.submit} />
                    </form>
            </div>
        </div>
        )
    }
}