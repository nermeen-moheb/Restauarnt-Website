// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function plus( cartItemId) {
    console.log("sha8al");
    var quantityElement = $(this).siblings(".text-grey");
    var quantity = parseInt(quantityElement.text());
    quantity++;
    quantityElement.text(quantity);
    window.location.href = '/Cart/PlusCartItem?cartItemId=' + cartItemId;
}

function minus(cartItemId) {
    console.log("sha8al miii");
    var quantityElement = $(this).siblings(".text-grey");
    var quantity = parseInt(quantityElement.text());
    quantity--;
    quantityElement.text(quantity);
    console.log("sha8al miii");
    window.location.href = '/Cart/MinusCartItem?cartItemId=' + cartItemId;
}
    function Delete(cartItemId) {
        console.log("sha8al miii");
        var quantityElement = $(this).siblings(".text-grey");
        var parentt = quantityElement.parentElement;
   

        console.log("sha8al miii");
        window.location.href = '/Cart/DeleteCartItem?cartItemId=' + cartItemId;
        parentt.remove();
    };