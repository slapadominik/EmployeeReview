import { LOGIN,  LOGOUT } from '../actions/types';

const initialState = {
    authToken: null,
}

export default function (state = initialState, action) {
    switch(action.type) {
        case LOGIN: {
            return {
                ...state,
                authToken: action.payload
            }
        }

        case LOGOUT: {
            return {
                ...state,
                authToken: null
            }
        }

        default:
            return state;
    }
}