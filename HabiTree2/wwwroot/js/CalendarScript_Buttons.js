console.log("hhhh")

let dateBoxes = document.getElementsByClassName("CalendarClickable");

let colIndex = 0;
let boxColors = ["green", "red", "yellow", "white"];

for (var i = 0, len = dateBoxes.length; i < dateBoxes.length; i++) {
    dateBoxes[i].style["background-color"] = "white";
    dateBoxes[i].addEventListener('click', changeBoxColor);
}

function changeBoxColor(d) {


    console.log("d", d)
    console.log("this", this)

    for (var i = 0; i < dateBoxes.length; i++) {
        dateBoxes[i].style["background-color"] = boxColors[colIndex];
    }

    colIndex++;
    if (colIndex >= boxColors.length)
        colIndex = 0;
}


