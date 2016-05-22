// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
(function () {
    var NameSpace = iCheap || {};
    
    NameSpace.Cart = new NameSpace.CartViewModel();
    NameSpace.Cart.AddItem();
    // Activates knockout.js
    ko.applyBindings(iCheap);
})();