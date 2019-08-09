$(function () {
    $('[data-admin-menu]').hover(function () {// Hover is when the mouse is on the item 
        $('[data-admin-menu]').toggleClass('open');
    })// It will toggle the class on the hover property, whan we hover the menu it will toggle it
});