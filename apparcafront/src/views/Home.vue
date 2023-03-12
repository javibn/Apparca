<template>
    <div>
      <div id="map" style="z-index:0;"></div>
        <!--<router-link to="/About">About</router-link>-->

    </div>
</template>

<script>
//import inicioPlazas from './components/Plazas.vue'
import L from 'leaflet';

export default {
  name: 'HomeA',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            plazasApi: [],
            map : {}
        }
    },
  components: {
    
  },
  async mounted() {
      this.map = L.map('map').setView([38.345169, -0.491991], 13)
      // Agregar una capa de mapa base
      L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
        maxZoom: 20,
        minZoom: 6
      }).addTo(this.map);
    this.initMap();
    await this.getPlazas();
  },
  methods: {
    async getPlazas(){
      try {
        const response = await fetch("https://localhost:7207/usuario/plazas");
        const data = await response.json();
        this.plazasApi = data
        this.plazasApi.forEach(plaza => {
        L.marker([plaza.latitud, plaza.longitud]).addTo(this.map);
      });
      } catch (error) {
        console.error(error);
      }
    },
    initMap() {
      
    }
  }
}

</script>

<style>
#map {
  height: 100%;
  z-index: 1 !important;
}
</style>