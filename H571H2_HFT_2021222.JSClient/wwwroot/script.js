let games = [];
let companies = [];
let people = [];
let noncruddata = [];
let noncruddata2 = [];

let gameIdToUpdate = -1
let companyIdToUpdate = -1
let personIdToUpdate = -1

const container = document.querySelector('#container')
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
//getnoncrud();

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


/**NONCRUD 1*/
const toggleButton = document.getElementById('button1');
const myTable = document.getElementById('noncrud');

toggleButton.addEventListener('click', function () {
    myTable.classList.toggle('hidden');
    getnoncrud();
});


async function getnoncrud() {
    await fetch('http://localhost:38231/stat/top3companywithmostgames')
        .then(x => x.json())
        .then(y => {
            noncruddata = y;
            console.log(noncruddata);
            displaynoncrud();
        });
}

function displaynoncrud() {
    noncrudarea.innerHTML = "";
    noncruddata.forEach(t => {
        document.getElementById('noncrudarea').innerHTML +=
            "<tr><td>" + t.key + "</td><td>"
            + t.value + "</td></tr>";
    });
}


/**NONCRUD 2*/
const toggleButton2 = document.getElementById('button2');
const myTable2 = document.getElementById('noncrud2');

toggleButton2.addEventListener('click', function () {
    myTable2.classList.toggle('hidden');
    getnoncrud2();
});

async function getnoncrud2() {
    await fetch('http://localhost:38231/stat/companieswithfpsgames')
        .then(x => x.json())
        .then(y => {
            noncruddata2 = y;
            console.log(noncruddata2);
            displaynoncrud2();
        });
}

function displaynoncrud2() {
    noncrudarea2.innerHTML = "";
    noncruddata2.forEach(t => {
        document.getElementById('noncrudarea2').innerHTML +=
            "<tr><td>" + t.key + "</td><td>"
            + t.value + "</td></tr>";
    });
}

/**NONCRUD 3*/

const toggleButton3 = document.getElementById('button3');
const myTable3 = document.getElementById('noncrud3');

toggleButton3.addEventListener('click', function () {
    myTable3.classList.toggle('hidden');
    getnoncrud3();
});

async function getnoncrud3() {
    await fetch('http://localhost:38231/stat/companynamelongerthan20')
        .then(x => x.json())
        .then(y => {
            noncruddata3 = y;
            console.log(noncruddata3);
            displaynoncrud3();
        });
}

function displaynoncrud3() {
    noncrudarea3.innerHTML = "";
    noncruddata3.forEach(t => {
        document.getElementById('noncrudarea3').innerHTML +=
            "<tr><td>" + t.key + "</td><td>"
            + t.value + "</td></tr>";
    });
}

/**NONCRUD 4*/

const toggleButton4 = document.getElementById('button4');
const myTable4 = document.getElementById('noncrud4');

toggleButton4.addEventListener('click', function () {
    myTable4.classList.toggle('hidden');
    getnoncrud4();
}
);

async function getnoncrud4() {
    await fetch('http://localhost:38231/stat/executivesalaryabove1000employee')
        .then(x => x.json())
        .then(y => {
            noncruddata4 = y;
            console.log(noncruddata4);
            displaynoncrud4();
        });
}

function displaynoncrud4() {
    noncrudarea4.innerHTML = "";
    noncruddata4.forEach(t => {
        document.getElementById('noncrudarea4').innerHTML +=
            "<tr><td>" + t.key + "</td><td>"
            + t.value + "</td></tr>";
    });
}

/**NONCRUD 5*/

const toggleButton5 = document.getElementById('button5');
const myTable5 = document.getElementById('noncrud5');

toggleButton5.addEventListener('click', function () {
    myTable5.classList.toggle('hidden');
    getnoncrud5();
});

async function getnoncrud5() {
    await fetch('http://localhost:38231/stat/top10mostplayedgamesexecutiveage')
        .then(x => x.json())
        .then(y => {
            noncruddata5 = y;
            console.log(noncruddata5);
            displaynoncrud5();
        });
}

function displaynoncrud5() {
    noncrudarea5.innerHTML = "";
    noncruddata5.forEach(t => {
        document.getElementById('noncrudarea5').innerHTML +=
            "<tr><td>" + t.key + "</td><td>"
            + t.value + "</td></tr>";
    });
}

