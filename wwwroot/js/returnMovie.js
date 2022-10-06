window.onload = CargarPagina();

function CargarPagina(){
    SearchMovieTemp();
}

function CancelReturn() {
    //console.log("Cancelar devolucion");

    $.ajax({
        type: "POST",
        url: "../../Returns/CancelReturn",
        data: {},
        success: function(resultado) {
            if(resultado == true){
                location.href="../../Returns/Index";
            }
        },
        error(result){
            console.log(result);
        }
    })
}

function SearchMovieTemp() {
    //console.log("Busca la movie");

    $("#tableMovies").empty();

    $.ajax({
        type: "GET",
        url: "../../Returns/SearchMovieTemp",
        data: {},
        success: function(ListadoMovieTemp) {

            $.each(ListadoMovieTemp, function(index, item){
                $("#tableMovies").append(
                    "<tr>" +
                        "<th>" + item.movieName + "</th>" +
                        "<th>" +                                            //juego de concatenacion
                        "<button class='btn-create2' onclick='QuitarMovie(" + item.movieID + ");'>Eliminar</button>" +
                        "</th>" +
                    "</tr>"
                );
            });

        },
        error(result){
            console.log(result);
        }
    })
}

function QuitarMovie(id){
    console.log("Peli eliminada");
    console.log(id);

    $.ajax({
        type: "POST",
        url: "../../Returns/QuitarMovie",
        data: {MovieID: id},
        success: function(resultado) {
            if(resultado == false){
                location.href="../../Returns/Create";
            }
        },
        error(result){
            console.log(result);
        }
    })
}