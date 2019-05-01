import {store} from '../store'; 
import {ADMIN_ROLE} from '../constants';

export const isUserAdmin = () => {
    let newState = store.getState();
    return newState.auth.isAuthenticated && newState.auth.user.roles.includes(ADMIN_ROLE);
}

store.subscribe(isUserAdmin);

