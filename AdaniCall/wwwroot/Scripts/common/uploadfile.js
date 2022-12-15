function showUploadDialog(path, type) {
    var strType = __Upload;
    var uniqueFileIdentifier = new Date().valueOf();
    var strFileName = uniqueFileIdentifier + "_UploadExcel";
    
    BootstrapDialog.show({
        title: __Upload + ' ' + strType.toLowerCase(),
        type: BootstrapDialog.TYPE_PRIMARY,
        message: function () {
            var $message = $('<div></div>');
            var str = '<div class="form-group">';
            str += '            <div class="btn btn-success btn-file">';
            str += '            <i class="fa fa-paperclip"></i> ' + __Search + ' ' + strType.toLowerCase();
            str += '            <input id="fuImage" type="file" name="attachment">';
            str += '        </div>';
            if (type == "xls") {
                //str += '    <p class="help-block">' + __fileExtMessage + ' ' + __XLS + ',' + __XLSX + '</p>';
                str += '    <p class="help-block">' + __fileExtMessage + ' ' + __XLS + '</p>';
            }
            else {
                str += '    <p class="help-block">' + __fileExtMessage + ' ' + __JPGandPNG + '</p>';
            }
            str += '</div>';
            $message.append(str);
            return $message;
        },
        closeByBackdrop: false,
        buttons: [
            {
                label: __Cancel,
                action: function (dialogItself) {
                    dialogItself.close();
                }
            },
            {
                label: __Submit,
                cssClass: 'btn btn-primary',
                action: function (dialog) {
                    var data = new FormData();
                    var files = $("#fuImage").get(0).files;

                    if (files.length > 0) {
                        var fileSize = Math.round(files[0].size / 1024);     //in kbs
                        var fileType = files[0].type;
                        var fileName = "";
                        if (fileType == "image/jpeg")
                            fileName = strFileName.trim() + '.jpg';
                        else if (fileType == "application/pdf") {
                            if (type == "regdoc")
                            type = "regdocpdf"
                            fileName = strFileName.trim() + '.pdf';
                        }
                        else if (fileType == "application/vnd.ms-excel")
                            fileName = strFileName.trim() + '.xls';
                        else
                            fileName = strFileName.trim() + '.png';

                        if (fileType == "application/vnd.ms-excel") {
                            data.append('FILE_UPLOAD_DELETE_EXISTING', 'false');
                            data.append('FILE_UPLOAD_KEY', 'UploadedImage');

                            data.append("FILE_UPLOAD_VIRTUAL_PATH", path);

                            //if (type == "cover" || type == "letter" || type == "letter_clinics" || type == "regdoc")
                            //    data.append('FILE_UPLOAD_FLAG', 'EXTRACT_COVER');
                            //else if (type == "logo" || type == "plogo" || type == "coverthumb")
                            //    data.append('FILE_UPLOAD_FLAG', 'EXTRACT_LOGO');
                            //else if (type == "signature")
                            //    data.append('FILE_UPLOAD_FLAG', 'EXTRACT_SIGNATURE');

                            data.append("FILE_UPLOAD_NAME", fileName);
                            data.append("UploadedImage", files[0]);
                            dialog.closable = false;

                            var strmesage = __fileExtMessage + ' ' + __JPGandPNG;
                            var isValidFileType = true;
                            
                            if (type == "regdocpdf") {
                                if (fileType != "application/pdf") {
                                    isValidFileType = false;
                                    strmesage = __fileExtMessage + ' ' + __PDF + ' ' + __JPG + ',' + __PNG;
                                }
                            }
                            else if (type == "xls" && fileType != "application/vnd.ms-excel") {
                                isValidFileType = false;
                                //strmesage = __fileExtMessage + ' ' + __XLS + ',' + __XLSX;
                                strmesage = __fileExtMessage + ' ' + __XLS;
                            }
                            else if (type != "xls" && !(fileType == "image/jpeg" || fileType == "image/png")) {
                                isValidFileType = false;
                                strmesage = __fileExtMessage + ' ' + __JPGandPNG;
                            }
                            if (isValidFileType == false) {
                                //BootstrapDialog.alert(strmesage);
                                showBSAlert(__warnCaption, strmesage, __WARNING);

                            }
                            else {
                                $(".modal-content").append($("#scriptLoader").text());
                                $(".modal-content").attr('class', 'modal-content box');

                                $.ajax({
                                    type: "POST",
                                    url: "/api/fileupload/upload",
                                    contentType: false,
                                    processData: false,
                                    data: data,
                                    success: function (response) {
                                        if (response.Data.IsSuccess) {
                                            var timestamp = "?" + new Date().getTime();
                                            if (type == "cover") {
                                                userProfile.CoverImagePath(response.Data.UploadedFilePath);
                                                $("#imgCover").attr("src", response.Data.UploadedFilePath + timestamp);
                                                $("#CoverImagePath").attr("value", response.Data.UploadedFilePathVir);
                                                $("#hdnCoverImagePathChange").attr("value", "1");
                                            }
                                            else if (type == "coverthumb") {
                                                userProfile.ImagePath(response.Data.UploadedFilePath);
                                                $("#imgLogo").attr("src", response.Data.UploadedFilePath + timestamp);
                                                $("#ImagePath").attr("value", response.Data.UploadedFilePathVir);
                                                $("#hdnImagePathChange").attr("value", "1");
                                            }
                                            else if (type == "logo") {
                                                userProfile.Profile_Logo(response.Data.UploadedFilePath);
                                                $("#imgLogo").attr("src", response.Data.UploadedFilePath + timestamp);
                                                $("#Profile_Logo").attr("value", response.Data.UploadedFilePathVir);
                                                $("#hdnProfile_LogoChange").attr("value", "1");
                                                $("#btnProfilePathDelete").removeClass('hide').addClass('show');
                                            }
                                            else if (type == "plogo") {
                                                userProfile.Profile_logo(response.Data.UploadedFilePath);
                                                $("#imgLogo").attr("src", response.Data.UploadedFilePath + timestamp);
                                                $("#Profile_logo").attr("value", response.Data.UploadedFilePathVir);
                                                $("#hdnProfile_LogoChange").attr("value", "1");
                                                $("#btnProfilePathDelete").removeClass('hide').addClass('show');
                                            }
                                            else if (type == "signature") {
                                                userProfile.Signature(response.Data.UploadedFilePath);
                                                $("#imgSignature").attr("src", response.Data.UploadedFilePath + timestamp);
                                                $("#Signature").attr("value", response.Data.UploadedFilePathVir);
                                                $("#hdnSignatureChange").attr("value", "1");
                                                $("#HeigthHeaderSignature").val("");
                                                $("#HeigthContentSignature").val("");
                                                addDrSignature();
                                                $("#btnMarkSignature").removeClass('hide').addClass('show');
                                            }
                                            else if (type == "regdoc" || type == "regdocpdf") {
                                                userProfile.UserDetails.RegistrationDocumentPath(response.Data.UploadedFilePath);
                                                if (type == "regdocpdf") {
                                                    $("#lblRegistrationDocumentPath").text(response.Data.UploadedFilePathVir.replace('/ALLContent/Temp/', ''))
                                                    $("#imgRegistrationDocument").attr("src", "");
                                                    $("#imgRegistrationDocument").attr("class", "hide");
                                                    $("#imgRegistrationDocument").addClass("hide")
                                                    $("#lblRegistrationDocumentPath").removeClass("hide")
                                                    $("#lblRegistrationDocumentPath").show();
                                                    $("#btnRegistrationDocumentDelete").removeClass('hide').addClass('show');
                                                }
                                                else {
                                                    $("#imgRegistrationDocument").attr("src", response.Data.UploadedFilePath + timestamp);
                                                    $("#lblRegistrationDocumentPath").hide();
                                                    $("#lblRegistrationDocumentPath").addClass("hide")
                                                    $("#imgRegistrationDocument").attr("class", "");
                                                    $("#imgRegistrationDocument").removeClass("hide");
                                                    $("#btnRegistrationDocumentDelete").removeClass('hide').addClass('show');
                                                }
                                                $("#RegistrationDocumentPath").attr("value", response.Data.UploadedFilePathVir);
                                                $("#hdnRegistrationDocumentChange").attr("value", "1");
                                            }
                                            else if (type == "xls") {
                                                $("#lblUploadExcelPath").text(response.Data.UploadedFilePathVir.replace('/ALLContent/Temp/', ''))
                                                $("#imgUploadExcel").attr("src", "");
                                                $("#imgUploadExcel").attr("class", "hide");
                                                $("#imgUploadExcel").addClass("hide")
                                                $("#lblUploadExcelPath").removeClass("hide")
                                                $("#lblUploadExcelPath").show();
                                                $("#btnUploadExcelDelete").removeClass('hide').addClass('show');
                                                $("#UploadExcelPath").attr("value", response.Data.UploadedFilePathVir);
                                                $("#hdnUploadExcelChange").attr("value", "1");
                                            }
                                            
                                            $(".modal-content").attr('class', 'modal-content');
                                            $(".modal-content").find(".overlay, .loading-img").remove();
                                            dialog.closable = true;
                                            dialog.close();
                                        }
                                        else
                                        {
                                            $(".modal-content").removeClass('box')
                                            showBSAlert(__warnCaption, __fileErrMessage + ' ' + __fileExtMessage + ' ' + __XLS, __WARNING);
                                            dialog.close();
                                        }
                                    },
                                    error: function (xhr, ajaxOptions, thrownError) {
                                        console.log(xhr.error().statusText);
                                    }
                                });
                            }
                        }
                        else {
                            //BootstrapDialog.alert(__fileErrMessage);
                            showBSAlert(__errCaption, __fileErrMessage + ' ' + __fileExtMessage + ' ' + __XLS, __DANGER);
                        }                            
                    }
                    else {
                        //BootstrapDialog.alert(__reqFile);
                        showBSAlert(__warnCaption, __reqFile, __WARNING);
                    }
                }
            }]
    });
    
}
