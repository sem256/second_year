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

    function creates(elem) {
        var chiefDiv,
            leftDiv,
            names,
            rightDiv,
        data = JSON.parse(elem);

        chiefDiv = document.createElement("div");
        leftDiv = document.createElement("div");
        rightDiv = document.createElement("div");
        document.getElementById("output").appendChild(chiefDiv);
        chiefDiv.appendChild(leftDiv);
        chiefDiv.appendChild(rightDiv);
        leftDiv.innerHTML = "Property Name";
        rightDiv.innerHTML = "Property Value";
        leftDiv.className = "left_block";
        rightDiv.className = "right_block";
        chiefDiv.className = "chief_block";
        rightDiv.style.backgroundColor = "#73CEFF";
        leftDiv.style.backgroundColor = "#73CEFF";

        for (names in data) {
            if (data.hasOwnProperty(names)) {
                chiefDiv = document.createElement("div");
                leftDiv = document.createElement("div");
                rightDiv = document.createElement("div");
                document.getElementById("output").appendChild(chiefDiv);
                chiefDiv.appendChild(leftDiv);
                chiefDiv.appendChild(rightDiv);
                leftDiv.innerHTML = names;
                rightDiv.innerHTML = data[names];
                leftDiv.className = "left_block";
                rightDiv.className = "right_block";
                chiefDiv.className = "chief_block";
            }
        }
    }
    var req = getXmlHttp();
    req.onreadystatechange = function () {
        if ((req.readyState === 4) && (req.status === 200)) {
            creates(req.responseText);
        }
    };
    req.open('GET', "data.json");
    req.send();
};