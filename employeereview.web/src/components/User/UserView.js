import React, { Component } from 'react';
import user from '../../images/user-small.png';
import { withRouter } from 'react-router-dom';

class UserView extends Component {

    openUserDetails = (id) => {
        this.props.history.push(`/user/${id}`);
    }

    render(){
        return(
            <div className="card mt-4 mr-2" onClick={() => this.openUserDetails(this.props.id)}>
                <img className="card-img-top" src={user} alt="User"/>
                <div className="card-body">
                    <h5 className="card-title">{this.props.firstName} {this.props.lastName}</h5>
                </div>
            </div>
        )
    }
}
export default withRouter(UserView);