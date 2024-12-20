// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/systemr").build();

connection.on("LoadRooms", function () {
    location.href = '/Index'
});
connection.on("LoadBookings", function () {
    location.href = '/Booking/Index'
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});