import React, { Component } from 'react';
import { isUserLoggedIn } from './isUserLoggedIn';
import { Redirect } from 'react-router-dom';

export default function WithAuthorization(ComposedComponent){
    return class Authorization extends Component {
        render(){
            if (isUserLoggedIn()){
                return(
                    <ComposedComponent {...this.props} />
                )
            }
            return (
                <Redirect to="/login"/>
            );
        }
    }
}