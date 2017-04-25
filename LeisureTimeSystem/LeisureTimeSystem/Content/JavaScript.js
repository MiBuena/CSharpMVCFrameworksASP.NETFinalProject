$(function () {
    $('.detailsLink').click(function () {
        $('#details').load(this.href);
        return false;
    });
});