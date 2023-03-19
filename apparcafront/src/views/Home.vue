<template>
    <div >
      <div id="map" class="z-4 position-absolute w-100" style="margin-top:6vh;"></div>
      <div class="z-2 w-100   position-absolute">
        <div class="row bg-white m-0 ps-5 pe-5 w-100 filtros" style="height:6vh;display: flex;  align-items: center;">
          <input type="text" class="col-2 h-75 rounded btn border text-start me-3" v-model="filtroPlazas.direccion"  placeholder="Direccion, Ciudad..." >
          <div class="col-xl-2 col-3 h-100 p-0 me-3">
            <time-component class="h-100 p-0 m-0" @getDataHoras="getDataHoras"></time-component>
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
      
        <!--<router-link to="/About">About</router-link>-->
      
    </div>
</template>

<script>
//import inicioPlazas from './components/Plazas.vue'
import L from 'leaflet';
import 'leaflet.markercluster';

import DateComponent from '../components/DateComponent.vue'
import TimeComponent from '../components/TimeComponent.vue'
import FiltrosComponent from '../components/FiltrosComponent.vue'
import SliderComponent from '../components/SliderComponent.vue'
import InputNumberComponent from '../components/InputNumberComponent.vue'


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
              latitudMaxima: "38,79182",
              latitudMinima: "36,00000",
              longitudMaxima: "3,03981",
              longitudMinima: "-9,30178"
            },
            
        }
    },
  components: {
    DateComponent,
    TimeComponent,
    FiltrosComponent,
    SliderComponent,
    InputNumberComponent
  },
  async mounted() {

    this.map = L.map('map').setView([38.345169, -0.491991], 13)
    // Agregar una capa de mapa base
    L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
      maxZoom: 20,
      minZoom: 6
    }).addTo(this.map);

    await this.GetPlazasFiltradas();
    console.log("hola")
    this.initMap();

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
    async GetPlazasFiltradas(){
      console.log(this.filtroPlazas)

      const formData = new FormData();

      for (const key in this.filtroPlazas) {
        formData.append(key, this.filtroPlazas[key]);
      }

      fetch('https://localhost:7207/Plazas/Filtrado', {
      method: 'POST',
      body: formData
      })
      .then(response => response.json())
      .then(data => {
        console.log(data, "hola 1")
        this.plazasApi = data
        })
      .catch(error => console.error(error))

    },
    initMap() {
      console.log("boroooooooooooooo"+this.plazasApi)
      var markers = L.markerClusterGroup();

        this.plazasApi.forEach(plaza => {
          var marker = L.marker([plaza.latitud, plaza.longitud]);
          markers.addLayer(marker);
        });

        this.map.addLayer(markers);
    }
  }
}

</script>

<style>
#map {
  height: 80vh !important;
  z-index: 1!important;
}


@media screen and (max-width: 991px) {
    .filtros{
      display: none !important;
    }
  }



</style>