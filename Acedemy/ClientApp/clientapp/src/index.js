import _ from 'lodash';

import React from 'react';
import ReactDOM from 'react-dom';
import {Provider} from 'react-redux';
import {createStore,applyMiddleware} from 'redux';
import promise from 'redux-promise';
import './index.css';
import Header from './components/header';
import Footer from './components/footer';
import registerServiceWorker from './registerServiceWorker';
import {BrowserRouter, Route, Switch} from 'react-router-dom';
import {routes} from './common/routes';
import reducers from './reducers';

//Dynamically create routes
function RenderRoutes(){

    return _.map(routes, (route) => {
        return <Route path={route.path} component={route.component} key={route.id} />
    });

}

const createStoreWithMiddleware = applyMiddleware(promise)(createStore);

ReactDOM.render((
    <Provider store={createStoreWithMiddleware(reducers)}>
    <Header />
        <BrowserRouter>
            <div>
                <Switch>
                    {RenderRoutes()}
                </Switch>
            </div>
        </BrowserRouter>
    <Footer />
    </Provider>
), document.getElementById('root'));
registerServiceWorker();
