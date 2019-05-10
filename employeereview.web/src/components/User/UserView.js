import React, { Component } from 'react';
import user from '../../images/user-male.png';
import { withRouter } from 'react-router-dom';
import './UserView.css';

class UserView extends Component {

    openUserDetails = (id) => {
        this.props.history.push(`/user/${id}`);
    }

    render(){
        return(
            <div className="col-lg-3 d-flex align-items-stretch">
            <div className="card mt-4" onClick={() => this.openUserDetails(this.props.id)}>
                <img className="card-img-top w-75 mx-auto align-items-stretch" src={user} alt="User"/>
                <div className="card-body">
                    <h5 className="card-title text-center">{this.props.firstName} {this.props.lastName}</h5>
                    <p className="text-center">{this.props.title}</p>
                </div>
            </div>
            </div>
        )
    }
}
export default withRouter(UserView);