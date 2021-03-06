﻿function getRewriteUrl(s) {
    s = s.toLowerCase();
    s = s.replace(/à|á|ả|ã|ạ|â|ầ|ấ|ẩ|ẫ|ậ|ă|ằ|ắ|ẳ|ẵ|ặ/g, "a");
    s = s.replace(/è|é|ẻ|ẽ|ẹ|ê|ề|ế|ể|ễ|ệ/g, "e");
    s = s.replace(/ì|í|ỉ|ĩ|ị/g, "i");
    s = s.replace(/ò|ó|ỏ|õ|ọ|ô|ồ|ố|ổ|ỗ|ộ|ơ|ờ|ớ|ở|ỡ|ợ/g, "o");
    s = s.replace(/ù|ú|ủ|ũ|ụ|ư|ừ|ứ|ử|ữ|ự/g, "u");
    s = s.replace(/ỳ|ý|ỷ|ỹ|ỵ/g, "y");
    s = s.replace(/đ/g, "d");
    s = s.replace(/!|@|\$|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\'| |\"|\&|\#|\[|\]|~/g, "-");
    s = s.replace(/-+-/g, "-");
    s = s.replace(/^\-+|\-+$/g, "");
    
    return s;
}

function getDataCode(s) {
    s = getRewriteUrl(s);
    s = s.replace("-", "");

    return s;
}

function showMessage(t, m) {
    DevExpress.ui.notify(m, t ? 'success' : 'error', 2000);
};

function showConfirm(o) {
    var result = DevExpress.ui.dialog.confirm(o.message, o.title);

    result.done(function (dialogResult) {
        if (dialogResult)
            if(o.successCallback != null)
                o.successCallback();
        else
            if (o.cancelCallback != null)
                o.cancelCallback();
    });
};

function addCommas(str) {
    var parts = (str + "").split("."),
        main = parts[0],
        len = main.length,
        output = "",
        first = main.charAt(0),
        i;
    
    if (first === '-') {
        main = main.slice(1);
        len = main.length;    
    } else {
    	  first = "";
    }
    i = len - 1;
    while(i >= 0) {
        output = main.charAt(i) + output;
        if ((len - i) % 3 === 0 && i > 0) {
            output = "." + output;
        }
        --i;
    }
    // put sign back
    output = first + output;
    // put decimal part back
    if (parts.length > 1) {
        output += "," + parts[1];
    }
    return output;
}