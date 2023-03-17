<template>
  <el-button class="fs-5 h-100 border-0 pt-3 ps-5" @click="drawer = true">
    <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-filter me-3" viewBox="0 0 16 16">
      <path d="M6 10.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5zm-2-3a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm-2-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z"/>
    </svg>
    Filtros de Busqueda
  </el-button>

  <el-drawer v-model="drawer" title="I am the title" :with-header="false" style="height: 86vh;width:100%; margin-top:8vh" class="position-absolute z-1">
    <p>holaaaaaa</p>
    <date-component class=""></date-component>
  </el-drawer>
</template>
<script>
import DateComponent from '../components/DateComponent.vue'

export default {
  name: 'HomeA',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            plazasApi: [],
            map : {},
        }
    },
  components: {
    DateComponent
  },
  async mounted() {

    
  },
  methods: {
    
  }
}
</script>


<script setup>
import { ref } from 'vue'
const drawer = ref(false)
</script>
<style>
.el-drawer{
  width: 75% !important;
  background-color: red !important;
  z-index: 5 !important;
  position: absolute !important;
}
</style>