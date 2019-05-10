import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export default function WithReviewReadPermission(ComposedComponent){
    return class extends Component {
        render(){
            if (isUserLoggedIn()){
                return(
                    <ComposedComponent {...this.props} />
                )
            }
        }
    }
}