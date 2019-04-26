import React, { Component } from 'react';
import { connect } from 'react-redux';
import UserDetailView from './UserDetailView';

class UserDetailContainer extends Component {
    componentDidMount(){
        console.log(this.props)
    }
    render(){
        return(
            <div>
                <UserDetailView firstName={this.props.user.firstName} lastName={this.props.user.lastName} roles={this.props.user.roles}/>
            </div>
        );
    }
}

function mapStateToProps(state, ownProps){

    return {
        user: state.users.users.find(x => x.id === ownProps.match.params.id)
    }
}
export default connect(mapStateToProps, null)(UserDetailContainer)