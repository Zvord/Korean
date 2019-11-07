function KeyPressed(event) {
    if (event.keyCode == 13) {
        document.getElementById("mainButton").click();
    }
}

function placeFocus() {
    document.getElementById("UserGuess").focus();
    document.getElementById("UserGuess").select();
}