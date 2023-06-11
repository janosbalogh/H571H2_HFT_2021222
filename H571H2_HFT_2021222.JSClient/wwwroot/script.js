fetch('http://localhost:38231/company')
    .then(response => response.json())
    .then(data => console.log(data));