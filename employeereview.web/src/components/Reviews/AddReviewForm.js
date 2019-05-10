import React, { Component } from 'react';
import axios from 'axios';
import { BASE_URL } from '../../constants';
import { Textarea } from 'react-inputs-validation';
import 'react-inputs-validation/lib/react-inputs-validation.min.css';
import Rating from 'react-rating';
import 'font-awesome/css/font-awesome.min.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
class RegisterForm extends Component {
    constructor(props){
        super(props);
        this.state = {
            rate: 0,
            reviewText: ''
        };
    }

    onChange = (data,e) => {
        this.setState({[e.target.name]: data});
    }

    selectOnChange = (data, e) => {
        this.setState({rate: data});
    }

    submit = e => {
        e.preventDefault();
        
        axios.post(`${BASE_URL}/users/${this.props.match.params.id}/reviews`,
          {
              content: this.state.reviewText,
              rate: this.state.rate
          }
        ).then(resp => {
            this.props.history.goBack();
        }).catch(err => {
            console.log(err);
        })
    }

    returnBackOnClick = e => {
        this.props.history.goBack();
    }

    onRatingClick = value => {
        this.setState({rate: value});
    }

    render() {
        return (
            <div className="container h-75">
             <FontAwesomeIcon icon="arrow-left" className="return-page" onClick={this.returnBackOnClick  }/>
                <div className="row h-100 justify-content-center align-items-center">
                    <form className="col-4">
                        <div className="mb-4 text-center">
                            <h3 className="display-3">Dodawanie opinii</h3>
                        </div>
                        <div className="form-group">
                            <label htmlFor="jobTitle">Ocena: </label>
                            <Rating
                                emptySymbol="fa fa-star-o fa-lg"
                                fullSymbol="fa fa-star fa-lg"
                                initialRating={this.state.rate}
                                onClick={this.onRatingClick}
                            />
                        </div>
                        <div className="form-group">
                            <label htmlFor="formGroupExampleInput">Opinia tekstowa</label>
                            <Textarea id={'reviewText'} rows={8} cols={4} type="text" name="reviewText" placeholder="Opinia o pracowniku.." value={this.state.reviewText} onChange={this.onChange} onBlur={() => {}}/>
                        </div>
                         <div className="float-right mt-3">
                             <input type="submit" value="Dodaj opinię" onClick={this.submit} className="btn btn-danger"/> 
                        </div>                                                                                          
                    </form>                         
            </div>
        </div>
        )
    }
}
export default RegisterForm;