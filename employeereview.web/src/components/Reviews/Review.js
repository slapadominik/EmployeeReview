import React, { Component } from 'react'
import Rating from 'react-rating';
import './Review.css';

export default class Review extends Component {
    constructor(props){
        super(props);
        console.log('wtf');
    }
    render(){
        console.log('wtf');
        return(
            <div className="card border-danger mt-2">
                <div className="card-header bg-danger text-white ">
                    <div className="row align-items-center">
                        <div className="col-md-9">
                            Autor: {this.props.authorName}
                        </div>
                        <div className="col-md-3">
                            {this.props.created.split('T')[0]}
                        </div>
                    </div>


                </div>
                <div className="card-body">
                    <p className="card-title">Ocena: <Rating
                        emptySymbol="fa fa-star-o fa-lg"
                        fullSymbol="fa fa-star fa-lg"
                        initialRating={this.props.rate}
                        readonly={true}
                        /></p>
                    <p className="card-text">{this.props.content}</p>
                </div>
            </div>
        );        
    }
}