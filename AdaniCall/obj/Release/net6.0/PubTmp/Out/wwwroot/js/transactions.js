function GetAnalysis(id) {
    //window.location.href = "/Transactions/GetAnalysis?ID=" + id;
    $.ajax({
        url: '/Transactions/GetAnalysis',
        data: JSON.stringify({ ID: id }),
        type: "POST",
        cache: false,
        async: false,
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            BootstrapDialog.show({
                id: "divAnalysis",
                title: "Analysis",
                size: BootstrapDialog.SIZE_WIDE,
                message: function () {
                    var $message = $('<div class="File-droppable box pTB10-LR05" style = "height: ' + $(window).height() * 0.8 + 'px; overflow:auto; padding-right:20px;"></div>');
                    $message.append(result);
                    return $message;
                },
                closeByBackdrop: true,
                closable: true,
            });
        },
        error: function (xhr, ajaxOptions, thrownError) {
        }
    });
}