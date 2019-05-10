import React, { Component } from 'react';
import { connect } from 'react-redux';
import axios from 'axios';
import { BASE_URL } from '../constants';
import { Textbox, Select } from 'react-inputs-validation';
import 'react-inputs-validation/lib/react-inputs-validation.min.css';

class RegisterForm extends Component {
    constructor(props){
        super(props);
        this.state = {
            email: '',
            password: '',
            repeatPassword: '',
            firstName: '',
            lastName: '',
            jobTitle: 0,
            jobTitles: []
        };
    }

    componentWillMount(){
        axios.get(`${BASE_URL}/jobTitles`)
        .then(resp => {
          this.setState({jobTitles: resp.data});
        }).catch(err => {
          console.log(err);
        })
    }

    onChange = (data,e) => {
        this.setState({[e.target.name]: data});
    }

    selectOnChange = (data, e) => {
        this.setState({jobTitle: data});
        console.log(data);
    }

    submit = e => {
        e.preventDefault();
        
        axios.post(`${BASE_URL}/security/register`,
          {
              email: this.state.email,
              password: this.state.password,
              firstName: this.state.firstName,
              lastName: this.state.lastName,
              titleId: this.state.jobTitle
          }
        ).then(resp => {
            this.props.history.push('/login');
        }).catch(err => {
            console.log(err);
        })
    }

    render() {
        return (
            <div className="container h-100">
                <div className="row h-100 justify-content-center align-items-center">
                    <form className="col-4">
                        <div className="mb-4 text-center">
                            <h3 className="display-3">Rejestracja</h3>
                        </div>
                        <div className="form-group">
                            <label htmlFor="formGroupExampleInput">Imię</label>
                            <Textbox id={'firstName'} type="text" name="firstName" placeholder="Imię" maxLength="15" value={this.state.firstName} onChange={this.onChange} onBlur={() => {}}
                                validationOption={{
                                    check: true, 
                                    required: true,
                                    msgOnError: 'Pole musi zawierać od 3 do 15 znaków.',
                                    min: 3,
                                    max: 15
                                }}/>
                        </div>
                        <div className="form-group">
                            <label htmlFor="formGroupExampleInput">Nazwisko</label>
                            <Textbox id={'lastName'} type="text" name="lastName" placeholder="Nazwisko" maxLength="25" value={this.state.lastName} onChange={this.onChange} onBlur={() => {}}
                                validationOption={{
                                    check: true, 
                                    required: true,
                                    msgOnError: 'Pole musi zawierać od 3 do 25 znaków.',
                                    min: 3,
                                    max: 25
                                }}/>
                        </div>
                        <div className="form-group">
                            <label htmlFor="jobTitle">Stanowisko pracy</label>
                            <Select id={'jobTitle'} name="jobTitle" optionList={this.state.jobTitles} value={this.state.jobTitle} onChange={this.selectOnChange} onBlur={() => {}}/>
                        </div>
                        <div className="form-group">
                            <label htmlFor="email">E-mail</label>
                            <Textbox id={'email'} type="text" name="email" placeholder="Email"  maxLength="40" value={this.state.email} onChange={this.onChange} onBlur={() => {}}
                                validationOption={{
                                    check: true, 
                                    required: true,
                                    msgOnError: 'Pole musi zawierać od 5 do 40 znaków.',
                                    min: 5,
                                    max: 40
                                }}/>
                        </div>
                        <div className="form-group">
                            <label htmlFor="formGroupExampleInput2">Hasło</label>
                            <Textbox id={'password'} type="password" name="password" placeholder="Hasło" maxLength="15" value={this.state.password} onChange={this.onChange} onBlur={() => {}}
                                validationOption={{
                                    check: true, 
                                    required: true,
                                    msgOnError: 'Pole musi zawierać od 5 do 20 znaków.',
                                    min: 5,
                                    max: 20
                                }}/>
                        </div>
                        <div className="form-group">
                            <label htmlFor="formGroupExampleInput2">Potwierdź hasło</label>
                            <Textbox id={'repeatPassword'} type="password" name="repeatPassword" placeholder="Potwierdź hasło" maxLength="15" value={this.state.repeatPassword} onChange={this.onChange} onBlur={() => {}}
                                validationOption={{
                                    check: true, 
                                    required: true,
                                    msgOnError: 'Pole musi zawierać od 5 do 20 znaków.',
                                    min: 5,
                                    max: 20
                                }}/>
                        </div>
                         <div className="float-right mt-3">
                             <input type="submit" value="Zarejestruj się" onClick={this.submit} className="btn btn-danger"/> 
                        </div>                                                                                          
                    </form>                         
            </div>
        </div>
        )
    }
}



export default connect(null, null)(RegisterForm)