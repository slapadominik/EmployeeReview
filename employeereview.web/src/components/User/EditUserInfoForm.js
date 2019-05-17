import React, {Component} from 'react';
import 'react-inputs-validation/lib/react-inputs-validation.min.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { withRouter } from 'react-router-dom'; 
import {BASE_URL} from '../../constants';
import axios from 'axios';
import {Form, Row, Col, Button} from 'react-bootstrap';

class EditUserInfoForm extends Component { 
    constructor(props){
        super(props);
        this.state = {
            jobTitleId: '',
            supervisorId: '',
            jobTitles:[],
            supervisors:[]
        }
    }
    returnBackOnClick = e => {
        this.props.history.goBack();
    }

    componentDidMount(){
        axios.get(`${BASE_URL}/users/${this.props.match.params.id}`)
        .then(resp => {
          this.setState({firstName: resp.data.firstName, jobTitleId: resp.data.jobTitle.id, lastName: resp.data.lastName, supervisorId: resp.data.supervisor.userId});
        }).catch(err => {
          console.log(err);
        })

        axios.get(`${BASE_URL}/users?role=Supervisor`)
        .then(resp => {      
          this.setState({supervisors:resp.data });
        }).catch(err => {
          console.log(err);
        })

        axios.get(`${BASE_URL}/jobTitles`)
        .then(resp => {
          this.setState({jobTitles: resp.data});
        }).catch(err => {
          console.log(err);
        })
    }

    selectOnChange = (e) => {
        this.setState({[e.target.name]: e.target.value});
    }

    submit = e => {
        e.preventDefault();
        axios.patch(BASE_URL+`/users/${this.props.match.params.id}/jobInformation`,
        {
            jobTitleId: this.state.jobTitleId,
            supervisorId: this.state.supervisorId
        })
        .then(resp => {
            this.props.history.goBack();
        })
        .catch(err =>{
            console.log(err);
        })
    }

    render(){
        return(
            <div className="container h-25">
                <FontAwesomeIcon icon="arrow-left" className="return-page" onClick={this.returnBackOnClick  }/>
                    <Form >
                        <div className="mb-4 text-center">
                            <h3 className="display-3">Edycja profilu</h3>
                        </div>
                        <Row className="justify-content-md-center">
                            <Col md={6}>
                                <Form.Group controlId="exampleForm.ControlSelect1">
                                    <Form.Label>Stanowisko pracy</Form.Label>
                                    <Form.Control name="jobTitleId"  as="select" value={this.state.jobTitleId} onChange={this.selectOnChange}>
                                        {this.state.jobTitles.map((x,key) => <option key={key} value={x.id}>{x.name}</option>)}
                                    </Form.Control>
                                </Form.Group>
                            </Col>
                        </Row>    
                        <Row className="justify-content-md-center">
                            <Col md={6}>
                                <Form.Group controlId="exampleForm.ControlSelect1">
                                    <Form.Label>Przełożony</Form.Label>
                                    <Form.Control name="supervisorId" as="select" value={this.state.supervisorId} onChange={this.selectOnChange}>
                                        {this.state.supervisors.map((x,key) => <option key={key} value={x.id}>{x.firstName+' '+x.lastName}</option>)}
                                    </Form.Control>
                                </Form.Group>
                            </Col>
                        </Row>          
                        <Row className="justify-content-md-center">
                            <Col md={6}>
                                <Button className="pull-right" variant="danger" type="submit" onClick={this.submit}>
                                    Zapisz
                                </Button>                            
                            </Col>
                        </Row>       
                    </Form>                       
            </div>
        );
    }
}

export default withRouter(EditUserInfoForm);