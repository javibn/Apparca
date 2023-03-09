<template>
  <div>
    <div id="map"></div>
    <inicio-plazas />
  </div>
</template>

<script>
import inicioPlazas from './components/Plazas.vue'
import L from 'leaflet';

export default {
  name: 'App',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            plazasApi: 2
        }
    },
  components: {
    inicioPlazas,
  },
  async mounted() {
    await this.getPlazas();
    this.initMap();
  },
  methods: {
    async getPlazas(){
      try {
        const response = await fetch("https://localhost:7207/usuario/plazas");
        const data = await response.json();
        this.plazasApi = data[0]
      } catch (error) {
        console.error(error);
      }
      

    
        console.log(this.plazasApi);
    },
    initMap() {
      console.log(this.plazasApi)
      let map = L.map('map').setView([38.345169, -0.491991], 13);

// Agregar una capa de mapa base
L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
  maxZoom: 20,
  minZoom: 6
}).addTo(map);

// Agregar un marcador al mapa
L.marker([38.345169, -0.491991]).addTo(map);
    }
  }
}
</script>

<style>
#map {
  height: 500px;
}
</style>
