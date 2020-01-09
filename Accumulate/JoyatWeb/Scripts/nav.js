$(function () {
    var path = window.location.pathname;
    $(".nav.nav-pills").find("li").removeClass("active");
    $("a[href='" + path + "']").parent().addClass("active");
});