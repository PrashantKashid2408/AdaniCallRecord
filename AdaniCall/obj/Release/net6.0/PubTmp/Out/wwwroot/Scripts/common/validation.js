function digitsOnly(value) {
    //debugger;
    return /^[0-9]+$/.test(value);
}

//Method allows to enter only digits 
//use it onkeypress of input eg.  <input type="text" id="txtChar" onkeypress="return numbersOnly(event)" />
function numbersOnly(e) {
    var unicode = e.charCode ? e.charCode : e.keyCode;
    if (unicode != 8 && unicode != 9) { 
        if (unicode < 48 || unicode > 57) //if not a number
            return false; //disable key press
    }
}

function excludeCharsOnly(e) {
    var c = e.which;
    if (c != 8 && c != 9) {
        if (c >= 65 && c <= 90 || c >= 97 && c <= 122)
            return false;
    }
}

function urlOnlyRW(url) {
    var re = /^(http[s]?:\/\/){0,1}(www\.){0,1}[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,5}[\.]{0,1}/;
    if (!re.test(url)) {
        return false;
    }
    return true;
}

//allowed chars : a-z, A-Z, 0-9, (space) and - 
function isbnOnly(e) {
    var c = e.which;
    if (c != 8 && c != 9) {
        if (c == 0 || c == 32 || c == 43 || c == 45 || (c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122))
            return true;
        else
            return false;
    }
}

function filenamesOnly(e) {
    var unicode = e.charCode ? e.charCode : e.keyCode;
    var res = !0;
    switch (unicode) {
        case 92:
        case 47:
        case 58:
        case 42:
        case 63:
        case 34:
        case 60:
        case 62:
        case 124:
            res = !1;
            break;
    }
    return res;
}

function getValidFilename(input) {
    if (input) {
        input = input.replace(/([*+?:|\/\\\"])/g, '');
        return input;
    }
}

//removes all spaces and special characters from input and returns result
function trimSpecial(input) {
    if (input) {
        input = input.replace('/ /g', '').replace(/[^\w]/gi, '');
        return input;
    }
}

function replaceIsbnSpecial(input) {
    if (input) {
        //allow alphanumeric with hyphen only
        input = input.replace(/ /g, '').replace(/[^\w-+]|_/g, '');
        return input;
    }
}

function replaceUsernameSpecial(input) {
    if (input) {
        //allow alphanumeric with - _ @ . only
        input = input.replace(/ /g, '').replace(/[^a-zA-Z0-9-_@.]/g, '');
        return input;
    }
}

function emailOnly(val) {
    return /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(val);
}

//returns false if val contains characters other than [A-Za-z0-9-_@.]
function usernameOnly(val) {
    return /^[A-Za-z0-9-_@.]+$/.test(val);
}

function alphaOnly(val) {
    return /^[A-Za-z]+$/.test(val);
}

//function pageRangeOnly(val) {
//    var p = new RegExp("^(\\s*\\d+\\s*\\-\\s*\\d+\\s*,?|\\s*\\d+\\s*,?)+$");
//    return p.test(val);
//}
function OnlyNumeric(val)
{
    var numeric = true;
    var chars = "0123456789-+";
    var len = val.length;
    var char = "";
    for (i = 0; i < len; i++) { char = val.charAt(i); if (chars.indexOf(char) == -1) { numeric = false; } }
    return numeric;
}


function percentOnly(val) {
    var r = !1;
    if (val) {
        val = val.toString();
        var p = val.indexOf('.') > -1 || val.indexOf('e') > -1 || val.indexOf('+') > -1 || isNaN(val.replace(/%/g, '')) ? 0 : parseInt(val);
        if (p > 0 && p <= 100)
            r = !0;
    }
    return r;
}

function hasWhiteSpace(s) {
    return /\s/g.test(s);
}

function urlOnly(url) {
    //var re = /^(?:(?:https?|ftp):\/\/)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/[^\s]*)?$/i;
    //var re = /^(http[s]?:\/\/){0,1}(www\.){0,1}[a-zA-Z0-9\.\-]+\.[a-zA-Z]{2,5}[\.]{0,1}/;
    var re = /^(http|https|ftp):\/\/[A-Za-z0-9]+([\-\.]{1}[A-Za-z0-9]+)*\.[A-Za-z]{2,5}(:[0-9]{1,5})?(\/.*)?$/i;
    return re.test(getValidUrl(url));
}

function getValidUrl(url) {
    if (url) {
        url = url.trim();
        if (url.indexOf('.') > -1 && url.length > 4 && url.toLowerCase().substring(0, 4) != "http")
            url = 'http://www.' + (url.toLowerCase().substring(0, 4) == "www." ? url.replace(/www./i, '') : url);
    }
    return url;
}

//To check if data entered is numeric, if non numeric data entered some how.
function isNumeric(val) {
    var numeric = true;
    var chars = "0123456789.-,+";
    var len = val.length;
    var char = "";
    for (i = 0; i < len; i++) { char = val.charAt(i); if (chars.indexOf(char) == -1) { numeric = false; } }
    return numeric;
}

function isNumeric(val) {
    var numeric = true;
    var chars = "0123456789.-,+";
    var len = val.length;
    var char = "";
    for (i = 0; i < len; i++) { char = val.charAt(i); if (chars.indexOf(char) == -1) { numeric = false; } }
    return numeric;
}

function is10DigitPhone(val) {
    var numeric = true;
    var chars = "0123456789";
    var len = val.length;
    var char = "";
    if (len == 10) {
        for (i = 0; i < len; i++) { char = val.charAt(i); if (chars.indexOf(char) == -1) { numeric = false; } }
    }
    else
        numeric = false;
    return numeric;
}

//To check the no. of occurences of specific character in string
function getOccurences(input, letter) {
    if (input == undefined || letter == undefined || input == null || letter == null) 
        return 0;
    if (input.indexOf(letter) != -1)
        return input.match(new RegExp('\\' + letter, 'g')).length;
    else
        return 0;
}

function nameOnly(x) {
    return /^[A-Za-z'".,_-\s]+$/.test(x);
}

function isPageRange(range) {
    var f = true;
    if (range) {
        if (range.replace(/,/g, '').trim() != "") {
            range = range.toString().trim().split(',');
            var arr = [];
            for (var i = 0; i < range.length; i++) {
                var val = range[i].trim().split('-');
                for (var j = 0; j < val.length; j++) {
                    arr.push(val[j].trim());
                }
            }
            for (var i = 0; i < arr.length; i++) {
                if (isNaN(arr[i]) ||
                    arr[i].toString().indexOf('.') > -1 ||
                    arr[i].toString().indexOf('+') > -1 ||
                    arr[i].toString().indexOf('e') > -1 ||
                    arr[i] <= 0 ||
                    arr[i] > LengthConstants.PAGE_RANGE_MAX_VAL) {
                    f = false;
                    break;
                }
            }
        }
        else
            f = false;
    }
    else
        f = false;
    return f;
}

//$.validator.addMethod("phonecheck",
//    function (value) {
//        return phonecheckfn(value);
//    }
//);

function phonecheckfn(value) {
    return /^(1\s|1|)?((\(\d{3}\))|\d{3})(\-|\s)?(\d{3})(\-|\s)?(\d{4})$/.test(value);
}