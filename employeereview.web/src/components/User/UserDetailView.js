import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import user from '../../images/user.png';
import { withRouter } from 'react-router-dom';  
import ReviewsContainer from '../Reviews/ReviewsContainer';

class UserDetailView extends Component {
    
    mapRoles = () => {
        return this.props.roles.map((x,i) => <li className="badge badge-primary mr-2 text-center" key={i}><h6>{x.name}</h6></li>)
    }

    returnBackOnClick = e => {
        this.props.history.goBack();
    }

    editRolesOnClick = e => {
        this.props.history.push(`/user/${this.props.id}/roles`);
    }

    addReviewOnClick = e => {
        this.props.history.push(`/user/${this.props.id}/addReview`);
    }

    render(){
        return(
            <div className="container justify-content-center">
                 <FontAwesomeIcon icon="arrow-left" className="return-page" onClick={this.returnBackOnClick  }/>
                <div className="row profile">
                    <div className="col-md-4 offset-md-4 text-center">
                        <h4 className="display-3">Profil użytkownika</h4> 
                    </div>
                </div>
                <div className="row mt-4">
                    <div className="col-md-4 offset-md-4 text-center">
                        <img src={user} alt="user"/>
                    </div>                  
                </div>
                <div className="row mt-4">
                    <div className="col-md-4 offset-md-4 text-center">
                        <h4 className="display-3">{this.props.firstName} {this.props.lastName}</h4> 
                    </div>
                </div> 
                <div className="row mt-2">
                    <div className="col-md-8 offset-md-2 text-center">
                        <h5>{this.props.title}</h5>
                    </div>
                </div> 
                <div className="row mt-3">    
                    <div className="col-md-4 offset-md-4 text-center">  
                        <ul className="wtf">
                            {this.mapRoles()}
                        </ul> 
                    </div>                
                </div>
                <div className="row mt-2">
                    <div className="col-md-8 offset-md-2 text-center">
                        <button className="btn btn-danger mr-2" onClick={this.editRolesOnClick}><FontAwesomeIcon icon="pen"/>Zarządzaj rolami</button>
                        <button className="btn btn-danger" onClick={this.addReviewOnClick}><FontAwesomeIcon icon="pen"/> Dodaj opinie</button>
                    </div>
                </div>
                <div className="row mt-4">
                    <div className="col-md-8 offset-md-2 text-center">
                        <h5>Opinie</h5>
                    </div>
                </div>
                <div className="col-md-6 offset-md-3">
                <ReviewsContainer userId={this.props.id} />   
                </div>         
            </div>
        );
    }
}

export default withRouter(UserDetailView);