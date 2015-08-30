window.onload = function () {
    var elem = document.getElementById("header").childNodes,
     flag = true,
     i, v,
     bColor,
     footerChild = document.getElementById("footer").childNodes,
     mas = [],
     dragAndDrop = document.getElementById("row"),
     fff = document.getElementById("footer"),
     center = document.getElementById("center");
    // перевіряємо, що розуміє браузер який ми використовуємо
    if (window.addEventListener) {
        flag = true;
    }
    else {
        if (window.attachEvent) {
            flag = false;
            if (fff.currentStyle.backgroundColor === "black") {
                bColor = true;
            }
        }
    }
    // генерує довільний колір
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
    // змінює колір блоків при наведенні
    function hendler_header(event) {
        if (flag) {
            event.target.style.backgroundColor = getRandomColor();
        }
        else {
            event = window.event;
            event.toElement.style.backgroundColor = getRandomColor();
        }
    }
    for (i = 0; i < elem.length; i++) {
        if (flag) {
            elem[i].addEventListener("mouseover", hendler_header, true);
            elem[i].style.backgroundColor = getRandomColor();
        }
        else {
            elem[i].attachEvent("onmouseover", hendler_header);
            elem[i].style.backgroundColor = getRandomColor();
        }
    }
    // звінює колір блоків при натисканні, 
    //а також при наступному натисканні пише відповідну літеру 
    function hendler_footer(event) {
        var k, n;
        for (n = 0; n < footerChild.length; n++) {
            if (flag) {
                if (event.target === footerChild[n]) {
                    k = n;
                }
            }
            else {
                event = window.event;
                if (event.srcElement === footerChild[n]) {
                    k = n;
                }
            }
        }
        if (mas[k]) {
            if (flag) {
                event.target.style.backgroundColor = getRandomColor();
            }
            else {
                event.srcElement.style.backgroundColor = getRandomColor();
            }
            if (bColor && (k === 3)) {
                document.getElementById("footer").style.backgroundColor = "black";
            }
            footerChild[k].style.border = "4px solid black";
            footerChild[k].innerHTML = "";
            mas[k] = false;
        }
        else {
            footerChild[k].style.backgroundColor = "white";
            footerChild[k].style.border = "0px solid black";
            switch (k) {
                case 0:
                    footerChild[0].innerHTML = "К";
                    break;
                case 1:
                    footerChild[1].innerHTML = "И";
                    break;
                case 2:
                    footerChild[2].innerHTML = "Ї";
                    break;
                case 3:
                    footerChild[3].innerHTML = "В";
                    if (bColor) {
                        document.getElementById("footer").style.backgroundColor = "white";
                    }
                    break;
            }
            mas[k] = true;
        }
    }
    for (v = 0; v < footerChild.length; v++) {
        if (flag) {
            footerChild[v].addEventListener("click", hendler_footer, true);
        }
        else {
            footerChild[v].attachEvent("onclick", hendler_footer);
        }
        footerChild[v].style.backgroundColor = getRandomColor();
    }
    // змінює положення рухомого блоку, якщо він зайшов за межу при зміненні розмірів екрана
    function positionElement() {
        var dragAnd = document.getElementById("row"),
            c = document.getElementById("center");
        if ((dragAnd.offsetLeft + 50) > c.offsetWidth) {
            dragAnd.style.left = c.offsetWidth - 50 + "px";
        }
    }
    if (flag) {
        window.addEventListener("resize", positionElement, true);
    }
    else {
        window.attachEvent("onresize", positionElement);
    }
    // метод для пересування блоку
    function drag(elementToDrag, event) {
        var startX = event.clientX,
        startY = event.clientY,
        origX = elementToDrag.offsetLeft,
        origY = elementToDrag.offsetTop,
        deltaX = startX - origX,
        deltaY = startY - origY;
        function moveHandler(e) {
            if (!e) {
                e = window.event;
            }
            var w = center.offsetWidth - 50,
             h = center.offsetHeight - 50,
             apexX = e.clientX - deltaX,
             apexY = e.clientY - deltaY;

            if ((0 <= apexX) && (0 <= apexY)) {
                if ((w > apexX) && (h > apexY)) {
                    elementToDrag.style.left = (e.clientX - deltaX) + "px";
                    elementToDrag.style.top = (e.clientY - deltaY) + "px";
                }
            }
        }
        // коли підняли кнопу миші, видаляємо обробники подій
        function upHandler(e) {
            if (!e) {
                e = window.event;
            }
            if (flag) {
                document.removeEventListener("mouseup", upHandler, true);
                document.removeEventListener("mousemove", moveHandler, true);
            }
            else {
                document.detachEvent("onmouseup", upHandler);
                document.detachEvent("onmousemove", moveHandler);
            }
        }
        if (flag) {
            document.addEventListener("mousemove", moveHandler, true);
            document.addEventListener("mouseup", upHandler, true);
        }
        else {
            document.attachEvent("onmousemove", moveHandler);
            document.attachEvent("onmouseup", upHandler);
        }
    }
    if (flag) {
        dragAndDrop.addEventListener("mousedown", function (e) {
            drag(this, e);
        });
    }
    else {
        dragAndDrop.attachEvent("onmousedown", function (event) {
            event = window.event;
            drag(event.srcElement, event);
        });
    }
};