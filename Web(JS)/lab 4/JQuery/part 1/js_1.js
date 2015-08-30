$(document).ready(function () {
    var row = $('#t2')[0].rows,
        array = [".td1", ".td2", ".td3", ".td4", ".td5"],
    i, j;
    for (i = 0; i < row.length; i++) {
        if (i % 2 === 0) {
            for (j = 0; j < row[i].children.length; j++) {
                $("td").filter(array[i]).css("background-color", "black");
                row[i].children[j].style.backgroundColor = "black";
            }
        }
    }
});