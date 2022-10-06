function SearchMovie(returnID) {
    // console.log("Busca la movie");

    $("#tableMovies").empty();

    $.ajax({
        type: "GET",
        url: "../../Returns/SearchMovie",
        data: { ReturnID: returnID},
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