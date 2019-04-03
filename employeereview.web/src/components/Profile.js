import React, { Component } from 'react';
import { connect } from 'react-redux';
import axios from 'axios';
import {BASE_URL} from '../constants';
import './Profile.css';

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
        axios.get(BASE_URL+`/employees/${this.props.user.jti}`)
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

    mapRoles = () => {
        return this.state.roles.map((x,i) => <li key={i}><h4>{x.name}</h4></li>)
    }
    render() {
        return (
            <div className="container profile">
                <div className="row justify-content-center align-items-center">
                    <h4>Imię: {this.state.firstName}</h4>
                </div>
                <div className="row justify-content-center align-items-center">
                    <h4>Nazwisko: {this.state.lastName}</h4>
                </div>
                <div className="row justify-content-center align-items-center">                    
                    <h4>Role</h4>
                </div>    
                <div className="row justify-content-center align-items-center">                    
                    <ul>
                        {this.mapRoles()}
                    </ul> 
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
