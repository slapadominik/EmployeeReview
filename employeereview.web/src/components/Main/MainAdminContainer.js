import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL} from '../../constants';
import { connect } from 'react-redux';
import MainAdminView from './MainAdminView';
import { setUsers} from '../../actions/userActions';

class MainAdminContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            users: []
        };
    }

    componentDidMount(){
        if (this.props.user.role){
            if (this.props.user.role.includes("Administrator")){
                axios.get(BASE_URL+'/users')
                .then(response => {
                    if (response.status===200){
                        this.setState({users: response.data});
                        this.props.setUsers(response.data);
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
        }      
    }



    render() {
        return (
            <div className="container">
                {this.props.user.role.includes("Administrator") && <MainAdminView users={this.state.users}/> }
            </div>
        );
    }
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}
export default connect(mapStateToProps, { setUsers })(MainAdminContainer)
