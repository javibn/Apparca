<template>
  <div class="row  p-0 m-0">
    <div class="col-12 d-lg-none mb-4 pb-3 py-3 position-absolute z-3 filtroMovil bg-white">
      <div class="row m-0">
        <div class="col-6 p-0">
          <a class="text-center mb-0 fw-bold nav-link" data-bs-toggle="collapse" href="#collapseExample" role="button"
            aria-expanded="false" aria-controls="collapseExample" style="color:#205760; font-size: 1.1rem;">Filtros
            <span style="background-color: #fa8e00;" class="rounded-5 px-2">4</span></a>
        </div>
        <div class="col-6 p-0">
          <p class="text-center mb-0 fw-bold" style="color:#205760; font-size: 1.1rem;">Vista lista</p>
        </div>
        <div class="collapse" id="collapseExample">
          <filtros-component vista='mapa' ref="refFiltro" v-if="this.screenWidth < 992" @limpiarFiltro="limpiarFiltro" @getDataCar="getDataCar" @PasarDatos="PasarDatos" @getDataAncho="getDataAncho" @getDataAlto="getDataAlto" @getDataServicio="getDataServicio" @getDataPrecio="getDataPrecio" @getDataHoras="getDataHoras" @getDataDias="getDataDias" @getDataBrowser="getDataBrowser" ></filtros-component>
        </div>
      </div>
    </div>
    <div id="contenedor" class="oculto position-absolute z-3 d-none d-lg-block pt-3">
      <div id="contenedor1" >
        <div class="row m-0 rounded-5 plazaItem overflow-hidden">
          <img src="./../assets/plaza.jpg" style="height: 130px;" class="col-4 p-0 rounded-start-5 d-md-block d-none">
          <div class="col-md-8 ">
            <div class="row align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="./../assets/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
            <div class="row">
              <div class="col-7">
                <p class="fw-semibold mb-1 mt-2" style="color: #133C44;">Servicios</p>
                <div class="mx-auto" style="display: flex; justify-content: center;">
                  <img class="iconoMap p-1" src="./../assets/iconoWc.png">
                  <img class="iconoMap p-1" src="./../assets/iconoSeguridad.png">
                  <img class="iconoMap p-1" src="./../assets/icono24horas.png">
                </div>
              </div>
              <div class="col-5 p-2" style="background-color: #CFE2E4;">
                <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
                <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <button @click="MostrarPlazas" class="btn bg-white p-2 position-absolute z-2 d-none d-lg-block botonLista" id="mostrarDiv">
      <img src="./../assets/iconoDespliegueLista.png">
    </button>
    <button @click="OcultarPlazas" class="btn bg-white p-2 position-absolute z-2 d-none d-lg-block botonOcultarLista" id="ocultarDiv">
      <img src="./../assets/iconoDespliegueLista.png" style="transform: rotate(180deg);">
    </button>
    <a @click="UbicacionUsuario" class="btn bg-white p-2 position-absolute z-2 botonUbicacion">
      <img src="./../assets/iconoUbicacion.png">
    </a>
    <filtros-component vista='mapa' v-if="this.screenWidth >= 992" ref="refFiltro" @limpiarFiltro="limpiarFiltro" class="d-none d-lg-block position-absolute z-3 filtroCaja rounded-5" style=" margin-left: 4%; padding-left: 5px; max-height: 86vh; overflow-y: scroll;" @PasarDatos="PasarDatos" @getDataCar="getDataCar" @getDataAncho="getDataAncho" @getDataAlto="getDataAlto" @getDataServicio="getDataServicio" @getDataPrecio="getDataPrecio" @getDataHoras="getDataHoras" @getDataDias="getDataDias" @getDataBrowser="getDataBrowser"></filtros-component>
    <div id="map" class="position-absolute z-1" style="height: 91%;">
    </div>

  </div>
</template>

<script>
import L from 'leaflet';
import 'leaflet.markercluster';
import FiltrosComponent from '../components/FiltrosComponent.vue'
import { mapState } from 'vuex';
import router from '@/router';

