// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function checkAgeWithinCorrectRange() {
    var age = parseInt(document.getElementById("Age").value);
    if (age >= 18 && age <= 65) {
        document.getElementById("submitBut").disabled = false;
    }
    else {
        document.getElementById("submitBut").disabled = true;
        alert("I'm afraid customers can only be aged between 18 and 65.");
    }
}