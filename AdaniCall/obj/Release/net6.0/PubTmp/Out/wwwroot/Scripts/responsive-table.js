var selectValue = "2";
var tableResize = true;
var tableResizeBibletCredit = true;
var currSelectName = "";
var currTableName = "";

var currBibletCreditSelectName = "";
var currBibletCreditTableName = "";

(function ($, sr) {
    var debounce = function (func, threshold, execAsap) {
        var timeout;
        return function debounced() {
            var obj = this, args = arguments;
            function delayed() {
                if (!execAsap)
                    func.apply(obj, args);
                timeout = null;
            };
            if (timeout)
                clearTimeout(timeout);
            else if (execAsap)
                func.apply(obj, args);

            timeout = setTimeout(delayed, threshold || 100);
        };
    }
    jQuery.fn[sr] = function (fn) { return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };

})(jQuery, 'smartresize');

$(window).smartresize(function (e) {
    resizeListView(currSelectName, currTableName);
    console.log("$(window).smartresize(): Current dropdown list: " + currSelectName + " :: Current table name: " + currTableName);

    resizeBibletCreditListView(currBibletCreditSelectName, currBibletCreditTableName);
});

function hideTableCol(obj, tableName) {
    selectValue = $(obj).val();
    $("#" + tableName).find(".hideCol2, .hideCol").not($(".hideHideCol_" + selectValue).css({ "display": "table-cell" })).css("display", "none");
    tableResize = false;    
}

function hideBibletCreditTableCol(obj, tableName) {
    selectValue = $(obj).val();
    $(".tblBibletCreditPackages").find(".hideCol2, .hideCol").not($(".tblBibletCreditPackages").find(".hideHideCol_" + selectValue).css({ "display": "table-cell" })).css("display", "none");
    tableResizeBibletCredit = false;
}

function resizeListView(selectName, tableName) {
    console.log("Table name from current table: " + tableName);

    currSelectName = selectName;
    currTableName = tableName;

    console.log("resizeListView(): Current Sel Name: " + currSelectName + " :: " + "Current Table Name: " + currTableName);

    if ($(window).width() <= 768) {

        console.log("Mobile Table View");

        $("#" + selectName).css("display", "block");
        $(".label-column").css("display", "block");

        if (!tableResize) {
            $("#" + tableName).find(".hideCol2, .hideCol").not($(".hideHideCol_" + selectValue).css({ "display": "table-cell" })).css("display", "none");            
        }            
        else {
            $(".hideCol").hide();
            $(".hideCol2").show();
            tableResize = true;            
        }
    }
    else {
        console.log("Desktop Table View");
        $("#" + selectName).css("display", "none");
        $(".label-column").css("display", "none");
        $(".hideCol2").show();
        $(".hideCol").removeAttr("style").end().show();
    }
}

function resizeBibletCreditListView(selectName, tableName) {
    currBibletCreditSelectName = selectName;
    currBibletCreditTableName = tableName;
    if ($(window).width() <= 768) {

        console.log("Biblet Credit Mobile Table View");

        $("#" + selectName).css("display", "block");
        $(".label-column").css("display", "block");

        if (!tableResizeBibletCredit) {
            $(".tblBibletCreditPackages").find(".hideCol2, .hideCol").not($(".tblBibletCreditPackages").find(".hideHideCol_" + selectValue).css({ "display": "table-cell" })).css("display", "none");
        }
        else {
            $(".tblBibletCreditPackages").find(".hideCol").hide();
            $(".tblBibletCreditPackages").find(".hideCol2").show();
            tableResizeBibletCredit = true;
        }
    }
    else {

        console.log("Biblet Credit Desktop Table View");

        $("#" + selectName).css("display", "none");
        $(".label-column").css("display", "none");
        $(".tblBibletCreditPackages").find(".hideCol2").show();
        $(".tblBibletCreditPackages").find(".hideCol").removeAttr("style").end().show();
    }
}

//admin.js start

function scrollActPubAutCumm() {
    var windowSize = $(window).width();
    //OLD for Pup, Comm and Aut - if (windowSize <= 1380 && windowSize > 992) {
    //New for Pup, Comm, Aut and Trial Pub
    if (windowSize <= 1660 && windowSize > 992) {
        var bodyWidth = $("body").width() - 255;
        $(".divPublisherTable").css("width", bodyWidth + "px");
        $(".divCommunityTable").css("width", bodyWidth + "px");
        $(".divAuthorsTable").css("width", bodyWidth + "px");
        //console.log("Big");
    }
    else if (windowSize <= 992 && windowSize > 769) {
        var bodyWidth = $("body").width() - 30;
        $(".divPublisherTable").css("width", bodyWidth + "px");
        $(".divCommunityTable").css("width", bodyWidth + "px");
        $(".divAuthorsTable").css("width", bodyWidth + "px");
        //console.log("Medium");
    }
    else {
        $(".divPublisherTable").removeAttr("style");
        $(".divPublisherTable").css("left", "none");

        $(".divCommunityTable").removeAttr("style");
        $(".divCommunityTable").css("left", "none");

        $(".divAuthorsTable").removeAttr("style");
        $(".divAuthorsTable").css("left", "none");
        //console.log("Small");
    }

    //var wh = $(window).height() - 310;
    //$(".divPublisherTable").css("height", wh + "px");
    //$(".divCommunityTable").css("height", wh + "px");
    //$(".divAuthorsTable").css("height", wh + "px");
}

function assignedbibletFilter() {
    $(".assigned-bib-filter").find("tbody tr").bind("click", function () {
        $(".assigned-bib-filter").find(this).toggleClass("report-toggle-class");

        //if ($(".assigned-bib-filter").hasClass("trToggleSel")) {
            //$(".assigned-bib-filter").find(this).removeClass("trToggleSel");
        //}

        //if ($(".assigned-bib-filter").hasClass("trToggle")) {
            //$(".assigned-bib-filter").find(this).removeClass("trToggle");
        //}

        //if (!$(this).hasClass("report-toggle-class")) {
        //    setTimeout(function () {
        //        console.log("start2");
        //        $("#btnUnAssign").attr("class", "btn btn-primary disabled");
        //        $("#nxtUnassigned").attr("class", "btn btn-primary disabled");
        //        console.log("start3");
        //    }, 500);
        //}
    });
}

function assignedbibletAuthorFilter() {
    $(".reassign-biblet-author").find("tbody tr").on("click", function () {
        //console.log("start");

        var currentAuthorID = $(".reassign-biblet-author").find(this).attr("id");
        //console.log(currentAuthorID);
        $(".reassign-biblet-author").find("tbody tr").not($("#" + currentAuthorID).addClass("toggle-class")).removeClass("toggle-class");
        //console.log("finish");
    });
}

$(window).resize(function () {
    scrollActPubAutCumm();
});

$(document).ready(function (e) {
    assignedbibletFilter();
    assignedbibletAuthorFilter();
    scrollActPubAutCumm();
});

//admin.js end