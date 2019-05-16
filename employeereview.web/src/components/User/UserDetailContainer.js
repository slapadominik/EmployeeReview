import React, { Component } from 'react';
import UserDetailView from './UserDetailView';
import axios from 'axios'
import { BASE_URL } from '../../constants';
import { connect } from 'react-redux';

class UserDetailContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            user: null
        };
    }
    componentDidMount(){
        axios.get(BASE_URL+`/users/${this.props.match.params.id}`)
        .then(response => {
            if (response.status===200){
                console.log(response.data)
                this.setState({user: response.data})
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
                {this.state.user && <UserDetailView loggedUser={this.props.user} id={this.state.user.id} firstName={this.state.user.firstName} lastName={this.state.user.lastName} title={this.state.user.jobTitle} roles={this.state.user.roles} supervisor={this.state.user.supervisor}/>}
            </div>
        );
    }
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}
export default connect(mapStateToProps, null)(UserDetailContainer)