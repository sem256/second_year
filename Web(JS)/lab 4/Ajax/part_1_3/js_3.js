window.onload = function () {
    function getXmlHttp() {
        var xmlhttp;
        try {
            xmlhttp = new window.ActiveXObject("Msxml2.XMLHTTP");
        } catch (e) {
            try {
                xmlhttp = new window.ActiveXObject("Microsoft.XMLHTTP");
            } catch (E) {
                xmlhttp = false;
            }
        }
        if (!xmlhttp) {
            xmlhttp = new XMLHttpRequest();
        }
        return xmlhttp;
    }
    var Ev = document.addEventListener,
        button = document.getElementById("button");


    function f() {
        var req = getXmlHttp(),
            xml,iE,
        statusElem = document.getElementById('output');
        req.open('GET', "xml_3.xml");
        req.onreadystatechange = function () {
            if ((req.readyState === 4) && (req.status === 200)) {
                xml = req.responseXML;
                if (xml.children) {
                    statusElem.innerHTML = xml.children[0].innerHTML;
                }
                else {
                    iE = req.responseText.substring(38, req.responseText.length);
                    statusElem.innerHTML = iE;
                }

            }
        };
        req.send();
    }
    if (Ev) {
        button.addEventListener("click", f);
    }
    else {
        button.attachEvent("onclick", f);
    }
};