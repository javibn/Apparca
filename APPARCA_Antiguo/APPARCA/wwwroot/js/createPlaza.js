

var completadoDireccion = false;
var autocompletedata;
var precioHoraCompleta = 0;

function initMap() {

    var horaInicio = document.getElementById("HoraInicio").value;
    var horaFinal = document.getElementById("HoraFinal").value;
    var precioHora = document.getElementById("PrecioHora").value;
    var precioMes = document.getElementById("PrecioMes").value;
    

    document.getElementById("HoraInicio").value = document.getElementById("HoraInicio").value.replace(/,/g, ".");
    document.getElementById("HoraFinal").value = document.getElementById("HoraFinal").value.replace(/,/g, ".");

    let CambioTextoPrecioHoras = function () {
        var inputprecio = document.getElementById("PrecioHora");
        var inputprecioMes = document.getElementById("PrecioMes");
        var inputhoraInicio = document.getElementById("HoraInicio");
        var inputhoraFinal = document.getElementById("HoraFinal");
        
        if (horaInicio != inputhoraInicio.value) {
            CorregirHoras(inputhoraInicio);
            horaInicio = document.getElementById("HoraInicio").value;
        }
        if (horaFinal != inputhoraFinal.value) {
            CorregirHoras(inputhoraFinal);
            horaFinal = document.getElementById("HoraFinal").value;
        }
               

        let horasCorrectas = (inputhoraInicio.value.substr(0, 2) < inputhoraFinal.value.substr(0, 2)) || (inputhoraInicio.value.substr(0, 2) == inputhoraFinal.value.substr(0, 2) && inputhoraInicio.value.substr(-2) < inputhoraFinal.value.substr(-2));
        
        let labelHoras = document.getElementById("labelHorasIncorrectas");

        if (inputhoraInicio.value.substr(-2) == "00" || inputhoraInicio.value.substr(-2) == "15" || inputhoraInicio.value.substr(-2) == "30" || inputhoraInicio.value.substr(-2) == "45") {
            if (inputhoraFinal.value.substr(-2) == "00" || inputhoraFinal.value.substr(-2) == "15" || inputhoraFinal.value.substr(-2) == "30" || inputhoraFinal.value.substr(-2) == "45") {
                if (!isNaN(inputprecio.value)) {
                    if (horasCorrectas) {

                        labelHoras.classList = "desaparecer";

                        let calculoHoras = (inputhoraFinal.value.substr(0, 2) - inputhoraInicio.value.substr(0, 2));
                        let calculoMinutos = ((inputhoraFinal.value.substr(-2) / 60) - (inputhoraInicio.value.substr(-2) / 60));
                        var posicionComa;
                        console.log(posicionComa);
                        console.log(((calculoHoras + calculoMinutos) * 20));
                        

                        if (precioMes != inputprecioMes.value) {
                            //------------------

                            precioMes = document.getElementById("PrecioMes").value;
                            posicionComa = (precioMes / ((calculoHoras + calculoMinutos) * 20)).toString().indexOf(".");

                            console.log(posicionComa);
                            console.log((precioMes / ((calculoHoras + calculoMinutos) * 20)));

                            if (posicionComa != -1) {
                                console.log("con coma");
                                console.log(posicionComa);
                                inputprecio.value = (precioMes / ((calculoHoras + calculoMinutos) * 20)).toString().substr(0, posicionComa + 3);
                                
                                //inputprecio.value = (precioMes / ((calculoHoras + calculoMinutos) * 20));
                            } else {
                                console.log("sin coma");

                                inputprecio.value = (precioMes / ((calculoHoras + calculoMinutos) * 20));
                            }
                            precioHora = document.getElementById("PrecioHora").value;
                            precioHoraCompleta = (precioMes / ((calculoHoras + calculoMinutos) * 20));
                            //-------------------
                            
                        } else {
                            posicionComa = ((calculoHoras + calculoMinutos) * 20 * inputprecio.value).toString().indexOf(".");
                            if (posicionComa != -1) {
                                inputprecioMes.value = ((calculoHoras + calculoMinutos) * 20 * inputprecio.value).toString().substr(0, (posicionComa + 3));
                            } else {
                                inputprecioMes.value = ((calculoHoras + calculoMinutos) * 20 * inputprecio.value);
                            }
                            precioMes = document.getElementById("PrecioMes").value;
                            precioHora = document.getElementById("PrecioHora").value;
                            precioHoraCompleta = document.getElementById("PrecioHora").value;
                        }

                        
                    } else {

                        labelHoras.classList = "";
                    }
                }
            }
        }
    }

    function CorregirHoras(inputhoraInicio){
        if (inputhoraInicio.value.substr(-2) <= 8) {
            inputhoraInicio.value = inputhoraInicio.value.substr(0, 2) + ":00";
        } else if (inputhoraInicio.value.substr(-2) <= 22) {
            inputhoraInicio.value = inputhoraInicio.value.substr(0, 2) + ":15";
        } else if (inputhoraInicio.value.substr(-2) <= 37) {
            inputhoraInicio.value = inputhoraInicio.value.substr(0, 2) + ":30";
        } else if (inputhoraInicio.value.substr(-2) <= 52) {
            inputhoraInicio.value = inputhoraInicio.value.substr(0, 2) + ":45";
        } else {
            if (inputhoraInicio.value.substr(0, 2) != 23) {
                let horas = (Number(inputhoraInicio.value.substr(0, 2)) + 1);
                if (horas.toString().length == 1) {
                    horas = "0" + horas;
                }
                inputhoraInicio.value = horas + ":00";
            } else {
                inputhoraInicio.value = "00:00";
            }
        }
    }

    var inputprecioHora = document.getElementById("PrecioHora");
    inputprecioHora.addEventListener('propertychange', CambioTextoPrecioHoras);
    inputprecioHora.addEventListener('input', CambioTextoPrecioHoras);

    var inputprecioMes = document.getElementById("PrecioMes");
    inputprecioMes.addEventListener('propertychange', CambioTextoPrecioHoras);
    inputprecioMes.addEventListener('input', CambioTextoPrecioHoras);

    var inputhoraInicio = document.getElementById("HoraInicio");
    inputhoraInicio.addEventListener('propertychange', CambioTextoPrecioHoras);
    inputhoraInicio.addEventListener('input', CambioTextoPrecioHoras);


    var inputhoraFinal = document.getElementById("HoraFinal");
    inputhoraFinal.addEventListener('propertychange', CambioTextoPrecioHoras);
    inputhoraFinal.addEventListener('input', CambioTextoPrecioHoras);

    

    let input = document.getElementById("Direccion");
    let autocomplete = new google.maps.places.Autocomplete(input);


    let CambioTexto = function () {
        completadoDireccion = false;
        let labelDireccion2 = document.getElementById("labelDireccion2");
        labelDireccion2.classList = "";
    }

    input.addEventListener('propertychange', CambioTexto);
    input.addEventListener('input', CambioTexto);



    autocomplete.addListener('place_changed', function () {
        var centroWa = (autocomplete.getPlace().geometry.viewport.Wa.lo + autocomplete.getPlace().geometry.viewport.Wa.hi) / 2;
        var centroIa = (autocomplete.getPlace().geometry.viewport.Ja.lo + autocomplete.getPlace().geometry.viewport.Ja.hi) / 2;
        console.log(isNaN(autocomplete.getPlace().address_components[0].long_name));
        let labelDireccion = document.getElementById("labelDireccion");
        let labelDireccion2 = document.getElementById("labelDireccion2");
        labelDireccion2.classList = "desaparecer";
        if (isNaN(autocomplete.getPlace().address_components[0].long_name)) {
            completadoDireccion = false;
            labelDireccion.classList = "";
        } else {
            labelDireccion.classList = "desaparecer";

            completadoDireccion = true;
            autocompletedata = autocomplete.getPlace();
            console.log(autocomplete.getPlace());
            console.log(centroWa);
            console.log(centroIa);


            var posicionComa = centroWa.toString().indexOf(".");
            console.log("Posicion Coma: " + posicionComa);
            console.log("Posicion que redondea" + (9 - posicionComa - 1));

            var centroWa = (+(Math.round(centroWa + "e+" + (9 - posicionComa - 1)) + "e-" + (9 - posicionComa - 1)));
            while (centroWa.toString().length < 9) {
                centroWa += "0";
            }
            console.log(centroWa);

            let inputLat = document.getElementById("Latitud");
            inputLat.value = centroWa.toString();

            posicionComa = centroIa.toString().indexOf(".");

            var centroIa = (+(Math.round(centroIa + "e+" + (9 - posicionComa - 1)) + "e-" + (9 - posicionComa - 1)));
            while (centroIa.toString().length < 9) {
                centroIa += "0";
            }
            console.log(centroIa);

            let inputLong = document.getElementById("Longitud");
            inputLong.value = centroIa.toString();
        }


    });

}

function CrearPlaza() {

    

    

    if (!completadoDireccion) {
        event.preventDefault();
        console.log("rechazado");
    } else {
        let input = document.getElementById("Direccion");
        input.value = autocompletedata.address_components[1].long_name + ", " + autocompletedata.address_components[0].long_name + ", " + autocompletedata.address_components[3].long_name;
        document.getElementById("PrecioHora").value = precioHoraCompleta.toString().replace(/,/g, ".");
        document.getElementById("PrecioMes").value = document.getElementById("PrecioMes").value.replace(/,/g, ".");

        window.location.assign("/Plazas/Index");

    }
}



