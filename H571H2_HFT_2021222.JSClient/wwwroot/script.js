let games = [];
let connection = null;
getdata();
setupSignalR();

let gameIdToUpdate = -1

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:39141/hub")
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

async function getdata() {
    await fetch('http://localhost:39141/game')
        .then(x => x.json())
        .then(y => {
            games = y;
            //console.log(games);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    games.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.GameID + "</td><td>"
            + t.Name + "</td><td>" +
            `<button type="button" onclick="remove(${t.GameID})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.GameID})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:39141/game/' + id, {
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
    fetch('http://localhost:39141/game', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, GameId: GameIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('gamenametoupdate').value = companies.find(x => x['GameID'] == id)['Name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    gameIdToUpdate = id;
}

function create() {
    let name = document.getElementById('gamename').value;
    fetch('http://localhost:39141/game', {
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