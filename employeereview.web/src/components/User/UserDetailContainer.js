import React, { Component } from 'react';
import UserDetailView from './UserDetailView';
import axios from 'axios'
import { BASE_URL } from '../../constants';

class UserDetailContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            user: null
        };
    }
    componentWillMount(){
        axios.get(BASE_URL+`/users/${this.props.match.params.id}`)
        .then(response => {
            if (response.status===200){
                this.setState({user: response.data})
                console.log(response.data)
            }
        }).catch(error => {
            if (error.response) {
                alert(error.response);
            }
            else{
                console.log(error);
            }
        });
    }

    render(){
        return(
            <div>
                {this.state.user && <UserDetailView id={this.state.user.id} firstName={this.state.user.firstName} lastName={this.state.user.lastName} title={this.state.user.title} roles={this.state.user.roles}/>}
            </div>
        );
    }
}

export default UserDetailContainer;