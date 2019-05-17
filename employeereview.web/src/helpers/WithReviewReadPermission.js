import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';
import { isUserLoggedIn } from './isUserLoggedIn';

export default function WithReviewReadPermission(ComposedComponent){
    return class extends Component {
        render(){
            if (isUserAdmin()){
                return(
                    <ComposedComponent {...this.props} />
                )
            }
        }
    }
}