import React from 'react';
import user from '../../images/user-male.png';
import { withRouter } from 'react-router-dom';
import './UserView.css';

const UserView = (props) => {

    const openUserDetails = (id) => {
        props.history.push(`/user/${id}`);
    }

        return(
            <div className="col-xs-4 col-sm-4 col-md-3 col-lg-2">
            <div className="card h-100 mt-4 text-center" onClick={() => openUserDetails(props.id)}>
                <img className="card-img-top mx-auto align-items-stretch" src={user} alt="User"/>
                <div className="card-body">
                    <h5 className="card-title">{props.firstName} {props.lastName}</h5>
                    <p className="text-center">{props.title.name}</p>
                </div>
            </div>
            </div>
        )
}
export default withRouter(UserView);