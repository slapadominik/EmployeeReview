import React, { Component } from 'react';
import axios from 'axios';
import {BASE_URL, SUPERVISOR_ROLE} from '../../constants';
import { connect } from 'react-redux';
import MainSupervisorView from './MainSupervisorView';
import { setUsers} from '../../actions/userActions';

class MainSupervisorContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            users: []
        };
    }

    componentDidMount(){
        console.log(this.props.user)
        if (this.props.user.role){
            if (this.props.user.role.includes(SUPERVISOR_ROLE)){
                axios.get(BASE_URL+`/users?supervisorId=${this.props.user.jti}`)
                .then(response => {
                    if (response.status===200){
                        console.log(response.data)
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
            <div className="container-fluid">
                {this.props.user.role.includes(SUPERVISOR_ROLE) && <MainSupervisorView users={this.state.users}/> }
            </div>
        );
    }
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}
export default connect(mapStateToProps, { setUsers })(MainSupervisorContainer)
