import React, { Component } from 'react';
import '../App.css';
import './Profile.css';
import user from '../images/user.png';
import { connect } from 'react-redux';
import { Textbox } from 'react-inputs-validation';
import 'react-inputs-validation/lib/react-inputs-validation.min.css';
import axios from 'axios'
import { BASE_URL } from '../constants';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class ProfileEditForm extends Component {
    constructor(props){
        super(props);
        this.state = {
            firstName:'',
            lastName: ''
        };
    }
    submit = e => {
        e.preventDefault();
        axios.put(BASE_URL+`/users/${this.props.user.jti}`, 
        {
            firstName: this.state.firstName,
            lastName: this.state.lastName
        })
        .then(resp => {
            this.props.history.goBack();
        })
        .catch(err =>{
            console.log(err);
        })
    }

    componentDidMount(){
        axios.get(BASE_URL+`/users/${this.props.user.jti}`)
        .then(response => {
            if (response.status===200){
                console.log(response.data)
                this.setState({firstName: response.data.firstName, lastName: response.data.lastName});
                console.log(this.state.roles);
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

    onChange = (data,e) => {
        this.setState({[e.target.name]: data});
    }

    returnBackOnClick = e => {
        this.props.history.goBack();
    }
    render() {
        return(
                <div className="container justify-content-center">
                    <FontAwesomeIcon icon="arrow-left" className="return-page" onClick={this.returnBackOnClick  }/>
                     <form>                    
                        <div className="row profile">
                            <div className="col-md-4 offset-md-4 text-center">
                                <h4 className="display-3">Edycja profilu</h4> 
                            </div>
                        </div>
                        <div className="row mt-4">
                            <div className="col-md-4 offset-md-4 text-center">
                                <img src={user} alt="user"/>
                            </div>                  
                        </div>
                        <div className="row mt-4">
                            <div className="col-md-4 offset-md-4 form-group"> 
                                <label htmlFor="formGroupExampleInput"><h4 className="display-4">Imię</h4></label>
                                <Textbox type="text" name="firstName" value={this.state.firstName} onChange={this.onChange}/>
                            </div>
                        </div>
                        <div className="row mt-2">
                            <div className="col-md-4 offset-md-4 form-group"> 
                                <label htmlFor="formGroupExampleInput"><h4 className="display-4">Nazwisko</h4></label>
                                <Textbox type="text" name="lastName" value={this.state.lastName} onChange={this.onChange}/>
                            </div>
                        </div>
                        <div className="row mt-3">
                            <div className="col-md-4 offset-md-4 text-center">
                                <input type="submit" value="Zapisz zmiany" className="btn btn-danger" onClick={this.submit}/>
                            </div>
                        </div>     
                    </form>       
                </div>
        )
    };
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}
export default connect(mapStateToProps, null)(ProfileEditForm)