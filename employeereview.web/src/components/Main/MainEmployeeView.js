import React, { Component } from 'react';
import UserView from '../User/UserView';

export default class MainEmployeeView extends Component {
    constructor(props){
        super(props)
        console.log(props)
    }
    mapUsersToViews = () => {
        return this.props.users.map((x, i) => <UserView key={i} id={x.id} firstName={x.firstName} lastName={x.lastName} title={x.jobTitle}/>)
    }

    render(){
        return (
        <div className="container-fluid">
            <div className="row justify-content-md-center">
                <div className="col-md-auto mt-5">
                    <h3 className="display-3">Zespół</h3>
                </div>
            </div>
            <div className="row">
            {this.mapUsersToViews()}
            </div>
        </div>
        );
    }
}