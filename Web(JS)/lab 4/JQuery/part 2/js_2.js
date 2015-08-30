$(function () {
    $("#button").click(function () {
        var div1 = $("#block1"),
            div2 = $("#block2"),
            div3 = $("#block3");
        div1.animate({ height: '300px', opacity: '0.4' }, "slow");
        div1.animate({ width: '300px', opacity: '0.8' }, "slow");
        div1.animate({ height: '100px', opacity: '0.4' }, "slow");
        div1.animate({ width: '100px', opacity: '0.8' }, "slow");

        div2.animate({ fontSize: '4em' }, "slow");
        div2.animate({ fontSize: '2em' }, "slow");

        div3.animate({ left: "500px" });
        div3.animate({ left: "10px" });
    });
});