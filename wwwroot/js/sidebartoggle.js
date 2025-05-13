$(document).ready(function() {
    $("#menu_toggle").click(function() {
        var icon = $("#icon").hasClass("hidden"); // true
        var logo = $("#logo").hasClass("hidden"); // false

        if (icon == true) {
            $("#logo").addClass("hidden");
            $("#icon").removeClass("hidden");
        } else {
            $("#icon").addClass("hidden");
            $("#logo").removeClass("hidden");
        }

    });
});