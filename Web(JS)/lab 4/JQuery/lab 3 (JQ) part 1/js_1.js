$(function () {
    $("#row").draggable({
        containment: "parent"
    });
    function getRandomColor() {
        var array1 = "0123456789ABCDEF",
         letters = array1.split(''),
         color = '#',
         j;
        for (j = 0; j < 6; j++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    }
    function changeC() {
        this.style.backgroundColor = getRandomColor();
    }
    var top = $("#header")[0].children,
        footer = $("#footer")[0].children,
        array = [], i, bColor,
         leter = function (event) {
             var elem = event.target || event.srcElement,
                 r, j;
             for (j = 0; j < footer.length; j++) {
                 if (footer[j] === elem) {
                     r = j;
                 }
             }
             if (array[r]) {
                 elem.style.backgroundColor = getRandomColor();
                 footer[r].innerHTML = "";
                 footer[r].style.border = "4px solid black";
                 if (bColor && (r === 3)) {
                     document.getElementById("footer").style.backgroundColor = "black";
                 }
                 array[r] = false;
             }
             else {
                 elem.style.backgroundColor = "white";
                 footer[r].style.border = "0px solid black";
                 switch (r) {
                     case 0:
                         footer[0].innerHTML = "К";
                         break;
                     case 1:
                         footer[1].innerHTML = "И";
                         break;
                     case 2:
                         footer[2].innerHTML = "Ї";
                         break;
                     case 3:
                         footer[3].innerHTML = "В";
                         if (bColor) {
                             document.getElementById("footer").style.backgroundColor = "white";
                         }
                         break;
                 }
                 array[r] = true;
             }

         };
    if (window.attachEvent) {
        if (document.getElementById("footer").currentStyle.backgroundColor === "black") {
            bColor = true;
        }
    }
    for (i = 0; i < top.length; i++) {
        $(top[i]).on("mouseover", changeC);
        $(footer[i]).click(leter);
    }
    for (i = 0; i < top.length; i++) {
        top[i].style.backgroundColor = getRandomColor();
        footer[i].style.backgroundColor = getRandomColor();
    }
});
$(window).resize(function () {
    var dragAnd = document.getElementById("row"),
            c = document.getElementById("center");
    if ((dragAnd.offsetLeft + 50) > c.offsetWidth) {
        dragAnd.style.left = c.offsetWidth - 50 + "px";
    }
});