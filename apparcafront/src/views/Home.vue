<template>
    <div >
      <div id="map" class="z-2 position-absolute w-100" style="margin-top:6vh;"></div>
      <div class="z-2 w-100   position-absolute">
        <div class="row bg-white m-0 ps-5 pe-5 w-100 filtros" style="height:6vh;display: flex;  align-items: center;">
          <input type="text" class="col-2 h-75 rounded btn border text-start me-3" v-model="filtroPlazas.direccion"  placeholder="Direccion, Ciudad..." >
          <div class="col-xl-2 col-3 h-100 p-0 me-3" style="display: flex;  align-items: center;">
            <time-component class="h-75 p-0 m-0" @getDataHoras="getDataHoras"></time-component>
          </div>
          <div class="col-2 me-3 h-75 p-0">
            <date-component class="h-100 p-0 m-0 w-100" @getDataFecha="getDataFecha"></date-component>
          </div>
          <div class="col me-3 h-100">
            <slider-component @getDataPrecio="getDataPrecio"></slider-component>
          </div>
            
            <!--<input-number-component class="w-100"></input-number-component>
            <div class="input-group mb-3">
              <input type="number" class="form-control" placeholder="Ancho(cm)" min="100" step="10">
            </div>-->
          <div class="col-2 me-2 h-75 row">
            <!--<input type="number" value="100" class="col-5 h-100 btn border text-start bg-white" id="basic-url" aria-describedby="basic-addon3">-->
            <input-number-component class="col-12 m-0 p-0" @getDataAncho="getDataAncho"></input-number-component>
          </div>
          <button class="col-1 h-75 btn btn-primary" @click="filtrar">
            Filtrar
          </button>
        </div>
        <div class="rounded  border-top border-1 d-block d-lg-none" style="height:5vh;display: flex;  align-items: center;">
          <!--<div class="row bg-white m-0  pe-5 w-100 "-->
          <filtros-component class="h-100"/>
        </div>
        
      </div>

      <div class="z-3 w-100 position-absolute " style="height:20vh; bottom: 6vh;">
        <p class="text-center fw-bold m-0" style="height:3vh;">{{this.plazasApi.length}} Resultados</p>
        <scrollbar-component :numberOfItems="plazasApi" :abierto="plazaId" />
      </div>
      
        <!--<router-link to="/About">About</router-link>-->
      
    </div>
</template>

<script>
import { mapState } from 'vuex';
//import inicioPlazas from './components/Plazas.vue'
import L from 'leaflet';
import 'leaflet.markercluster';
//import {toRaw} from 'vue';
//import { stringify } from 'flatted';

import DateComponent from '../components/DateComponent.vue'
import TimeComponent from '../components/TimeComponent.vue'
import FiltrosComponent from '../components/FiltrosComponent.vue'
import SliderComponent from '../components/SliderComponent.vue'
import InputNumberComponent from '../components/InputNumberComponent.vue'
import ScrollbarComponent from '../components/ScrollbarComponent.vue'


