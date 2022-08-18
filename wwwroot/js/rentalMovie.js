function CancelRental() {
    //console.log("Cancelar alquiler");

    $.ajax({
        type: "POST",
        url: "../../Rentals/CancelRental",
        data: {},
        success: function(resultado) {
            if(resultado == true){
                location.href="../../Rentals/Index";
            }
        },
        error(result){
            console.log(result);
        }
    })
}
