window.onload = function () {
    var labels = document.getElementsByTagName('label'),
    inputs = document.getElementsByName("inputs"),
    watermark = ["", "Введите E-mail", "", "+XX (XXX) XXX-XX-XX", "day-month-year"],
    i, pattern, error;
    for (i = 0; i < inputs.length; i++) {
        if (inputs[i].type === "text") {
            inputs[i].value = "";
        }
    }
    function watermarks(elemt, text) {
        elemt.onblur = function () {
            if (elemt.value === "") {
                elemt.value = text;
                elemt.style.color = "gray";
                elemt.style.fontStyle = "italic";
            }
        };
        elemt.onfocus = function () {
            if (elemt.value === text) {
                elemt.value = "";
                elemt.style.color = "black";
                elemt.style.fontStyle = "normal";
            }
        };
    }
    function validate(elem, pattern, err, nameError) {
        var res = elem.value.search(pattern);
        if (res === -1) {
            elem.className = "invalid";
            nameError.innerHTML = err;
        }
        else {
            elem.className = "valid";
            nameError.innerHTML = "";
        }
    }
    function nameOnChange() {
        pattern = /^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9-_\.]{1,20}$/;
        error = "Могут быть буквы и цифры, первый символ обязательно буква, и обязательно больше одного символа в строке";
        validate(this, pattern, error, labels[0]);
    }
    function emailOnChange() {
        pattern = /^[\w.]+@([A-z0-9][A-z0-9]+\.)+[A-z]{2,4}$/;
         error = "Введите Ваш адрес электронной почты. Допустимо использовать только латинские буквы и цифры.";
        validate(this, pattern, error, labels[1]);
        watermarks(this, watermark[1]);
    }
    function passwordOnChange() {
        pattern = /\S{6,24}/;
         error = "Пароль может содержать от 6 до 24 символов.";
        validate(this, pattern, error, labels[2]);
    }
    function phoneOnChange() {
        pattern = /\+38 \(\d{3}\) \d{3}-\d{2}-\d{2}/;
        error = "Возможно зарегистрироваться только мобильным номером телефона, состоящим из 12 цифр.<br /> +XX (XXX) XXX-XX-XX";
        validate(this, pattern, error, labels[3]);
        watermarks(this, watermark[3]);
    }
    function birthdayOnChange() {
        pattern = /\d{1,2}-\d{1,2}-\d{4}/;
        error = "Дата введена не верно day-month-year";
        validate(this, pattern, error, labels[4]);
        watermarks(this, watermark[4]);
    }
    function checkButtonHandler() {
        var invalid = false,
        j, e;
        for (j = 0; j < inputs.length; ++j) {
            e = inputs[j];
            if (e.onchange) {
                e.onchange();
                if (e.className === "invalid") {
                    invalid = true;
                }
            }
        }
        if (invalid) {
            alert("Допущены ошибки при заполнении формы.");
            return false;
        }
    }
    document.getElementById("userName").onchange = nameOnChange;
    document.getElementById("email").onchange = emailOnChange;
    document.getElementById("password").onchange = passwordOnChange;
    document.getElementById("phone").onchange = phoneOnChange;
    document.getElementById("birthday").onchange = birthdayOnChange;
    document.getElementById("checkButton").onclick = checkButtonHandler;
};