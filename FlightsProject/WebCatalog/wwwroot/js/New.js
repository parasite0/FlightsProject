function myFunction() {
    $.ajax({
        url: '/Home/searchFlights',
        data: {
            departure: $("#field1").val(),
            arrival: $("#field2").val(),
            date: $("#field3").val()
        },
        success: function (flights) {
            $(".flights").empty();
            $(".flights").append(flights);
        }
    }
    );
};