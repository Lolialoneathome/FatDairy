export function GetCurrentUser() {
  function status(response) {
    if (response.status == 401) {
      console.log("redirect to login");
      return;
    }
    if (response.status >= 200 && response.status < 300) {  
      return Promise.resolve(response)  
    } else {  
      return Promise.reject(new Error(response.statusText))  
    }  
  }
  
  function json(response) {
    return response.json()
  }

  fetch('http://localhost:5000/api/auth')  
    .then(status)  
    .then(json)  
    .then(function(data) {
      console.log('Request succeeded with JSON response', data);  
    }).catch(function(error) {  
      console.log('Request failed', error);  
    });
}