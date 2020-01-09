//展开菜单
$("body").on("click", ".nav-list>li>a:not(:only-child)", function () {
    var child = $(this).siblings(".nav-list-child");
    var status = child.css("display");
    if (status == "block")
        child.css("display", "none");
    else
        child.css("display", "block");
});
//菜单点击
$("body").on("click", ".nav-list li>a:only-child", function () {
    var menuid = $(this).data("id");
    if ($("li[data-id='" + menuid + "']").length) {
        $("iframe").hide();
        $("#iframe" + menuid).show();

        $("ul[class=tabs]>li").removeClass("tab-selected");
        $("li[data-id='" + menuid + "']").addClass("tab-selected");
        return;
    }
    var tab = $(".page-tabs .tabs");
    var tab_text = $(this).text();
    var html = '<li data-id="' + menuid + '">\
                            <a href="javascript:;">' + tab_text + '</a>\
                            <span class="tab-close">&times;</span>\
                        </li>'
    tab.append(html);

    var url = $(this).attr("data-url");
    var iframe = "<iframe frameborder='0' style='width:100%;' onload='this.height = this.contentWindow.document.documentElement.scrollHeight' id='iframe" + menuid + "' src='" + url + "'></iframe>";
    $("iframe").hide();
    $("[class=tab-selected]").removeClass("tab-selected");
    $("li[data-id=" + menuid + "]").addClass("tab-selected");
    $(".content").append(iframe);

});
//鼠标经过显示关闭按钮
$("body").on("mouseenter", "ul[class=tabs] li", function () {
    $(this).find("span[class=tab-close]").show();
});
$("body").on("mouseleave", "ul[class=tabs] li", function () {
    $(this).find("span[class=tab-close]").hide();
});
//禁止tab内的文本被选中
$("body").on("selectstart", "ul[class=tabs] li", function () {
    return false;
});
//关闭tab
$("body").on("click", "span[class=tab-close]", function () {
    var tabid = $(this).closest("li").data("id");
    var iframeid = "iframe" + tabid;
    $("#" + iframeid).remove();
    $(this).closest("li").remove();
    var tabs = $("ul[class=tabs]>li");

    if (tabs.eq(0).length) {
        tabs.removeClass("tab-selected");
        tabs.eq(0).addClass("tab-selected");

        $("iframe").hide();
        $("#iframe" + tabs.eq(0).data("id")).show();
        return false;
    }
});
//tab切换
$("body").on("click", "ul[class=tabs] li", function () {
    $("ul[class=tabs]>li").removeClass("tab-selected");
    $(this).addClass("tab-selected");

    $("iframe").hide();
    $("#iframe" + $(this).data("id")).show();
});
//分页选择PageSize
$("body").on("change", ".pagination li select", function () {
    alert($(this).text());
});
//全选
$("body").on("click", "#all", function () {
    var check_all = $(this);
    var checkboxs = $("[data-checkall='all']");

    if (check_all.prop("checked")) {
        checkboxs.prop("checked", true);
    } else {
        checkboxs.prop("checked", false);
    }
});
//反选
$("body").on("click", "#reverse", function () {
    var selectedBox = $("[data-reverse='reverse']:checked");
    var uselectedBox = $("[data-reverse='reverse']:not(:checked)");
    selectedBox.prop("checked", false);
    uselectedBox.prop("checked", true);
})