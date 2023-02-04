


let map = L.map('map').setView([38.345169, -0.491991], 13);

map.on("moveend", function () {
    var localizacionMapa = map.getBounds();

    
  });

L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
	maxZoom: 18,
    minZoom: 6
}).addTo(map);

var icono = L.icon({
    iconUrl: 'img/icono.png',
	shadowUrl: "",

    iconSize:     [38, 50], // size of the icon
	shadowSize:   [50, 64], // size of the shadow
    iconAnchor:   [22, 50], // point of the icon which will correspond to marker's location
    popupAnchor:  [-3, -76] // point from which the popup should open relative to the iconAnchor
});

var marcadores= L.markerClusterGroup({ iconCreateFunction: function (cluster) {
     var markers = cluster.getAllChildMarkers(); 
     return L.divIcon({ html: markers.length, className: 'mycluster', iconSize: L.point(40, 40) }); } });



var marcadoresArray = [];

marcadoresArray.push(L.marker([38.379852, -0.429192], {icon: icono}));
marcadoresArray.push(L.marker([38.380850, -0.427476], {icon: icono}));
marcadoresArray.push(L.marker([38.3470302,-0.4986278], {icon: icono}));
marcadoresArray.push(L.marker([38.3469339,-0.4973522], {icon: icono}));
marcadoresArray.push(L.marker([38.342981, -0.484889], {icon: icono}));
marcadoresArray.push(L.marker([38.345296, -0.488024], {icon: icono}));



var plazasActivas=[];
mostrarMarcadores(marcadoresArray, marcadores);

MontarLista();

map.on("moveend", function () {
    
    mostrarMarcadores(marcadoresArray, marcadores);
    
});





function mostrarMarcadores(marcadoresArray, marcadores){
    console.clear();
    var localizacionMapa = map.getBounds();

    //console.log(localizacionMapa);
    //console.log(marcadoresArray[0])
    plazasActivas = [];

    marcadoresArray.forEach(marcador => {
        if(marcador._latlng.lat < localizacionMapa._northEast.lat && marcador._latlng.lat > localizacionMapa._southWest.lat){
            if(marcador._latlng.lng < localizacionMapa._northEast.lng && marcador._latlng.lng > localizacionMapa._southWest.lng){
                console.log(marcador);
                var localizador = {
                    marcador:marcador,
                    info: {
                        calle: "calle clara campoamor",
                        numero:"5",
                        cp:"03540",
                        localidad:"Alicante",
                        precio: 10
                    }

                }
                marcadores.addLayer(marcador);
                plazasActivas.push(localizador);
                var estilo =
                    {
                        'background-color':'blue',
                        'fontsize':'1rem'
                    }
                marcador.bindPopup('<div class="popup"><h1 >'+localizador.info.calle+'</h1><img src="img/plaza.jpg"></div>');
            }
        }
    });

    map.addLayer(marcadores);

    MontarLista();
}



function MostrarFiltros(idElemento){
    console.log("hola");
    $('#'+idElemento).fadeToggle(100);
}

function MontarLista(){
    var element = document.getElementById("listaPlazas");
    element.innerHTML="";
    

    var cerrar = document.createElement("div");
    cerrar.id="cerrar";
    var X = document.createElement("img");
    X.src="img/cerrar.png";
    X.addEventListener("click", function(){CerrarLista()});
    cerrar.appendChild(X);
    element.appendChild(cerrar);


    var titulo = document.createElement("h1");
    titulo.innerHTML="MOSTRANDO "+plazasActivas.length+" PLAZAS";
    titulo.style="text-align:center;"
    element.appendChild(titulo);

    plazasActivas.forEach(marcador => {
        var divMarcador = document.createElement("div");
        divMarcador.classList+="row marcadorLista";

        var foto= document.createElement('img');
        foto.classList="col-3 fotoLista";
        foto.src="img/plaza.jpg";
        divMarcador.appendChild(foto);

        var info = document.createElement("div");
        info.classList="offset-1 col-6";
        divMarcador.appendChild(info);

        var calle = document.createElement("p");
        calle.innerHTML=marcador.info.calle+", nº "+marcador.info.numero;
        info.appendChild(calle);

        var localidad = document.createElement("p");
        localidad.innerHTML=marcador.info.localidad+", "+marcador.info.cp;
        info.appendChild(localidad);

        var botonResevar = document.createElement('button');
        botonResevar.innerHTML="RESERVAR PLAZA";
        botonResevar.classList="btn btn-primary"
        info.appendChild(botonResevar);

        element.appendChild(divMarcador);
    });

    
    
}

function MostrarLista(){
    MontarLista();
    var element = document.getElementById("listaPlazas");
    element.style="display: block;";
    element.scroll(0, 0);

    
    setTimeout(function(){
        element.classList="deslizarse";
    },1);
    
}

function CerrarLista(){
    var element = document.getElementById("listaPlazas");
    element.classList-="deslizarse";

    
    setTimeout(function(){
        element.style="display: none;";
    },1000);

    
}

function Filtrar(){
    console.log("hola");
    var hora = document.getElementById("horaFin");
    console.log(hora.value);
}

