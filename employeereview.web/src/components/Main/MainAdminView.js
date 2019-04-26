import React, { Component } from 'react';
import UserView from '../User/UserView';

export default class MainContainer extends Component {

    mapUsersToViews = () => {
        return this.props.users.map((x, i) => <UserView key={i} id={x.id} firstName={x.firstName} lastName={x.lastName}/>)
    }

    render(){
        return (
        <div>
            <div className="row justify-content-md-center">
                <div className="col-md-auto">
                    <h3>Użytkownicy</h3>
                </div>
            </div>
            <div className="row">
            {this.mapUsersToViews()}
            </div>
        </div>
        );
    }
}