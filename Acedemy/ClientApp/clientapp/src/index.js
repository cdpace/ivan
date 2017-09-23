import _ from 'lodash';

import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import Header from './components/header';
import Footer from './components/footer';
import registerServiceWorker from './registerServiceWorker';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import {routes} from './common/routes';

function RenderRoutes(){

    return _.map(routes, (route) => {
        return <Route path={route.path} component={route.component} key={route.id} />
    });

}

ReactDOM.render((
<div>
    <Header />
        <BrowserRouter>
            <div>
                <Switch>
                    {RenderRoutes()}
                </Switch>
            </div>
        </BrowserRouter>
    <Footer />
</div>


), document.getElementById('root'));
registerServiceWorker();
