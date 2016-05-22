var iCheap = {};
(function(){
    var NameSpace = iCheap;
    //NameSpace.j = $.noConflict();
    NameSpace.IsInt = function(value) {
        return !isNaN(value) &&
			parseInt(Number(value)) == value &&
			!isNaN(parseInt(value, 10));
    };

    NameSpace.SayHello = function(){
        alert('Hello world');
    };
})();