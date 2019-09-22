"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    //var msg = message;
    alert(message);
    //var encodedMsg = " says " + msg;
    //var td = document.createElement("td");
    //td.textContent = encodedMsg;
    //document.getElementById("messagesList").appendChild(td);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("addDatePicker").value;
    connection.invoke("SendNotification", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});