export default {
  name: 'VistaMapa',
  data: function() {
        return {
          map: {},
          filtro:{
            inputValue: "",
            centro: null,
            horas: null,
            isCoche: true,
            precio: 100,
            disponibilidad:[false, false, false, false, false, false, false],
            servicios: {
              aseo: false,
              vigilancia: false,
              abierto24h: false
            },
            ancho: 0,
            alto: 0,
          },
          screenWidth: window.innerWidth
        }
  },
  computed:{
      ...mapState(['isCar']),
      ...mapState(['direccion']),
      ...mapState(['coordenadas']),
      ...mapState(['horasHome']),
      ...mapState(['filtroStore'])
  },
  components:{
    FiltrosComponent
  },
  async mounted() {
    this.map = L.map('map').setView([39.850931195377946, -3.1256103515625004], 7)
    console.log(this.map)


    this.map.on("moveend", () => {
      this.actualizarResultados()
    });

    if(this.filtroStore != null){
      console.log("Aqui meto los datos en el filtro: vistaMapa")
      this.filtro = this.filtroStore
      if(typeof this.filtro.horas == 'string'){
        this.filtro.horas = JSON.parse(this.filtro.horas)
      }
      this.$store.dispatch('limpiar')
      this.$refs.refFiltro.MeterDatos(this.filtro)
      if(this.filtro.centro != null){
        this.map.setView([this.filtro.centro[1], this.filtro.centro[0]], 15)
      }
    }else{
      if(this.coordenadas != null){
        this.DatosHome()
        console.log(this.coordenadas)
        this.map.setView([this.coordenadas[1], this.coordenadas[0]], 15)
      }
    }
    
    

    // Agregar una capa de mapa base
    L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
      maxZoom: 20,
      minZoom: 6
    }).addTo(this.map);

    var markers = L.markerClusterGroup();
    
    this.map.addLayer(markers);

    this.actualizarResultados()

    this.MeterMarcador(markers)
  },
  methods:{
    MeterMarcador(markers){
      var divIcon = L.divIcon({
            // Establece el contenido HTML del icono
            html: '<div class="marcador"><p>100€</p></div><div class="flecha-down mx-auto"></div>',
            iconSize: [38, 40], // size of the icon
            shadowSize: [50, 64], // size of the shadow
            iconAnchor: [22, 40], // point of the icon which will correspond to marker's location
            popupAnchor: [-3, -76]
          });

      var marker = L.marker([39.850931195377946, -3.1256103515625004], {icon : divIcon});
      markers.addLayer(marker);

      //var imagenCodificada = URL.createObjectURL(this.base64ToBlob(plaza.imagen));

      var stringPopup = '\
      <div class="row p-3 pb-0" style="width:350px">\
        <h6 class="fw-bold textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</h6>\
        <hr class="mt-1 text-warning">\
        <div class="row m-0 p-0">\
          <div class="col-6">\
            <p class="fw-bold textoPrimario textPopUp text-center my-1">Distancia</p>\
            <p class="textPopUp text-center my-2">182,65m</p>\
          </div>\
          <div class="col-6">\
            <p class="fw-bold textoPrimario textPopUp text-center my-1">Tamaño</p>\
            <p class="textPopUp text-center my-2"><img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAACXBIWXMAAAsTAAALEwEAmpwYAAADXElEQVR4nO3dTW7TQBjGcR+Di9ATsGBDWfBVvtJ21Z4MsfX7vJMV4gjAEjgKTVo0VipBMnZce5w8mTx/yRJtkeXml/G4VTVTVQUE4Cwe+74OVVVV7X4BD4t4xH/rRdljZuESHpbwcBcPg9+ahWuh7G9kLO8x/kNxvxIKAQaEwocBoez4acqbCfyu57EEcL7DSzyegDBLjIzUSNn8PwizfV9/cSPD4DcbtyQL1xu3qrUnL42UzJmFN+sY8QW//5ljHSR+rnZ/m7i1aaRMhYF/5oUUSMd8s9Dta2C1++ttGF0g9yiJcyzM/ePQ6zrK6p4Y20CarwtlEoxF2+PrNhChTIIRWh9b+4B0zEcLd/8w5pqLzd1fPRTjISAxoYzEsB6T70NAukahRkoGjCEgMaG0BMxfjn23YgBIFwowf18dYzkwxoB0z1tHhpILYyxI7OhRcmLkAOmcx0J4V5WchfDC4H9y3iKQAaTrjVIsSu3+PPEr9Js4uY45LzKBtE30zcfAaVVaBv+1/o3GW8XY8yIjSOvtC/6zKi3z8CM3xhQgKRRD+F6VFoCT+I3Fd5vZ/Fm283p+kOa8wGkzquHfzOaPc523+DARiBJIGUEjhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIhCsIZFju/gjun+H+xd2fsIPUcQU8D7+bdb6Ak6q0gPBJC5gRZQhftcQfUe7+9FAXwbSMK+AdxDKxYxbCRyaQtrV7435WVcnlRoEWUh7fatHiLCiYaKnxYhdQZl6Mv27ZIeHoMLYu7+39d1EbCqLtKiZCwQAQYUy0/9QQEO1D1TNtCnZQKDgfO0LaNpjUZmAZd/nsCyIMsq1XkdikWPvhToSCDhBhZK5O/7Lv1tyvtoHE/dYTG91rZIzNEnvYNigWrttAzMJlCkN7qe8ABWsgwthRQJgl3vXrH6c+t9TImAwFqSemrqP1cVntHmUpDB6UpTB2XJ1+rN14LFZ7RDFh0KAsVn+QcLHv61HVak4Bzkp4Mf4CyRSDOl0uWtAAAAAASUVORK5CYII=" height="20">1,9m</p>\
          </div>\
          <div>\
            <p class="fw-bold textoPrimario textPopUp text-center my-1">Servicios</p>\
            <div class="col-9 mx-auto" style="display: flex; justify-content: center;">\
                <img class="iconoPop p-1 mx-auto" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADQAAAA0CAYAAADFeBvrAAAACXBIWXMAAAsTAAALEwEAmpwYAAADjklEQVR4nO2ay2sUQRDGR3yDKHgRFDQGBTVnn6D4JxhN0It4Uw/GF3g1Xo2YREQl6CkeIqNm6vt6WMQIe0l8EEFBPZmDgh5VNDmEGF3pdcWY7O50T3d2R7GgYNkd+sdXXd1V3bNBkGC5XG6hkMdBPhZgTLv+DKBN/xZ4sppwlFKrBHgOslDWgWf6mb+Ck9MRqwaZAnOJYK04QWn6q0N+w45lnRMAeGIKEvJR1jkByFHjyJGjWecENiABPmedE/x7KQe01WKx1ooT6C1Sb5Um22kYhguyzimaLmZVYR4Lay04RdNR0VOt87e0gEcFeKi/c45YHTj/LbMGoEnILiFfljrf6TVhTP8GoFNENrmwSG4Q8oYAb0FOTuFMFr8DrutnUg2u81XIy9MGTvJJAJd6enrm2/IAHBJg3KCojpM8aC0G5ICFkOmF776NqEip3baBi5TabSyoNDMFR+825YEcsg4a8KJQKMxJHhxosoxWJeDX/jjemMQjuTkto1+pLSbR6vYwO78K4cUknpDtDql91kTQK1+CdFoYCBp0EDTo+1yS5F+qsXK53FKQEy5pHYbhsiRBBZ9edXaUanYdn+Se7Agir3pI6yuZEQRyxFkQ+ToTgqIoavDFiOO4se6ChDzqixGRR7Ig6K4vhgB36iooDMO5Anz0yPmUz+fn1U1QFEU7fHNIbq+bIADnfHOEbK8k6JtH0KSv7hrJPlRWUOm06CtqM2qEblV0y+J9hlChDQLQ4VHQmdlod1CJp1TzDEFhGC52Oa1O8T69m5UJ2LXZEgTgWtm00ydBUaoF5HCKgYdJ7pvNdgeVfSSoZnEcr7EdlOTqhDEbReREKQtSHx3w58XM0+LOCTRVFaQvOmwvL2wuR8J795YDaBWgVxdH47WC4tWZAnAYwIrAxkC+twC9C1KaTlOLtbI3qMV7G/36PS3Hpntgpa7AxHTjZxG522k5ANaacqIoakgviOyyENSZlpPP5xcJ8N0grb/rZ10EnTZeQ+Sp1KCf2ZDcgQMfXBg6FVqNBSnV4sQyuEIT8qWroG3GgkS2urAEeGDAGXB/TWguaKWTIPKmwRrqdRKk+zHDij5RrnezMZPGWMjzgauZHCkEeOPMIU8ZbAonnQWZHMiM7pmTBIkcSOJE5H53QcAtg5Tr8yBoV6IgpXY6CxLggkEqdLhylFLrDTjr3AWZ/JcNaHPlhGG4JImjnzEZ7AdAukFf4Gz16QAAAABJRU5ErkJggg==">\
                <img class="iconoPop p-1 mx-auto" src="data:image/png;base64,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">\
                <img class="iconoPop p-1 mx-auto" src="data:image/png;base64,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">\
              </div>\
          </div>\
        </div>\
      </div>\
      <div class="col-12 mb-0" style="background-color: #CFE2E4;">\
        <div>\
          <p class="fw-semibold mb-0 col-4 mx-auto pt-2 textPopUp" style="color: #133C44;">Precio</p>\
          <p class="fw-bold mb-0 fs-3 text-center mt-0" style="color: #000000;">91,90€</p>\
        </div>\
      </div>\
      <div class="col-12" style="background-color: #205760; border-radius: 0px 0px 25px 25px;">\
        <div>\
          <p class="fw-semibold mb-0 text-white p-2 textPopUp text-center mt-0">Ver detalle</p>\
        </div>\
      </div>';

      var popup = L.popup({ className: 'popup' })
          .setContent(stringPopup);

      marker.bindPopup(popup);
    },
    getDataCar(data) {
      this.filtro.isCoche = data
      this.actualizarResultados()
    },
    getDataHoras(data) {
      this.filtro.horas = data
      this.actualizarResultados()
    },
    getDataPrecio(data) {
      this.filtro.precio = data
      this.actualizarResultados()
    },
    getDataBrowser(inputValue, centro, isCorrect){
      this.filtro.inputValue = inputValue
      this.filtro.centro = centro
      this.isCorrect = isCorrect

      if(isCorrect){
        this.map.setView([centro[1], centro[0]], 15)
      }

      this.actualizarResultados()
    },
    PasarDatos(){
      console.log("Aqui subo los datos en el filtro: vistaMapa")
      console.log(this.filtro)
      this.$store.dispatch('PasarDatos', this.filtro)
      router.push({ name: 'VistaLista' });
    },
    UbicacionUsuario(){
      if ("geolocation" in navigator) {
        var vm = this;
        // El navegador admite geolocalización.
        navigator.geolocation.getCurrentPosition(function(position) {
          var latitud = position.coords.latitude;
          var longitud = position.coords.longitude;
          console.log("Latitud: " + latitud + ", Longitud: " + longitud);
          
          vm.map.setView([latitud, longitud], 14)
        }, function() {});
      }
    } ,
    getDataServicio(servicio, value){
      console.log(servicio + ": " +  value)
      const propiedades = Object.keys(this.filtro.servicios);

      this.filtro.servicios[propiedades[servicio]] = value;
      console.log(this.filtro.servicios)
      this.actualizarResultados()
    },
    getDataAncho(data){
      this.filtro.ancho = data
      this.actualizarResultados()
    },
    getDataAlto(data){
      this.filtro.alto = data
      this.actualizarResultados()
    },
    getDataDias(data){
      this.filtro.disponibilidad = data
      this.actualizarResultados()
    },
    actualizarResultados(){
      console.log("Actualizamos")
    },
    DatosHome(){
      var data = {
        nombre: this.isCar ? "Coche" : "Moto",
        direccion: this.direccion,
        horas: this.horasHome
      }

      this.$refs.refFiltro.CambiarOptionsHome(data)
      this.filtro.isCoche = this.isCar
      this.filtro.inputValue = this.direccion
      this.filtro.centro = this.coordenadas
      this.filtro.horas = this.horasHome

      this.$store.dispatch('limpiar')
    },
    MostrarPlazas(){
      const contenedorDiv = document.getElementById("contenedor");
      const ocultarDivBtn = document.getElementById("ocultarDiv");
      contenedorDiv.classList.toggle("oculto");
      
      contenedorDiv.style.left = "0";
      
      if(window.innerWidth > 1450){
        ocultarDivBtn.style.left = "60%"
      }
      else if(window.innerWidth > 1200){
        ocultarDivBtn.style.left = "65%"
      }else if(window.innerWidth > 992){
        ocultarDivBtn.style.left = "80%"
      }
    },
    OcultarPlazas(){
      const contenedorDiv = document.getElementById("contenedor");
      const ocultarDivBtn = document.getElementById("ocultarDiv");
      contenedorDiv.classList.toggle("oculto");
      if (contenedorDiv.classList.contains("oculto")) {
          if(window.innerWidth > 1450){
            contenedorDiv.style.left = "-60%";
          }
          else if(window.innerWidth > 1200){
            contenedorDiv.style.left = "-65%";
          }
          else if(window.innerWidth > 992){
            contenedorDiv.style.left = "-80%";
          }
      } else {
          contenedorDiv.style.left = "0";
      }
      ocultarDivBtn.style.left = "-10%"
    },
    limpiarFiltro(){
      this.filtro = {}
      this.actualizarResultados()
    }, 
  }
}

