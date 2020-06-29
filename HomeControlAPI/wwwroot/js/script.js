const uri = 'home/device';
let todos = [];

function getInfo() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items.', error));
}

function _displayItems(data) {

    const message = document.getElementById('values');

    if (data[0].status == true) {

        message.innerHTML = "<i style='color:#d9701a;transition:2s;' class='material-icons'>lens</i>";

    } else {

        message.innerHTML = "<i style='color:#182040;transition:2s;' class='material-icons'>lens</i>";

    }

    todos = data;
}

function updateDevice() {
    const device = todos[0];

    if (device.status == true) {
        device.status = false;
    } else {
        device.status = true;
    }

    fetch(`${uri}/${device.id}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(device)
    })
        .then(() => getInfo())
        .catch(error => console.error('Unable to update item.', error));
        return false;
}
