import React, {Component} from 'react';
import {Link} from 'react-router-dom';

class Content extends Component {
    render() {
        return (
            <div>
                Content
                <Link to="/">Home</Link>
            </div>
        );
    }
}

export default Content;