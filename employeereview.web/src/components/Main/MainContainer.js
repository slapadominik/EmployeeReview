import React, { Component } from 'react';
import { connect } from 'react-redux';
import { setUsers} from '../../actions/userActions';
import {ADMIN_ROLE, HR_ROLE, EMPLOYEE_ROLE, SUPERVISOR_ROLE} from '../../constants';
import MainAdminContainer from './MainAdminContainer';
import MainEmployeeContainer from './MainEmployeeContainer';
import MainSupervisorContainer from './MainSupervisorContainer';

class MainContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            isAdmin: false,
            isSupervisor: false,
            isHR: false,
            isEmployee: false
        };
    }

    componentDidMount(){
        if (this.props.isUserAuthenticated){
            if (this.props.user.role.includes(ADMIN_ROLE)){
                this.setState({isAdmin: true});
            }
            else if (this.props.user.role.includes(SUPERVISOR_ROLE)){
                this.setState({isSupervisor: true});
            }
            else if (this.props.user.role.includes(HR_ROLE)){
                this.setState({isHR: true});
            }
            else if (this.props.user.role.includes(EMPLOYEE_ROLE)){
                this.setState({isEmployee: true});
            }
        }      
    }



    render() {
        return (
            <div className="container-fluid">
                {this.state.isAdmin && <MainAdminContainer/> }
                {this.state.isSupervisor && <MainSupervisorContainer/> }
                {this.state.isEmployee && <MainEmployeeContainer/> }
            </div>
        );
    }
}

function mapStateToProps(state){
    return {
        user: state.auth.user,
        isUserAuthenticated: state.auth.isAuthenticated
    }
}
export default connect(mapStateToProps, { setUsers })(MainContainer)
