// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

$(document).ready(function () {
    $.ajax({
        url: "/Fan/index",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            $('#speed').html(data.speed);
            $('#direction').html(data.direction ? "clockwise" : "counter-clockwise");
        },
        error: function (e) {
            alert('Server is not responding');
        }
    });

    $('#speedButton').click(function (data) {
        $.ajax({
            url: "/Fan/speedUp",
            type: "GET",
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                $('#speed').html(data.speed);
            },
            error: function (e) {
                alert('Server is not responding');
            }
        });

        return false;
    });

    $('#reverseButton').click(function (data) {
        $.ajax({
            url: "/Fan/reverse",
            type: "GET",
            success: function (data) {
                $('#direction').html(data.direction ? "clockwise" : "counter-clockwise");
            },
            error: function (e) {
                alert('Server is not responding');
            }
        });

        return false;
    });
})