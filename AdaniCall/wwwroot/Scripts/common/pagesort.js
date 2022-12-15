
function setArrow() {
    var sort = $("#hdnSortOrder").val().trim().toLowerCase();
    var col = $("#hdnSortColumn").val().trim().toLowerCase();

    if (sort == "asc")
        $("#col_" + col).append('<i class="fa fa-caret-down pull-right sort-arrow"></i>');
    else
        $("#col_" + col).append('<i class="fa fa-caret-up pull-right sort-arrow"></i>');
}

$(document).on("click", ".table th", function () {
    var col = $(this).attr("id");
    col = col.substring(4, col.length);

    switch (col) {
        case "activedeactive":
        case "editdeleterecords":
        case "recharge":
            break;
        default:
            search($("#Search").val().trim(), col, $("#hdnSortOrder").val().trim(), $("#hdnPage").val().trim(), $("#hdnSize").val().trim(), 'sort', false, listtype);
            $("#hdnSortColumn").val(col);
            break;
    }

    return false;
});

$(document).on("click", ".pagination-container a", function () {

    if ($(this).attr("href")) {
        var pgno = "1";
        var sParameterName = $(this).attr("href").split('=');
        if (isNaN(sParameterName[1])) {
            sParameterName = sParameterName[1].split('&');
            pgno = sParameterName[0];
        }
        else
            pgno = sParameterName[1];

        search($("#Search").val().trim(), $("#hdnSortColumn").val().trim(), $("#hdnSortOrder").val().trim(), pgno, $("#hdnSize").val().trim(), 'paging', false, listtype);
    }
    return false;
});


$(document).ready(function () {
    setArrow();
    //resizeListView('ddlColumns', 'tblList');
});

function changePageSize() {
    var size = $("#ddlPageSize option:selected").val();
    if (size == undefined || size == "")
        size = "10";
    $("#hdnSize").val(size);
    go('size');
}

function go(flag) {
    if (flag == undefined)
        flag = 'search';

    var isLoad = false;
    if (flag == '-1')
        isLoad = true;
    search($("#Search").val().trim(), $("#hdnSortColumn").val().trim(), $("#hdnSortOrder").val().trim(), $("#hdnPage").val().trim(), $("#hdnSize").val().trim(), flag, isLoad, listtype);
}