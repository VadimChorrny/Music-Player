const users = "https://jsonplaceholder.typicode.com/users";
const tracks = "https://localhost:44398/api/track";

const requestURL = users;

const xhr = new XMLHttpRequest();

function sendRequest(method, url, body = null) {
    return new Promise((resolve, reject) => {
        xhr.open(method, url);

        xhr.responseType = "json"; // витягуємо з апішкі в джсон форматі

        xhr.onload = () => {
            if (xhr.status >= 400) {
                reject(xhr.response);
            } else {
                resolve(xhr.response);
            }
        };

        xhr.onerror = () => {
            reject(xhr.response);
        };

        xhr.send(JSON.stringify(body));
    });
}

// FOR GET FROM API
// sendRequest("GET", requestURL)
//     .then((data) => console.log(data))
//     .catch((err) => console.log(err));

// FOR POST TO API

const body = {
    name: "Vadym",
    age: 18,
};

sendRequest("POST", requestURL, body)
    .then((data) => console.log(data))
    .catch((err) => console.log(err));

// COMMENTS

// resolve if success
// reject if error
