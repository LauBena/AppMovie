function SearchMovie(rentalID) {
    // console.log("Busca la movie");

    $("#tableMovies").empty();

    $.ajax({
        type: "GET",
        url: "../../Rentals/SearchMovie",
        data: { RentalID: rentalID},
        success: function(ListadoMovie) {

            $.each(ListadoMovie, function(index, item){
                $("#tableMovies").append(
                    "<tr>" +
                        "<th>" + item.movieName + "</th>" +
                    "</tr>"
                );
            });

        },
        error(result){
            console.log(result);
        }
    })
}