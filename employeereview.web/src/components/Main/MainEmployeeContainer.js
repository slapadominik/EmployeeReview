import React, { Component } from 'react';
import { connect } from 'react-redux';

class MainEmployeeContainer extends Component {
    render() {
        return (
            <div className="container">
                <h3>Zespół</h3>
            </div>
        );
    }
}


export default connect(null, null)(MainEmployeeContainer)
