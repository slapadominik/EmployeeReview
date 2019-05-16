import React, { Component } from 'react';
import { connect } from 'react-redux';
import axios from 'axios'
import { BASE_URL } from '../../../constants';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import '../../../App.css';
import {Form, Button} from 'react-bootstrap';


class EditRoleForm extends Component {
    constructor(props){
        super(props);
        this.state = {
            allRoles: [],
            userRoles: [],
            rolesAfterEdit: []  
        };
    }

    componentDidMount(){
        console.log(this.props);
        axios.get(BASE_URL+`/roles`)
        .then(response => {
            if (response.status===200){
                this.setState({allRoles: response.data})
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
        axios.put(BASE_URL+`/users/${this.props.match.params.id}/roles`, this.state.rolesAfterEdit.filter(x => x.checked === true))
        .then(resp => {
            this.props.history.push('/');
        })
        .catch(err =>{
            console.log(err);
        })
    }

    returnBackOnClick = e => {
        this.props.history.goBack();
    }

    handleCheckboxChange = event => {
        const target = event.target
        const checked = target.checked
        const name = target.name
        this.setState({
            rolesAfterEdit: [...this.state.rolesAfterEdit, {name: name, checked: checked}]
        });
      }
    
    render() {
        return(
            <div className="container h-50">
                <FontAwesomeIcon icon="arrow-left" className="return-page" onClick={this.returnBackOnClick  }/>
                 <div className="row h-100 justify-content-center align-items-center">
                    <Form>
                    <div className="mb-4 text-center">
                            <h3 className="display-3">Edycja ról użytkownika</h3>
                        </div>
                    <div key={`custom-inline-checkbox`} className="col-md-12 text-center">
                        {this.state.allRoles.map((role, key) => (
                            <Form.Check
                            key={key}
                            custom
                            inline
                            name={role.name}
                            onChange={this.handleCheckboxChange}
                            label={role.name}
                            type="checkbox"
                            id={`custom-inline-${role.name}`}
                        />
                        ))}
                        </div>
                        <div className="row">
                            <div className="col-md-4 offset-md-4 mt-4 text-center">
                                <Button variant="danger" type="submit" onClick={this.submit}>
                                    Zapisz
                                </Button>
                            </div>
                        </div>
                    </Form>                       
                </div>
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