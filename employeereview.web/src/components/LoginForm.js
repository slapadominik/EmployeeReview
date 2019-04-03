import React, { Component } from 'react';
import '../App.css';
import { connect } from 'react-redux';
import { login} from '../actions/authActions';

class Login extends Component {
    constructor(props){
        super(props);
        this.state = {
            email: '',
            password: ''
        };
    }

    submit = (e) => {
        e.preventDefault();
        this.props.login(this.state)
        .then(
            resp => {
                console.log(this.props)
                this.props.history.push('/')
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
                            <label htmlFor="formGroupExampleInput2">Hasło</label>
                            <input type="password" className="form-control"  placeholder="Hasło" value={this.state.password} onChange={this.passwordOnChange}/>
                        </div>
                         <input type="submit" value="Login" onClick={this.submit} className="btn btn-danger"/>                                                                                           
                    </form>                         
            </div>
        </div>
        )
    }
}

export default connect(null, { login })(Login)