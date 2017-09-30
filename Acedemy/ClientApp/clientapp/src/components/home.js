import React, {Component} from 'react';
import {Link} from 'react-redux-dom';

class Home extends Component {
    render() {
        return (
            <div>
                Home
                <h2>Register</h2>
                <Link to="/register">Register</Link>
            </div>
        );
    }
}


export default Home;