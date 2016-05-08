var test = function(a, b){
    return a + b;
}

jQuery.fn.extend({
    test: function (a, b) {
        var text = a + b;

        $(this).html(['Value is ', text].join(''));
    }
});