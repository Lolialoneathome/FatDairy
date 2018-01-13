export function GetCurrentUser() {
  function status(response) {
    if (response.status === 401) {
      return null;
    }
    if (response.status >= 200 && response.status < 300) {  
      return response.json()
    } else {  
      return Promise.reject(new Error(response.statusText))  
    }  
  }

  fetch('http://localhost:5000/api/auth', {
    headers: {
    'Content-Type': 'application/json'},  
    mode: 'cors'})  
    .then(status)
    .catch(function(error) {  
      console.log('Request failed', error);  
    });
}