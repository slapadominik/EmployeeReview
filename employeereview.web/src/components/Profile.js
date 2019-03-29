import React, { Component } from 'react';
import { connect } from 'react-redux';
import jwt_decode from 'jwt-decode'

class Profile extends Component {
    constructor(props){
        super(props);
        this.state = {
            firstName: '',
            lastName: '',
            roles: []
        };
    }
    componentDidMount(){
        const decodedToken = jwt_decode(this.props.token);
        console.log(decodedToken);
    }  
    render() {
        return (
            <div className="container">
                <p>{this.state.firstName}</p>
                <p>{this.state.lastName}</p>                
            </div>
        );
    }
}
const mapStateToProps = state => ({
    token: state.auth.token
});

export default connect(mapStateToProps, null)(Profile)
