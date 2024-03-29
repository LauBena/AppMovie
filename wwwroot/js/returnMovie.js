window.onload = CargarPagReturn();

function CargarPagReturn(){
    SearchMovieReturnTemp();
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

function SearchMovieReturnTemp() {
    //console.log("Busca la movie");

    $("#Movie-Return").empty();

    $.ajax({
        type: "GET",
        url: "../../Returns/SearchMovieReturnTemp",
        data: {},
        success: function(ListadoMovieTemp) {

            $.each(ListadoMovieTemp, function(index, item){
                $("#Movie-Return").append(
                    "<tr>" +
                        "<th>" + item.movieName + "</th>" +
                        "<th>" +                                            //juego de concatenacion
                        "<button class='btn-create2' onclick='QuitarReturn(" + item.movieID + ");'>Eliminar</button>" +
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

function QuitarReturn(id){
    console.log("Peli eliminada");
    console.log(id);

    $.ajax({
        type: "POST",
        url: "../../Returns/QuitarReturn",
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