export default {
  name: 'HomeA',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            plazasApi: [],
            map : {},
            filtroPlazas: {
              /*direccion: '',
              horas: {
              },
              fecha: '',
              precio: '',
              ancho: '',*/
              latitudMaxima: "",
              latitudMinima: "",
              longitudMaxima: "",
              longitudMinima: ""
            },
            plazaId: 0
        }
    },
  components: {
    DateComponent,
    TimeComponent,
    FiltrosComponent,
    SliderComponent,
    InputNumberComponent,
    ScrollbarComponent
  },
  computed:{
            ...mapState(['isLoggedIn']),
            ...mapState(['token'])
        },
  async mounted() {
    const mapa = L.map('map').setView([39.850931195377946, -3.1256103515625004], 7)
    this.map = mapa
    // Agregar una capa de mapa base
    L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
      maxZoom: 20,
      minZoom: 6
    }).addTo(mapa);

    //console.log("hola"+mapa.getCenter());

    mapa.on("moveend", () => {
      this.MovimientoMapa(mapa);
    });

    mapa.on('popupopen', (event) => {
      this.AbrirPopUp(event)
    });

    mapa.on('popupclose', () => {
      this.plazaId = 0
      console.log("id: " + this.plazaId)
    });

    this.MovimientoMapa(mapa);

  },
  methods: {
    getDataFecha(data) {
      this.filtroPlazas.fecha = data
    },
    getDataHoras(data) {
      this.filtroPlazas.horas = JSON.parse(data)
    },
    getDataPrecio(data) {
      this.filtroPlazas.precio = data
    },
    getDataAncho(data) {
      this.filtroPlazas.ancho = data
    },
    filtrar(){
      console.log("Direccion: " + this.filtroPlazas.direccion);
      console.log("Horas: " + this.filtroPlazas.horas);
      console.log("Rango de fechas: " + this.filtroPlazas.fecha);
      console.log("Precio: " + this.filtroPlazas.precio);
      console.log("Ancho: " + this.filtroPlazas.ancho);
    },
    AbrirPopUp(event){
      var marker = event.popup._source;
      //console.log(marker.options.id)
      this.plazaId = marker.options.id

      var posicion = -1
      var plaza = {}
      for(var i=0; i< this.plazasApi.length;i++){
        if(this.plazaId === this.plazasApi[i].id){
          posicion = i;
          plaza = this.plazasApi[i]
        }
      }

      if(posicion!=0){
        this.plazasApi.splice(posicion, 1);
        this.plazasApi.unshift(plaza)
      }
      console.log("id: " + this.plazaId)
    },
    MovimientoMapa(map){
      console.log(this.plazaId)

      var bounds = map.getBounds()
      //console.log(bounds)
      //console.log(this.filtroPlazas)
      this.filtroPlazas.latitudMaxima = bounds._northEast.lat.toString().replace(".", ",");
      this.filtroPlazas.longitudMaxima = bounds._northEast.lng.toString().replace(".", ",");
      this.filtroPlazas.latitudMinima = bounds._southWest.lat.toString().replace(".", ",");
      this.filtroPlazas.longitudMinima = bounds._southWest.lng.toString().replace(".", ",");

      for(var i=0; i< this.plazasApi.length; i++){
        if(this.plazaId !== this.plazasApi[i].id){
          this.plazasApi.splice(i, 1)
          i--
        }
      }
      console.log(this.plazasApi)
      // Crea un nuevo MarkerClusterGroup vacío y asigna al mapa
      const self = this;
      // Itera sobre todas las capas del mapa y elimina cada capa que sea un marcador o un grupo de marcadores
      map.eachLayer(function(layer) {
        console.log(self.plazaId)
        console.log("1"+ layer)
          if (layer instanceof L.Marker) {
            console.log("2M")
            console.log(layer)
            console.log(self.plazaId)
            //layer.clearLayers();
            if(layer.options.id){
              if(layer.options.id !== self.plazaId){
                map.removeLayer(layer)
              }else{
                console.log("no lo quito")
              }
              
            }else{
              map.removeLayer(layer)
            }
          }
      });

      this.GetPlazasFiltradas();
      
    },
    base64ToBlob(base64) {
      const binaryString = window.atob(base64);
      const byteNumbers = new Array(binaryString.length);
      for (let i = 0; i < binaryString.length; i++) {
        byteNumbers[i] = binaryString.charCodeAt(i);
      }
      const byteArray = new Uint8Array(byteNumbers);
      return new Blob([byteArray], { type: 'image/jpeg' });
    },
    async GetPlazasFiltradas(){
      /*const formData = new FormData();

      for (const key in this.filtroPlazas) {
        formData.append(key, this.filtroPlazas[key]);
      }

      await fetch('https://localhost:7207/Plazas/Filtrado', {
      method: 'POST',
      body: formData
      })
      .then(response => response.json())
      .then(data => {
        //this.plazasApi = this.plazasApi.concat(data)
        data.forEach(plazaNueva => {
          if(plazaNueva.id != this.plazaId){
            this.plazasApi.push(plazaNueva)
          }
        })
        })
      .catch(error => console.error(error))*/
      console.log(this.filtroPlazas)
      await fetch('https://localhost:7207/Plazas/Filtrado?latitudMaxima=' + this.filtroPlazas.latitudMaxima + '&latitudMinima=' + this.filtroPlazas.latitudMinima + '&longitudMaxima=' + this.filtroPlazas.longitudMaxima + '&longitudMinima=' + this.filtroPlazas.longitudMinima)
      .then(response => response.json())
      .then(data => {
        console.log(data)
        //this.plazasApi = this.plazasApi.concat(data)
        data.forEach(plazaNueva => {
          if(plazaNueva.id != this.plazaId){
            var imagenCodificada = URL.createObjectURL(this.base64ToBlob(plazaNueva.imagen));
            console.log(imagenCodificada)
            console.log(plazaNueva)
            plazaNueva.imagenSrc = imagenCodificada;
            console.log(plazaNueva)
            this.plazasApi.push(plazaNueva)
          }
        })
        })
      .catch(error => console.error(error))


      var markers = L.markerClusterGroup();

      this.plazasApi.forEach(plaza => {

        if(plaza.id !== this.plazaId){
          var divIcon = L.divIcon({
            // Establece el contenido HTML del icono
            html: '<div class="marcador"><p>' + plaza.precioMes + '€</p></div><div class="flecha-down mx-auto"></div>',
            iconSize: [38, 40], // size of the icon
            shadowSize: [50, 64], // size of the shadow
            iconAnchor: [22, 40], // point of the icon which will correspond to marker's location
            popupAnchor: [-3, -76]
          });

          var marker = L.marker([plaza.latitud, plaza.longitud], {id: plaza.id,icon : divIcon});
          markers.addLayer(marker);

          console.log(marker.options.id)

          //var imagenCodificada = URL.createObjectURL(this.base64ToBlob(plaza.imagen));

          var stringPopup = '\
          <div class="row p-0" style="width:300px">\
            <img class="col-12" src="'+plaza.imagenSrc+'"/>\
            <div class="col-12 mx-auto ms-3 row mt-3 p-0">\
            <h6 class="mx-auto">\
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo-alt-fill" viewBox="0 0 16 16">\
                    <path d="M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10zm0-7a3 3 0 1 1 0-6 3 3 0 0 1 0 6z"/>\
                </svg>\
                '+plaza.direccion+'\
            </h6>\
            <hr class="border border-black border-1 opacity-100 w-75 mx-auto">\
            <div class="row p-0 m-0">\
                <h7 class="col-6 btn" style="font-size:1rem;">'+plaza.horaInicio+' - '+plaza.horaFinal+'</h7>\
                <h7 class="col-4 btn bg-primary  text-white rounded" style="font-size:1rem;">'+ plaza.precioMes+'€/mes</h7>\
            </div>\
            <router-link to="google.com" class="col-8 mx-auto p-0 btn btn-light text-dark fw-bold mt-3">VISITAR PLAZA</router-link>\
        </div>\
          </div>';

          var popup = L.popup({ className: 'popup' })
              .setContent(stringPopup);

          //.setContent('<div class="popup" style="background-image: url(' + url + '); "><h1>PLAZA</h1><p style="font - size: 1rem">' + marcador.direccion + '</p>' +/*<img src="' + url + '"/>'</div>');

          marker.bindPopup(popup);
        }

        
      });
      
      this.map.addLayer(markers);

      
    }
  }
}

</script>

<style>
#map {
  height: 80vh !important;
}


@media screen and (max-width: 991px) {
    .filtros{
      display: none !important;
    }
  }

  .marcador {
    background-color: #3146c2;
    color:white;
    font-size:1rem;
    border:0px solid black;
    border-radius:10px;
    overflow:visible;

}
.marcador p{
    border:0px;
    margin:0px;
    font-weight:bold;
    text-align:center;
}

.flecha-down {
    width: 0px;
    height: 0px;
    border-left: 10px solid transparent; /* izquierda flecha */
    border-right: 10px solid transparent; /* derecha flecha */
    border-top: 11px solid #3146c2; /* base flecha y color*/
    font-size: 0px;
    line-height: 0px;
}

.leaflet-div-icon{
    border:0px;
    background-color: transparent;
}


</style>