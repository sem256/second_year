$(function () {
    function validationE(check, user, elements, lable, error) {
        if (user.search(check) === -1) {
            elements.css({ "background-color": "#FF6473" });
            lable.innerHTML = error;
        }
        else { elements.css({ "background-color": "#ABFF87" }); }
    }
    var array = [/^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9-_\.]{1,20}$/,
            /^[\w.]+@([A-z0-9][A-z0-9]+\.)+[A-z]{2,4}$/,
             /\S{6,24}/,
             /\+38 \(\d{3}\) \d{3}-\d{2}-\d{2}/,
              /\d{1,2}-\d{1,2}-\d{4}/
    ],
    mass = [$("#userName"), $("#email"), $("#password"), $("#phone"), $("#birthday")],
    errors = [ "Могут быть буквы и цифры, первый символ обязательно буква, и обязательно больше одного символа в строке",
    "Введите Ваш адрес электронной почты. Допустимо использовать только латинские буквы и цифры.",
     "Пароль может содержать от 6 до 24 символов.",
     "Только мобильным номером телефона, состоящим из 12 цифр.<br /> +XX (XXX) XXX-XX-XX",
     "Дата введена не верно day-month-year"];
    $("#email").blur(function () {
        validationE(array[1], $(this).val(), $(this), $(".positionText")[1], errors[1]);
    });
    $("#userName").blur(function () {
        validationE(array[0], $(this).val(), $(this), $(".positionText")[0], errors[0]);
    });
    $("#password").blur(function () {
        validationE(array[2], $(this).val(), $(this), $(".positionText")[2], errors[2]);
    });
    $("#phone").blur(function () {
        validationE(array[3], $(this).val(), $(this), $(".positionText")[3], errors[3]);
    });
    $("#birthday").blur(function () {
        validationE(array[4], $(this).val(), $(this), $(".positionText")[4], errors[4]);
    });
    function show() {
        var i, flag;
        for (i = 0; i < mass.length; i++) {
            if (mass[i].val().search(array[i]) === -1) {
                mass[i].css({ "background-color": "#FF6473" });
                $(".positionText")[i].innerHTML = errors[i];
                flag = true;
            }
            else {
                mass[i].css({ "background-color": "#ABFF87" });
                flag = false;
            }
        }
        if (flag) {
            alert("Допущены ошибки при заполнении формы.");
        }
    }
    $("#checkButton").click(show);

});