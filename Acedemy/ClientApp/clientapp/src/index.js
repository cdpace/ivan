import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Header from './components/header';
import Footer from './components/footer';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render((
<div>
    <Header />
    <Footer />
</div>


), document.getElementById('root'));
registerServiceWorker();
