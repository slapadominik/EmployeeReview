import React, { Component } from 'react';
import { connect } from 'react-redux';
import { EMPLOYEE_ROLE } from '../../constants';
import MainEmployeeView from './MainEmployeeView';
import axios from 'axios';
import { BASE_URL } from '../../constants';

class MainEmployeeContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            user: null,
            users: null
        };
    }

    componentDidMount(){
        axios.get(BASE_URL+`/users/${this.props.user.jti}`)
            .then(response => {
                if (response.status===200){
                    this.setState({user: response.data});
                    if (response.data.team){
                        console.log(response.data.team)
                        axios.get(BASE_URL+`/teams/${response.data.team.id}/users`)
                        .then(response2 => {
                            if (response2.status===200){
                                console.log(response2)
                                this.setState({users: response2.data});
                            }
                        }).catch(error => {
                            if (error.response2) {
                                alert('Unauthorized');
                            }
                            else{
                                console.log(error);
                            }
                        });
                    }
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

    render() {
        return (
            <div className="container-fluid">
                {this.state.users && <MainEmployeeView users={this.state.users}/>}
            </div>
        );
    }
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}

export default connect(mapStateToProps, null)(MainEmployeeContainer)
