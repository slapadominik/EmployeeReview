export const isUserLoggedIn = () => {
    var token = localStorage.getItem('jwtToken')
    if (token !== null){
        console.log('token istnieje: '+token)
        return token;
    }
    console.log('token nie istnieje')
    return false;
 }