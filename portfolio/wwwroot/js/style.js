var signInDiv = document.getElementById("signin");
var overlay = document.getElementById("overlay");

function toggleSignin() {
    overlay.classList.toggle("hidden");
    signInDiv.classList.toggle("hidden");
}
overlay.addEventListener("click", toggleSignin);