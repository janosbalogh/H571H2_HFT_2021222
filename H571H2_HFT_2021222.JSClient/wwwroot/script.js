let games = [];
let companies = [];
let people = [];

let gameIdToUpdate = -1
let companyIdToUpdate = -1
let personIdToUpdate = -1

let connection = null;

const gametable = document.getElementById('gametable');
const gametbody = gametable.tBodies[0];

const companytable = document.getElementById('companytable');
const companytbody = companytable.tBodies[0];

const persontable = document.getElementById('persontable');
const persontbody = persontable.tBodies[0];

getgamedata();
getcompanydata();
getpersondata();

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:38231/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("GameCreated", (user, message) => {
        getgamedata();
    });

    connection.on("GameDeleted", (user, message) => {        
        getgamedata();
    });

    connection.on("GameUpdated", (user, message) => {
        getgamedata();
    });
    connection.on("CompanyCreated", (user, message) => {
        getcompanydata();
    });

    connection.on("CompanyDeleted", (user, message) => {
        getcompanydata();
    });

    connection.on("CompanyUpdated", (user, message) => {
        getcompanydata();
    });
    connection.on("PersonCreated", (user, message) => {
        getpersondata();
    });

    connection.on("PersonDeleted", (user, message) => {
        getpersondata();
    });

    connection.on("PersonUpdated", (user, message) => {
        getpersondata();
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

//***GAME DATA */
async function getgamedata() {
    await fetch('http://localhost:38231/Game')
        .then(x => x.json())
        .then(y => {
            games = y;
            console.log(games);
            displaygame();
        });
}

function displaygame() {
    gametbody.innerHTML = "";
    games.forEach(t => {
        document.getElementById('gameresultarea').innerHTML +=
            "<tr><td>" + t.gameID + "</td><td>"
            + t.gameName + "</td><td>" +
            `<button type="button" onclick="removegame(${t.gameID})">Delete</button>` +
            `<button type="button" onclick="showupdategame(${t.gameID})">Update</button>`
            + "</td></tr>";
    });
}


//***COMPANY DATA*/
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
    companytbody.innerHTML = "";
    companies.forEach(t => {
        document.getElementById('companyresultarea').innerHTML +=
            "<tr><td>" + t.companyID + "</td><td>"
            + t.companyName + "</td><td>" +
            `<button type="button" onclick="removecompany(${t.companyID})">Delete</button>` +
            `<button type="button" onclick="showupdatecompany(${t.companyID})">Update</button>`
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
    persontbody.innerHTML = "";
    people.forEach(t => {
        document.getElementById('personresultarea').innerHTML +=
            "<tr><td>" + t.personID + "</td><td>"
            + t.personName + "</td><td>" +
            `<button type="button" onclick="removeperson(${t.personID})">Delete</button>` +
            `<button type="button" onclick="showupdateperson(${t.personID})">Update</button>`
            + "</td></tr>";
    });
}


/**game crud*/
function removegame(id) {
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

function updategame() {
    document.getElementById('updategameformdiv').style.display = 'none';
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

function showupdategame(id) {
    document.getElementById('gamenametoupdate').value = games.find(x => x['gameID'] == id)['gameName'];
    document.getElementById('updategameformdiv').style.display = 'flex';
    gameIdToUpdate = id;
}

function creategame() {
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

/**company crud */
function removecompany(id) {
    fetch('http://localhost:38231/company/' + id, {
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

function updatecompany() {

    document.getElementById('updatecompanyformdiv').style.display = 'none';
    let name = document.getElementById('companynametoupdate').value;
    fetch('http://localhost:38231/company', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { companyName: name, companyID: companyIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

    
}

function showupdatecompany(id) {
    document.getElementById('companynametoupdate').value = companies.find(x => x['companyID'] == id)['companyName'];
    document.getElementById('updatecompanyformdiv').style.display = 'flex';
    companyIdToUpdate = id;
}

function createcompany() {
    let name = document.getElementById('companyname').value;
    fetch('http://localhost:38231/company', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { companyName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

/**person crud */
function removeperson(id) {
    fetch('http://localhost:38231/person/' + id, {
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

function updateperson() {
    document.getElementById('updatepersonformdiv').style.display = 'none';
    let name = document.getElementById('companynametoupdate').value;
    fetch('http://localhost:38231/company', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { personName: name, personID: personIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdateperson(id) {
    document.getElementById('personnametoupdate').value = people.find(x => x['personID'] == id)['personName'];
    document.getElementById('updatepersonformdiv').style.display = 'flex';
    personIdToUpdate = id;
}

function createperson() {
    let name = document.getElementById('personname').value;
    fetch('http://localhost:38231/person', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { personName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}