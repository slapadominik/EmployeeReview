import React, { Component } from 'react';
import { connect } from 'react-redux';
import axios from 'axios';
import {BASE_URL} from '../constants';
import './Profile.css';
import user from '../images/user.png';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class Profile extends Component {
    constructor(props){
        super(props);
        this.state = {
            firstName: '',
            lastName: '',
            roles: []
        };
    }
    componentDidMount(){
        axios.get(BASE_URL+`/users/${this.props.user.jti}`)
        .then(response => {
            if (response.status===200){
                console.log(response.data)
                this.setState({firstName: response.data.firstName, lastName: response.data.lastName, roles: response.data.roles});
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

    editOnClick = e => {
        this.props.history.push('/profile/edit');
    }

    mapRoles = () => {
        return this.state.roles.map((x,i) => <li className="badge badge-primary mr-2 text-center" key={i}><h6>{x.name}</h6></li>)
    }

    returnBackOnClick = e => {
        this.props.history.goBack();
    }

    render() {
        return (
            <div className="container justify-content-center">
                 <FontAwesomeIcon icon="arrow-left" className="return-page" onClick={this.returnBackOnClick  }/>
                <div className="row profile">
                    <div className="col-md-4 offset-md-4 text-center">
                        <h4 className="display-3">Twój profil</h4> 
                    </div>
                </div>
                <div className="row mt-4">
                    <div className="col-md-4 offset-md-4 text-center">
                        <img src={user} alt="user"/>
                    </div>                  
                </div>
                <div className="row mt-4">
                    <div className="col-md-4 offset-md-4 text-center">
                        <h4 className="display-3">{this.state.firstName} {this.state.lastName}</h4> 
                    </div>
                </div> 
                <div className="row mt-3">    
                    <div className="col-md-4 offset-md-4 text-center">  
                        <ul className="wtf">
                            {this.mapRoles()}
                        </ul> 
                    </div>                
                </div>
                <div className="row mt-2">
                    <div className="col-md-4 offset-md-4 text-center">
                        <h4 className="display-4">Email: {this.props.user.email}</h4> 
                    </div>
                </div> 
                <div className="row mt-5">
                    <div className="col-md-4 offset-md-4 text-center">
                        <button className="btn btn-danger" onClick={this.editOnClick}><FontAwesomeIcon icon="pen"/> Edytuj profil</button>
                    </div>
                </div>              
            </div>
        );
    }
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}
export default connect(mapStateToProps, null)(Profile)
