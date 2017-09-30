import React, {Component} from 'react';
import {Field, reduxForm} from 'redux-form';
import textInput from './FormFields/text-input';

class Register extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <form>
                <Field type="text" placeholder="Username" component={textInput}/>
                <Field type="password" placeholder="Password" component={textInput}/>
            </form>
        );
    }

}

export default Register;