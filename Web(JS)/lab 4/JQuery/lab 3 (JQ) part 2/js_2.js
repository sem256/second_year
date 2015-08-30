$(function () {
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
     text = document.getElementById("all_text"),
     array = [lion, cat, seagull, chicken, dog, pigeon, giraffe, tit, bull, bear],
     flag;

    
    function showList() {
        var j,
         string1 = "",
         checked1 = $("#canFly").is(":checked"),
         chacked2 = $("#notDangerous").is(":checked");
        if (flag) {
            if (checked1 || chacked2) {
                if (checked1 && chacked2) {
                    for (j = 0; j < array.length; j++) {
                        if (array[j].fly && !array[j].dangerous) {
                            string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                        }
                    }
                    text.innerHTML = string1;
                }
                else {
                    if (checked1) {
                        for (j = 0; j < array.length; j++) {
                            if (array[j].fly) {
                                string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                            }
                        }
                    }
                    if (chacked2) {
                        for (j = 0; j < array.length; j++) {
                            if (!array[j].dangerous) {
                                string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                            }
                        }
                    }
                    text.innerHTML = string1;
                }
            }
            else {
                for (j = 0; j < array.length; j++) {
                    string1 += array[j].title + " (fly: " + array[j].fly + " dangerous: " + array[j].dangerous + " )" + "<br />";
                }
                text.innerHTML = string1;
            }
        }
    }
    function show() {
        if (flag) {
            flag = false;
            text.innerHTML = "";
        }
        else {

            flag = true;
            showList();

        }
    }
    $("#all_names").click(show);
    $("#canFly").click(showList);
    $("#notDangerous").click(showList);
});