</script>

<style>
.filtroCaja::-webkit-scrollbar{
        width: 5px;
    }

    .filtroCaja{
      direction: rtl;
    }

    .prueba{
      direction:ltr;
    }

    .filtroCaja::-webkit-scrollbar-thumb {
        background-image: linear-gradient(180deg, #28748165 10%, #9e9e9e 90%);
        box-shadow: inset 2px 2px 5px 0 rgba(#fff, 0.5);
        border-radius: 100px;
    }
  .textoPrimario {
      color: #133C44;
    }

    .textPopUp{
      font-size: 1rem;
    }

    .iconoPop {
      width: 20%;
    }

    .iconoMap {
      width: 20%;
    }

    .marcador p{
      border:0px;
      margin:0px;
      font-weight:600;
      text-align:center;
      font-size: 0.9rem;
      color: white;
    }

    .marcador{
      background-color: #2b7a64;
      padding: 4px;
      width: 55px;
      border-radius: 5px;
    }

    .flecha-down {
        width: 0px;
        height: 0px;
        border-left: 7px solid transparent; /* izquierda flecha */
        border-right: 7px solid transparent; /* derecha flecha */
        border-top: 7px solid #2b7a64; /* base flecha y color*/
        font-size: 0px;
    }

    .leaflet-div-icon{
        width: 55px !important;
        border:0px;
        background-color: transparent;
    }

    .leaflet-popup-content-wrapper{
      margin: 0px;
      border-radius: 25px;
      padding: 0px;
    }

    .leaflet-popup{
      margin-bottom: 5px;
    }

    .leaflet-popup-close-button, .leaflet-popup-tip-container{
      display: none;
    }

    .leaflet-popup-content{
      margin: 0px;
      width: auto !important;
    }

    .filtroCaja{
      width: 22% !important;
    }
    .botonLista{
      width: 40px !important;
      left: 25%;
      top: 250px
    }

    .botonUbicacion{
      width: 60px !important;
      height: 60px !important;
      right: 2%;
      bottom: 4vh
    }

    .botonUbicacion:hover{
      background-color: red !important;
    }

    
    .botonOcultarLista{
      width: 40px !important;
      left: -10%;
      top: 250px;
      transition: 1s;
    }

    .botonOcultarLista img{
      width: 100%;
      height: auto;
    }

    .botonLista img{
      width: 100%;
      height: auto;
    }

    .botonUbicacion img{
      width: 100%;
      height: auto;
    }

    .listaDesplegable{
      margin-left: 24%;
      height: 90vh;
      width: 200px;
      background-color: white;
    }

    #contenedor {
        left: -60%; /* Comienza fuera de la pantalla */
        width: 60%;
        height: 90vh;
        padding-left: 27%;
        background-color: white;
        overflow: hidden;
        transition: 1s;
    }

    #contenedor1{
      height: 100%;
      overflow-y: scroll;
      padding-right: 20px;
    }

    #contenedor1::-webkit-scrollbar{
        width: 10px;
    }

    #contenedor1::-webkit-scrollbar-thumb {
        background-image: linear-gradient(180deg, #287381 10%, #8cbdc5 90%);
        box-shadow: inset 2px 2px 5px 0 rgba(#fff, 0.5);
        border-radius: 100px;
    }

    @media screen and (max-width: 1450px) {
      .filtroCaja{
        width: 25% !important;
      }
      .botonLista{
        left: 28%;
      }
      #contenedor{
        padding-left: 28%;
        width: 65%;
        left: -65%;
      }
    }

    @media screen and (max-width: 1200px) {
      .filtroCaja{
        width: 30% !important;
      }
      .botonLista{
        left: 32%;
      }
      #contenedor{
        padding-left: 33%;
        width: 80%;
        left: -80%;
      }
    }

</style>