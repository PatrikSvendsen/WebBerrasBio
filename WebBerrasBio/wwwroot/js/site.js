// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('#myTable').DataTable();
});

function submitText() {
    var html = "Name: " + $("#fname").val() + " " + $("#lname").val() +
        "<br>Email: " + $("#email").val() + "<br>Total price: "
        + calcPrice();
    $("#bodyModal").html(html);
}
function calcPrice() {
    return $("#bookedticks").val() * $("#price").val();
}

function submitEmail() {
    var x = document.getElementById("Email");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function submitAdress() {
    var x = document.getElementById("Adress");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}

function submitTele() {

    var x = document.getElementById("Tele");
    if (x.style.display === "none") {
        x.style.display = "block";
    } else {
        x.style.display = "none";
    }
}
