import store from '../store';

export const isUserLoggedIn = () => {
    let newState = store.getState();
    return newState.auth.isAuthenticated;
} 
console.log(store);
store.subscribe(isUserLoggedIn);


