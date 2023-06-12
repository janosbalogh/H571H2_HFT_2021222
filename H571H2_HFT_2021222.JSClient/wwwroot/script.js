let games = [];
let companies = [];
let people = [];

let connection = null;

const table1 = document.getElementById('table1');
const tbody1 = table1.tBodies[0];

const table2 = document.getElementById('table2');
const tbody2 = table2.tBodies[0];

const table3 = document.getElementById('table3');
const tbody3 = table3.tBodies[0];


getdata();
getcompanydata();
getpersondata();

setupSignalR();

let gameIdToUpdate = -1

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:38231/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("GameCreated", (user, message) => {
        getdata();
    });

    connection.on("GameDeleted", (user, message) => {        
        getdata();
    });

    connection.on("GameUpdated", (user, message) => {
        getdata();
    });
    connection.on("CompanyCreated", (user, message) => {
        getdata();
    });

    connection.on("CompanyDeleted", (user, message) => {
        getdata();
    });

    connection.on("CompanyUpdated", (user, message) => {
        getdata();
    });


    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

//*         GAME DATA */
async function getdata() {
    await fetch('http://localhost:38231/Game')
        .then(x => x.json())
        .then(y => {
            games = y;
            console.log(games);
            display();
        });
}

function display() {
    tbody1.innerHTML = "";
    games.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.gameID + "</td><td>"
            + t.gameName + "</td><td>" +
            `<button type="button" onclick="remove(${t.gameID})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.gameID})">Update</button>`
            + "</td></tr>";
    });
}

//**COMPANY DATA*/
async function getcompanydata() {
    await fetch('http://localhost:38231/Company')
        .then(x => x.json())
        .then(y => {
            companies = y;
            console.log(companies);
            displaycompany();
        });
}

function displaycompany() {
    tbody2.innerHTML = "";
    companies.forEach(t => {
        document.getElementById('resultarea1').innerHTML +=
            "<tr><td>" + t.companyID + "</td><td>"
            + t.companyName + "</td><td>" +
            `<button type="button" onclick="remove(${t.companyID})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.companyID})">Update</button>`
            + "</td></tr>";
    });
}

//***PERSON DATA */
async function getpersondata() {
    await fetch('http://localhost:38231/Person')
        .then(x => x.json())
        .then(y => {
            people = y;
            console.log(people);
            displayperson();
        });
}

function displayperson() {
    tbody3.innerHTML = "";
    people.forEach(t => {
        document.getElementById('resultarea2').innerHTML +=
            "<tr><td>" + t.personID + "</td><td>"
            + t.personName + "</td><td>" +
            `<button type="button" onclick="remove(${t.personID})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.personID})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:38231/game/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('gamenametoupdate').value;
    fetch('http://localhost:38231/game', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { gameName: name, gameID: gameIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('gamenametoupdate').value = games.find(x => x['gameID'] == id)['gameName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    gameIdToUpdate = id;
}

function create() {
    let name = document.getElementById('gamename').value;
    fetch('http://localhost:38231/game', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { gameName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}