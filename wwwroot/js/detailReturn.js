function SearchMovieReturn(returnID) {
    // console.log("Busca la movie");

    $("#Movie-Return").empty();

    $.ajax({
        type: "GET",
        url: "../../Returns/SearchMovieReturn",
        data: { ReturnID: returnID},
        success: function(ListadoMovieReturn) {

            $.each(ListadoMovieReturn, function(index, item){
                $("#Movie-Return").append(
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