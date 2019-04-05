import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import "bootstrap/dist/css/bootstrap.css";
import setAuthorizationToken from './helpers/setAuthorizationToken';
import { createStore, applyMiddleware} from 'redux';
import rootReducer from './reducers/rootReducer';
import { composeWithDevTools } from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import { Provider } from 'react-redux';
import jwt from 'jsonwebtoken';
import { setCurrentUser } from './actions/authActions';
import { library } from '@fortawesome/fontawesome-svg-core'
import { faPen, faArrowLeft } from '@fortawesome/free-solid-svg-icons'

library.add(faPen, faArrowLeft);


const store = createStore(rootReducer,
    composeWithDevTools(
        applyMiddleware(thunk)
    )
);


if (localStorage.jwtToken){
    setAuthorizationToken(localStorage.jwtToken);
    store.dispatch(setCurrentUser(jwt.decode(localStorage.jwtToken)));
}


ReactDOM.render(
        <Provider store={store}>
            <App />
        </Provider>, 
        document.getElementById('root'));



// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
