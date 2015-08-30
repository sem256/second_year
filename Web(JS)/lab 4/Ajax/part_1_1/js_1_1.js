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
    var req = getXmlHttp(),
    statusElem = document.getElementById('output');
    req.open('GET', "text_1_1.txt");
    req.onreadystatechange = function () {
        if ((req.readyState === 4) && (req.status === 200)) {
            statusElem.innerHTML = req.responseText.replace(/\n/g, "<br />");
        }
    };
    req.send();
};
