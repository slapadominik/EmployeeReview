// export const isUserLoggedIn = () => {
//     var token = localStorage.getItem('jwtToken')
//     if (token !== null){
//         console.log('token istnieje: '+token)
//         return token;
//     }
//     console.log('token nie istnieje')
//     return false;
//  }

import store from '../store';

export const isUserLoggedIn = () => {
   var newState =store.getState();
   console.log(newState);
    if(newState.auth.token != null) {
       return true;
    }

     return false;
}

store.subscribe(isUserLoggedIn)
 