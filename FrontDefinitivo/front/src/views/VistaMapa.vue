<template>
  <div class="row  p-0 m-0">
    <div id="contenedor" class="oculto position-absolute z-3 d-none d-lg-block pt-3">
      <div id="contenedor1" >
        <div class="row m-0 rounded-5 plazaItem overflow-hidden">
          <img src="img/plaza.jpg" style="height: 130px;" class="col-4 p-0 rounded-start-5 d-md-block d-none">
          <div class="col-md-8 ">
            <div class="row align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="img/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
            <div class="row">
              <div class="col-7">
                <p class="fw-semibold mb-1 mt-2" style="color: #133C44;">Servicios</p>
                <div class="mx-auto" style="display: flex; justify-content: center;">
                  <img class="icono p-1" src="img/iconoWc.png">
                  <img class="icono p-1" src="img/iconoSeguridad.png">
                  <img class="icono p-1" src="img/icono24horas.png">
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
    <button class="btn bg-white p-2 position-absolute z-2 d-none d-lg-block botonLista" id="mostrarDiv">
      <img src="./../assets/iconoDespliegueLista.png">
    </button>
    <button class="btn bg-white p-2 position-absolute z-2 d-none d-lg-block botonOcultarLista" id="ocultarDiv">
      <img src="./../assets/iconoDespliegueLista.png" style="transform: rotate(180deg);">
    </button>
    <filtros-component ref="refFiltro" class="d-none d-lg-block mt-5 position-absolute z-3 filtroCaja" style=" margin-left: 3%;" @getDataCar="getDataCar" @getDataAncho="getDataAncho" @getDataAlto="getDataAlto" @getDataServicio="getDataServicio" @getDataPrecio="getDataPrecio" @getDataHoras="getDataHoras" @getDataDias="getDataDias" @getDataBrowser="getDataBrowser"></filtros-component>
    <div id="map" class="position-absolute z-1" style="height: 90%;">
    </div>

  </div>
</template>

<script>
import L from 'leaflet';
import 'leaflet.markercluster';
import FiltrosComponent from '../components/FiltrosComponent.vue'

export default {
  name: 'VistaMapa',
  data: function() {
        return {
          map: {}
        }
  },
  components:{
    FiltrosComponent
  },
  async mounted() {
    const mapa = L.map('map').setView([39.850931195377946, -3.1256103515625004], 7)
    this.map = mapa
    // Agregar una capa de mapa base
    L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
      maxZoom: 20,
      minZoom: 6
    }).addTo(mapa);

    var markers = L.markerClusterGroup();
    
    mapa.addLayer(markers);
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
            <p class="textPopUp text-center my-2"><img src="img/iconoAltura.png" height="20">1,9m</p>\
          </div>\
          <div>\
            <p class="fw-bold textoPrimario textPopUp text-center my-1">Servicios</p>\
            <div class="col-9 mx-auto" style="display: flex; justify-content: center;">\
                <img class="iconoPop p-1 mx-auto" src="img/iconoWc.png">\
                <img class="iconoPop p-1 mx-auto" src="img/iconoSeguridad.png">\
                <img class="iconoPop p-1 mx-auto" src="img/icono24horas.png">\
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
      this.isCoche = data
      this.actualizarResultados()
    },
    getDataHoras(data) {
      this.horas = data
      this.actualizarResultados()
    },
    getDataPrecio(data) {
      this.precio = data
      this.actualizarResultados()
    },
    getDataBrowser(inputValue, centro, isCorrect){
      this.inputValue = inputValue
      this.centro = centro
      this.isCorrect = isCorrect

      this.actualizarResultados()
    },
    getDataServicio(servicio, value){
      console.log(servicio + ": " +  value)
      const propiedades = Object.keys(this.servicios);

      this.servicios[propiedades[servicio]] = value;
      console.log(this.servicios)
      this.actualizarResultados()
    },
    getDataAncho(data){
      this.ancho = data
      this.actualizarResultados()
    },
    getDataAlto(data){
      this.alto = data
      this.actualizarResultados()
    },
    getDataDias(data){
      this.disponibilidad = data
      this.actualizarResultados()
    },
    actualizarResultados(){
      console.log("Actulizamos")
    },
    DatosHome(){
      var data = {
        nombre: this.isCar ? "Coche" : "Moto",
        direccion: this.direccion,
        horas: this.horasHome
      }

      this.$refs.refFiltro.CambiarOptionsHome(data)

      this.isCoche = this.isCar
      this.inputValue = this.direccion
      this.centro = this.coordenadas
      this.horas = this.horasHome
    },
  }
}

</script>

<style>
  .textoPrimario {
      color: #133C44;
    }

    .textPopUp{
      font-size: 1rem;
    }

    .iconoPop {
      width: 20%;
    }

    .icono {
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
      left: 24%;
      top: 250px
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
        left: 27%;
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
        left: 31%;
      }
      #contenedor{
        padding-left: 33%;
        width: 80%;
        left: -80%;
      }
    }
</style>