import React, { Component } from 'react';
import { connect } from 'react-redux';
import 'react-inputs-validation/lib/react-inputs-validation.min.css';
import axios from 'axios'
import { BASE_URL } from '../../../constants';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

class EditRoleForm extends Component {
    constructor(props){
        super(props);
        this.state = {
            roles: []
        };
    }

    componentDidMount(){
        axios.get(BASE_URL+`/roles`)
        .then(response => {
            if (response.status===200){
                this.setState({roles: response.data})
            }
        }).catch(error => {
            if (error.response) {
                alert('Unauthorized');
            }
            else{
                console.log(error);
            }
        });
    }

    
    submit = e => {
        e.preventDefault();
        axios.get(BASE_URL+`/users/${this.props.user.jti}`)
        .then(resp => {
            this.setState({
                roles: resp.data
            })
        })
        .catch(err =>{
            console.log(err);
        })
    }

    onChange = (data,e) => {
        this.setState({[e.target.name]: data});
    }

    returnBackOnClick = e => {
        this.props.history.goBack();
    }
    render() {
        return(
                <div className="container justify-content-center">
                    <FontAwesomeIcon icon="arrow-left" className="return-page" onClick={this.returnBackOnClick  }/>
                     <form>           
                                    
                           <button>Zapisz</button>
                    </form>       
                </div>
        )
    };
}

function mapStateToProps(state){
    return {
        user: state.auth.user
    }
}
export default connect(mapStateToProps, null)(EditRoleForm)