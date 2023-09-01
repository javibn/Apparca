<template>
  <div class="row container-lg mx-auto p-0 m-0">
    <filtros-component ref="refFiltro" v-if="this.screenWidth >= 992" @PasarDatos="PasarDatos" @limpiarFiltro="limpiarFiltro" @getDataCar="getDataCar" @getDataAncho="getDataAncho" @getDataAlto="getDataAlto" @getDataServicio="getDataServicio" @getDataPrecio="getDataPrecio" @getDataHoras="getDataHoras" @getDataDias="getDataDias" @getDataBrowser="getDataBrowser" class="filtroVista"></filtros-component>
    <div class="col-lg-9 p-0 pt-lg-5 mt-lg-5 mt-3">
      <div class="col-12 d-lg-none mb-4 pb-3 filtroMovil">
        <div class="row m-0">
          <div class="col-6 p-0">
            <a class="text-center mb-0 fw-bold nav-link" data-bs-toggle="collapse" href="#collapseExample" role="button"
              aria-expanded="false" aria-controls="collapseExample" style="color:#205760; font-size: 1.1rem;">Filtros
              <span style="background-color: #fa8e00;" class="rounded-5 px-2">4</span></a>
          </div>
          <div class="col-6 p-0">
            <p class="text-center mb-0 fw-bold" style="color:#205760; font-size: 1.1rem;">Vista mapa</p>
          </div>
          <div class="collapse" id="collapseExample">
            <filtros-component ref="refFiltro" v-if="this.screenWidth < 992" @PasarDatos="PasarDatos" @getDataCar="getDataCar" @getDataAncho="getDataAncho" @limpiarFiltro="limpiarFiltro" @getDataAlto="getDataAlto" @getDataServicio="getDataServicio" @getDataPrecio="getDataPrecio" @getDataHoras="getDataHoras" @getDataDias="getDataDias" @getDataBrowser="getDataBrowser" ></filtros-component>
          </div>
        </div>
      </div>
      <div class="col-11 mx-auto">
        <div class="dropdown custom-dropdown mb-4">
          <a class=" dropdown-toggle" style="color: #205760; text-decoration: none;" type="button"
            id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <span class="fw-semibold">Ordenar:</span> {{this.ordenTextos[this.orden]}}
          </a>
          <ul class="dropdown-menu mt-2" aria-labelledby="dropdownMenuButton" style="cursor: pointer;">
            <li><a class="dropdown-item" @click="CambiarOrden(0)">Más cercanos</a></li>
            <li><a class="dropdown-item" @click="CambiarOrden(1)">Precio menor</a></li>
            <li><a class="dropdown-item" @click="CambiarOrden(2)">Precio mayor</a></li>
          </ul>
        </div>

        <div class="row m-0 rounded-4 plazaItem overflow-hidden">
          <img src="../assets/plaza.jpg" class="col-2 p-0 d-md-block d-none">
          <div class="col-md-6 ">
            <div class="row h-100 align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="../../src/assets/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
          </div>
          <div class="col-md-2 col-6 d-flex align-items-center justify-content-center">
            <div>
              <p class="fw-semibold mb-3" style="color: #133C44;">Servicios</p>
              <div class="m-0">
                <img class="icono p-1" src="../assets/iconoWc.png">
                <img class="icono p-1" src="../assets/iconoSeguridad.png">
                <img class="icono p-1" src="../assets/icono24horas.png">
              </div>
            </div>
          </div>
          <div class="col-md-2 col-6 d-flex align-items-center " style="background-color: #CFE2E4;">
            <div>
              <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
              <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import FiltrosComponent from '../components/FiltrosComponent.vue'
import { mapState } from 'vuex';
import router from '@/router';

export default {
  name: 'VistaLista',
  data: function() {
      return {
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
        orden: 0,
        ordenTextos: ["Más Cercanos", "Precio menor", "Precio mayor"],
        screenWidth: window.innerWidth
      }
  },
  computed:{
      ...mapState(['filtroStore'])
  },
  components:{
    FiltrosComponent
  },
  methods:{
    getDataCar(data) {
      this.filtro.isCoche = data
      this.actualizarResultados()
    },
    getDataHoras(data) {
      this.filtro.horas = data
      this.actualizarResultados()
    },
    getDataPrecio(data) {
      this.filtro.isCoche = data
      this.actualizarResultados()
    },
    getDataBrowser(inputValue, centro, isCorrect){
      this.filtro.inputValue = inputValue
      this.filtro.centro = centro
      this.isCorrect = isCorrect

      this.actualizarResultados()
    },
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
    limpiarFiltro(){
      this.filtro={
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
      }
      this.actualizarResultados()
    },
    actualizarResultados(){
      console.log("Actualizamos")
      console.log(this.filtro)
    },
    CambiarOrden(orden){
      this.orden = orden
      this.actualizarResultados()
    },
    PasarDatos(){
      console.log("Aqui subo los datos en el filtro: vistaLista")
      console.log(this.filtro)
      this.$store.dispatch('PasarDatos', this.filtro)
      router.push({ name: 'VistaMapa' });
    },
  },
  mounted(){    
    if(this.filtroStore != null){
      console.log("Aqui meto los datos en el filtro: vistaLista")
      console.log(this.filtro)
      console.log(this.filtroStore)
      this.filtro = this.filtroStore
      console.log(this.filtro)
      if(typeof this.filtro.horas == 'string'){
        this.filtro.horas = JSON.parse(this.filtro.horas)
      }
      this.$store.dispatch('limpiar')
      console.log(this.filtro)
      this.$refs.refFiltro.MeterDatos(this.filtro)
      console.log(this.filtro)
    }
  }
}

</script>

<style>


    .textoPrimario {
      color: #133C44;
    }

    .custom-dropdown .dropdown-toggle::after {
      display: none;
      /* Ocultar el icono de desplegar predeterminado */
    }

    .custom-dropdown .dropdown-toggle {
      background-image: url('../../src/assets/desplegable.png');
      /* Reemplaza 'ruta_de_la_imagen.png' con la URL de tu imagen */
      background-repeat: no-repeat;
      background-position: right center;
      /* Puedes ajustar la posición de la imagen */
      background-size: 20px;
      /* Ajusta el tamaño de la imagen según tus necesidades */
      padding-right: 30px;
      /* Ajusta el espacio para que la imagen no se superponga con el texto */
    }

    .icono {
      width: 30%;
    }

    .filtroMovil {
      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
      border-radius: 0px 0px 20px 20px;
    }

    @media screen and (max-width: 992px) {
      .filtroVista{
        display: none;
      }
    }

    @media screen and (max-width: 768px) {
      .icono {
        width: 15%;
      }

      .plazaItem {
        background-color: rgba(246, 246, 246, 0.511);
      }
    }
</style>