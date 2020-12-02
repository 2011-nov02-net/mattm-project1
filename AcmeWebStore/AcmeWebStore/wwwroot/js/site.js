// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//////
//Home Page Scripts
///

const signInButton = $("#signInButton");
const newUserButton = $("#newUserButton");

signInButton.on("click", () => {
    window.location.href = "Store/SignIn"
});

newUserButton.on("click", () => {
    window.location.href = "Store/NewUser"
});