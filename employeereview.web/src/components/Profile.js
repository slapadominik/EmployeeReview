import React, { Component } from 'react';
import { connect } from 'react-redux';
import axios from 'axios';
import {BASE_URL} from '../constants';
import './Profile.css';
import user from '../images/user.png';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ReviewsContainer from './Reviews/ReviewsContainer';
import { EMPLOYEE_ROLE } from '../constants'
class Profile extends Component {
    constructor(props){
        super(props);
        this.state = {
            firstName: '',
            lastName: '',
            roles: [],
            jobTitle : '',
            supervisor: '',
            team: ''
        };
    }
    componentDidMount(){
        axios.get(BASE_URL+`/users/${this.props.user.jti}`)
        .then(response => {
            if (response.status===200){
                console.log(response.data);
                this.setState({
                    firstName: response.data.firstName, 
                    lastName: response.data.lastName, 
                    roles: response.data.roles, 
                    jobTitle: response.data.jobTitle, 
                    supervisor: response.data.supervisor,
                    team: response.data.team
                });
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
                <div className="row mt-2">
                    <div className="col-md-8 offset-md-2 text-center">
                        <p className="display-4">{this.state.jobTitle.name}</p>
                    </div>
                </div> 
                <div className="row">
                    <div className="col-md-8 offset-md-2 text-center">
                        <p className="display-4">Przełożony: {this.state.supervisor ? this.state.supervisor.firstName+' '+this.state.supervisor.lastName : "Brak"}</p>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-8 offset-md-2 text-center">
                        <p className="display-4">Zespół: {this.state.team ? this.state.team.name : "Brak"}</p>
                    </div>
                </div>
                <div className="row mt-1">
                    <div className="col-md-4 offset-md-4 text-center">
                        <h5 className="display-4">Email: {this.props.user.email}</h5> 
                    </div>
                </div> 
                <div className="row mt-2">
                    <div className="col-md-4 offset-md-4 text-center">
                        <button className="btn btn-danger" onClick={this.editOnClick}><FontAwesomeIcon icon="pen"/> Edytuj profil</button>
                    </div>
                </div>
                {this.props.user.role.includes(EMPLOYEE_ROLE) && <div className="row mt-2">
                    <div className="col-md-8 offset-md-2 text-center">
                        <h5 className="display-4">Opinie</h5>
                    </div>
                </div>}
                {this.props.user.role.includes(EMPLOYEE_ROLE) && <div className="col-md-6 offset-md-3">
                    <ReviewsContainer userId={this.props.user.jti} />   
                </div>}                   
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
