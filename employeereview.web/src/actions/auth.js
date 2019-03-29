import {  LOGIN, LOGOUT } from './types';

export const login = (token) => dispatch => {
    dispatch({
        type: LOGIN,
        payload: token 
    })    
}

export const logout = () => dispatch => {
    dispatch({
        type: LOGOUT
    })    
}