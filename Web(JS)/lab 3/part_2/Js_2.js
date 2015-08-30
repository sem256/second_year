window.onload = function () {
    function CreateObject(title, fly, dangerous) {
        this.title = title;
        this.fly = fly;
        this.dangerous = dangerous;
    }
    var lion = new CreateObject("lion", false, true),
     cat = new CreateObject("cat", false, false),
     seagull = new CreateObject("seagull", true, false),
     chicken = new CreateObject("chicken", false, false),
     dog = new CreateObject("dog", false, false),
     pigeon = new CreateObject("pigeon", true, false),
     giraffe = new CreateObject("giraffe", false, false),
     tit = new CreateObject("tit", true, true),
     bull = new CreateObject("bull", false, true),
     bear = new CreateObject("bear", false, true),
     array = [lion, cat, seagull, chicken, dog, pigeon, giraffe, tit, bull, bear],
     button = document.getElementById("all_names"),
     changes = document.getElementsByName("changes"),
     text = document.getElementById("all_text"),
     flag = false,
     string1;
    function checkboxChecked() {
        var j;
        string1 = "";
        if (flag) {
            if (changes[0].checked || changes[1].checked) {
                if (changes[0].checked && changes[1].checked) {
                    for (j = 0; j < array.length; j++) {
                        if (!array[j].dangerous && array[j].fly) {
                            string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                        }
                    }
                }
                else {
                    if (changes[0].checked) {
                        for (j = 0; j < array.length; j++) {
                            if (array[j].fly) {
                                string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                            }
                        }
                    }
                    if (changes[1].checked) {
                        for (j = 0; j < array.length; j++) {
                            if (!array[j].dangerous) {
                                string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                            }
                        }
                    }
                }
                text.innerHTML = string1;
            }
            else {
                for (j = 0; j < array.length; j++) {
                    string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                }
                text.innerHTML = string1;
            }
        }
    }
    function writeOllText() {
        if (flag) {
            text.innerHTML = "";
            flag = false;
        }
        else {
            flag = true;
            checkboxChecked();
        }
    }
    document.getElementById("notDangerous").onclick = function () {
        checkboxChecked();
    };
    document.getElementById("fly").onclick = function () {
        checkboxChecked();
    };
    if (window.addEventListener) {
        button.addEventListener("click", writeOllText, true);
    }
    else {
        if (window.attachEvent) {
            button.attachEvent("onclick", writeOllText);
        }
    }
};