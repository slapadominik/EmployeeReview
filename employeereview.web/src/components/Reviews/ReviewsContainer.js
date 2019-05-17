import React, { Component } from 'react';
import axios from 'axios';
import Review from './Review';
import { BASE_URL } from '../../constants';

export default class ReviewsContainer extends Component {
    constructor(props){
        super(props);
        this.state = {
            reviews: []
        }
    }

    componentWillMount(){
        axios.get(BASE_URL+`/users/${this.props.userId}/reviews`)
                .then(response => {
                    if (response.status===200){
                        this.setState({reviews: response.data});

                    }
                }).catch(error => {
                    if (error.response) {
                        alert('Something went wrong');
                        console.log(error);
                    }
                    else{
                        console.log(error);
                    }
                });
    }

    mapReviews = () => {
       return this.state.reviews.map((x, key) => <Review key={key} rate={x.rate} content={x.content} created={x.created} authorName={`${x.author.firstName} ${x.author.lastName}`}/>);
    }

    render(){
        return(
            <div>
                {this.mapReviews()}
            </div>
        );
    }
}