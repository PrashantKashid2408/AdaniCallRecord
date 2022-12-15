/// <reference path="../../Common/global.js" />

function changeStatus(obj, id, action, type) {
    if (obj) {
        //BootstrapDialog.confirm(__confirmMessage, function (result) {
        //    if (result) {
                $("#divLoader").append(getLoader());
                $.ajax({
                    url: changeStatusUrl,
                    data: JSON.stringify({ ID: id, StatusID: action, type: type }),
                    type: "POST",
                    cache: false,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data != null) {
                            removeLoader("#divLoader");
                            if (data.IsSuccess) {
                                if (data.Message!="")
                                    showBSAlert(data.MessageCaption, data.Message, __SUCCESS);
                                var onclick = "changeStatus(this,'" + id + "','0')";
                                if (action == '0') {
                                    onclick = "changeStatus(this,'" + id + "','1')";
                                }
                                $(obj).attr("onclick", "");
                                $(obj).attr("data-toggle", "");
                                $(obj).removeAttr("data-original-title");
                                $(obj).attr("onclick", onclick);
                                $(obj).siblings().attr("title", "");
                                $(obj).siblings().attr("data-toggle", "tooltip");
                                $(obj).siblings().attr("class", "btn-fa-addCustom");

                                if (action == '1') {
                                    $(obj).attr("class", "btn-fa-addCustom bg-green");
                                    $(obj).attr("data-original-title", __deActivate);
                                    $(obj).children().attr("class", "fa fa-unlock");
                                    $(obj).next().hide();
                                }
                                else {
                                    if ($(obj).attr("id") == "DeActive") {
                                        $(obj).prev().hide();
                                    }
                                    $(obj).attr("class", "btn-fa-addCustom bg-red");
                                    $(obj).attr("data-original-title", __activate);
                                    $(obj).children().attr("class", "fa fa-lock");
                                }
                                $('[data-toggle="tooltip"]').tooltip();
                            }
                        }
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        removeLoader("#divLoader");
                    }
                });
        //    }
        //});
    }
}

function search(query, sortColumn, sortOrder, page, size, flag, ISLOAD, lsttype) {
    $("#divLoader").append(getLoader());
    $.ajax({
        url: searchUrl,
        data: JSON.stringify({ query: query, sortColumn: sortColumn, sortOrder: sortOrder, page: page, size: size, flag: flag, ISLOAD: ISLOAD, ListType: lsttype }),
        type: "POST",
        cache: false,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            removeLoader("#divLoader");
            if (result != null) {
                $("#dvCommon").empty();
                $("#dvCommon").html(result);
                if ($(window).width() > 768)
                    $("#Search").focus();
            }
            setArrow();
            //resizeListView('ddlColumns', 'tblList');
            $("#ddlColumns").val(selectValue);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            removeLoader("#divLoader");
        }
    });
}

