<template >
    <div class="h-100" style="display: flex; flex-direction: column;">
    <div id="contenido" class="mt-3 pb-3" style="flex-grow: 1; min-height: 60vh;">
      
      <div v-if="this.active==0">
        <div class="row mb-3">
          <div class="col-12  ">
            <vue-google-autocomplete  id="mapControl" class="form-control" placeholder="Direccion" v-on:placechanged="getAddressData"> 
            </vue-google-autocomplete >
            <div class="valid-feedback">
              Direccion correcta
            </div>
            <div class="invalid-feedback">
              Introduce una dirección correcta en España
            </div>
          </div>
        </div>

        <div class="row mb-4">
          
          <div class="col">
            <input type="text" class="form-control" id="paisControl" placeholder="Localidad" disabled>
          </div>

          <div class="col ms-2">
            <input type="text" class="form-control" id="cpControl" placeholder="CP" disabled>
          </div>

          <div class="col ms-2">
            <input type="text"  class="form-control" id="numberControl" placeholder="Número" disabled>
            <div class="invalid-feedback">
              Introduce una dirección con numero
            </div>
          </div>
        </div>

        <div id="mapaForm" style="height:250px; width:100%;" ></div>

        <div class="row col-10 mx-auto mt-5 mb-4">
          <div class="col-md-6">
            <label class="form-label">Ancho de la plaza (cm)</label>
            <input-number-component id="anchoControl" class="pac-target-inputis-valid is-invalid" @getDataAncho="getDataAncho"/>
            <div class="invalid-feedback">
              Introduce el ancho de tu plaza
            </div>
            <div class="valid-feedback">
              Ancho correcto
            </div>
          </div>

          <div class="col-md-6">
            <label class="form-label">Largo de la plaza (cm)</label>
            <input-number-component id="largoControl" class="pac-target-inputis-valid is-invalid" @getDataAncho="getDataLargo"/>
            <div class="invalid-feedback">
              Introduce el largo de tu plaza
            </div>
            <div class="valid-feedback">
              Largo correcto
            </div>
          </div>
        </div>
      </div>
      <div v-if="active==1" class="row p-0">
        <div class="col-md-6 mb-md-5 mb-1 h-100">
          <label class="form-label fs-5 w-100">Fechas de Alquiler</label>
            <label class="mb-2 text-grey">Desde cuando y hasta cuando estará en alquiler la plaza</label>
            <date-component class="h-100 form-control" id="dateControl" @getDataFecha="getDataFecha" />
            <div class="valid-feedback text-center">
              Fechas Correctas
            </div>
        </div>
        <div class="col-md-6 h-100 mb-md-5 mb-1">
          <label class="form-label fs-5 w-100">Horario de alquiler</label>
          <label class="mb-2 text-grey">Horario diario en el que se alquila</label>
            <time-component class="h-100 ms-0 form-control"  id="timeControl" @getDataHoras="getDataHoras"></time-component>
            <div class="valid-feedback text-center">
              Horario Correcto
            </div>
            <div class="invalid-feedback text-center">
              Determine el horario completo
            </div>
        </div>
        <div class="col-md-6 h-100">
            <label class="form-label fs-5 w-100">Precio Mensual</label>
            <label class="mb-2 text-grey">Precio que se pagará al mes por la plaza</label>
            <div class="input-group">
              <input
                type="number"
                id="priceControl"
                @input="validatePrice" class="form-control"
              >
              <span class="input-group-text text-success rounded-end">€/mes</span>
              <div class="valid-feedback">
                Precio mensual correcto
              </div>
              <div class="invalid-feedback">
                El precio mensual deber ser mayor que 0
              </div>
            </div>
        </div>
        <div class="col-md-6 h-100">
            <label class="form-label fs-5 w-100">Fianza</label>
            <label class="mb-2 text-grey">Precio de la fianza por la posible perdida del mando del garaje</label>
            <div class="input-group">
              <input
                type="number"
                id="fianzaControl"
                @input="validateFianza" class="form-control"
              >
              <span class="input-group-text text-success rounded-end" id="basic-addon2">€</span>
              <div class="valid-feedback">
                Precio de la fianza correcto
              </div>
              <div class="invalid-feedback">
                El precio de la fianza deber ser positivo
              </div>
            </div>
            
        </div>
      </div>
      <div v-if="active==2" class="row">
        <div class="col-6 row m-0 mt-5">
          <h5 class="text-center">Imagen de tu plaza</h5>
          <div class="col-8 mx-auto mt-5">
            <input type="file" v-on:change="cambioImagen" class="form-control">
          </div>
          <img v-bind:src="imagenUrl" id="preview" style="height: 230px; object-fit: cover;" class="col-6 mx-auto mt-5 rounded-5">
        </div>
        <div class="col-6  d-flex align-items-center justify-content-center">
          <div class="w-100">
            <h5 class="text-center">Descipción de tu plaza</h5>
            <label class="text-grey mt-4">Será la información que los usuarios vean antes de decidir si alquilan tu plaza</label>
            
            <v-textarea v-model="plaza.descripcion"
              bg-color="grey-lighten-3"
              color="blue"
              label="Describe tu plaza..."
              class="mt-4"
            ></v-textarea>
          </div>
        </div>
        
        
        
        
      </div>
    </div>
    <div class="container" style="height:130px">
      <el-steps :active="active" class="container" style="height:70px" finish-status="success" >
        <el-step title="Datos Básicos" />
        <el-step title="Personalización" />
        <el-step title="Descripción e Imagenes" />
      </el-steps>
      
      <button style="margin-top: 12px" v-if="active>0" class="btn btn-dark me-4" id="botonAnterior" @click="last">Anterior</button>
      <button style="margin-top: 12px" v-if="active<2" class="btn btn-dark" id="botonSiguiente" @click="next">Siguiente</button>
      <button style="margin-top: 12px" v-if="active==2" class="btn btn-dark" id="botonEnviar" @click="enviar">Publicar</button>
      <!--<el-button style="margin-top: 12px" v-if="active>0"  @click="last">Anterior</el-button>-->
    </div>

    
  </div>
</template>
<script>
  import VueGoogleAutocomplete from "vue-google-autocomplete";
  import InputNumberComponent from './InputNumberComponent.vue'
  import L from 'leaflet';
  import DateComponent from '../components/DateComponent.vue'
  import TimeComponent from '../components/TimeComponent.vue'
  import axios from 'axios';
  import { mapState } from 'vuex';

  export default {
  name: 'PruebA',
  data: function() {
      return {
          plaza: {
            direccion:"",
            cp:"",
            localidad: "",
            numero:"",
            ancho:"",
            largo:"",
            latitud : "",
            longitud : "",
            precioMes:"",
            precioMando:"",
            startTime:"",
            endTime:"",
            fechaInicio:"",
            fechaFinal:"",
            descripcion:null
          },
          active:0,
          mapa: "",
          markers : "",
          imagen:null,
          imagenUrl:"https://us.123rf.com/450wm/mattbadal/mattbadal1911/mattbadal191100006/135029891-falta-la-p%C3%A1gina-de-imagen-para-el-dise%C3%B1o-del-sitio-web-o-el-dise%C3%B1o-de-la-aplicaci%C3%B3n-m%C3%B3vil-no-hay.jpg?ver=6"
        }
    },
  components: {
    InputNumberComponent,
    VueGoogleAutocomplete,
    DateComponent,
    TimeComponent
  },
  computed:{
        ...mapState(['isLoggedIn']),
        ...mapState(['token']),
        ...mapState(['name'])
    },
  mounted(){
    const direccionInput = document.getElementById('mapControl');

    if(direccionInput){
      direccionInput.addEventListener('input', this.escucharDireccion);
    }

    setInterval(() => {
      this.updateButtonState();
    }, 100)

    if(document.getElementById("mapaForm")){
      this.mapa = L.map('mapaForm').setView([39.850931195377946, -3.1256103515625004], 7)
      //const mapa = this.mapa
      // Agregar una capa de mapa base
      L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
        maxZoom: 20,
        minZoom: 6
      }).addTo(this.mapa);

      this.markers = L.layerGroup().addTo(this.mapa)
    }
    
  },
  methods: {
    next(){
      if (this.active++ > 1) this.active = 2

      console.log(this.plaza)
    },
    last(){
      this.active--

      console.log(this.plaza)
    },
    updateButtonState() {
      //console.log(this.active)
      const botonSiguiente = document.getElementById("botonSiguiente");
      if(this.active == 0){
        if (this.plaza.direccion && this.plaza.ancho && this.plaza.largo) {
          botonSiguiente.disabled = false;
        } else {
          botonSiguiente.disabled = true;
        }
      }else if(this.active==1){
        
        if (this.plaza.startTime && this.plaza.endTime && this.plaza.fechaInicio && document.getElementById("fianzaControl").value>=0 && document.getElementById("priceControl").value>0) {
          botonSiguiente.disabled = false;
        } else {
          botonSiguiente.disabled = true;
        }
      }
    },
    escucharDireccion()
    {

      var inputDireccion = document.getElementById("mapControl")
      inputDireccion.classList = "pac-target-inputis-valid is-invalid form-control"
      
      this.plaza.direccion = "";
      
    },
    getDataAncho(data) {
      var inputAncho = document.getElementById("anchoControl")
      inputAncho.classList = "pac-target-inputis-valid is-valid"

      this.plaza.ancho = data
    },
    getDataLargo(data) {
      var inputLargo = document.getElementById("largoControl")
      inputLargo.classList = "pac-target-inputis-valid is-valid"

      this.plaza.largo = data
    },
    getAddressData(place){
      var inputDireccion = document.getElementById("mapControl")
      var inputNumero = document.getElementById("numberControl")

      console.log(place);
      if(place.country==="España"){
        
        inputDireccion.classList = "pac-target-inputis-valid is-valid form-control"

        var inputPais = document.getElementById("paisControl")
        inputPais.value = place.administrative_area_level_2

        var inputCp = document.getElementById("cpControl")
        inputCp.value = place.postal_code

        

        if(place.street_number){
          inputNumero.classList = "pac-target-inputis-valid is-valid  form-control"
          inputNumero.value = place.street_number
          inputDireccion.value = place.route
          this.contadorStep1++;
          this.plaza.direccion = place.route
          this.plaza.cp = place.postal_code
          this.plaza.localidad = place.administrative_area_level_2
          this.plaza.numero = place.street_number

          this.plaza.latitud = place.latitude.toString().replace(".", ",")
          this.plaza.longitud = place.longitude.toString().replace(".", ",")
        }else{
          inputNumero.value = "Número"
          inputNumero.classList = "pac-target-inputis-valid is-invalid  form-control"
          inputDireccion.classList = "pac-target-inputis-valid is-invalid form-control"
          this.plaza.direccion=""
          
        }
        
        this.mapa.setView([place.latitude, place.longitude],15)


        var marker = L.marker([place.latitude, place.longitude])
        this.markers.clearLayers();
        marker.addTo(this.markers)

      }else{
        inputNumero.classList = "pac-target-inputis-valid is-invalid  form-control"
        inputDireccion.classList = "pac-target-inputis-valid is-invalid form-control"
        this.plaza.direccion=""
      }

    },
    validatePrice() {
      var inputPrecio = document.getElementById("priceControl")
      console.log(inputPrecio.value)
      if(inputPrecio.value > 0){
        inputPrecio.classList = "pac-target-inputis-valid is-valid form-control"
        this.plaza.precioMes = inputPrecio.value
      }else{
        inputPrecio.classList = "pac-target-inputis-valid is-invalid form-control"
      }
      
    },
    validateFianza() {
      var inputPrecio = document.getElementById("fianzaControl")
      console.log(inputPrecio.value)
      if(inputPrecio.value >= 0){
        inputPrecio.classList = "pac-target-inputis-valid is-valid form-control"
        this.plaza.precioMando = inputPrecio.value
      }else{
        inputPrecio.classList = "pac-target-inputis-valid is-invalid form-control"
      }
      
    },
    getDataFecha(data){
      var inputFecha = document.getElementById("dateControl")
      inputFecha.classList = "pac-target-inputis-valid is-valid form-control"
      
      console.log(data)

      var fechaInicial = data[0];
      var fechaFinal = data[1];

      var añoInicial = fechaInicial.getFullYear();
      var mesInicial = fechaInicial.getMonth();
      var diaInicial = fechaInicial.getDate();
      this.plaza.fechaInicio = new Date(añoInicial, mesInicial, diaInicial).toLocaleDateString("es");
      console.log(this.plaza.fechaInicio)

      var añoFinal = fechaFinal.getFullYear();
      var mesFinal = fechaFinal.getMonth();
      var diaFinal = fechaFinal.getDate();
      this.plaza.fechaFinal = new Date(añoFinal, mesFinal, diaFinal).toLocaleDateString("es");
      console.log(this.plaza.fechaFinal)
    },
    getDataHoras(data) {
      var horario = JSON.parse(data)
      this.plaza.startTime = horario.startTime
      this.plaza.endTime = horario.endTime

      var inputFecha = document.getElementById("timeControl")
      if(this.plaza.startTime && this.plaza.endTime){
        inputFecha.classList = "pac-target-inputis-valid is-valid form-control"
      }else{
        inputFecha.classList = "pac-target-inputis-valid is-invalid form-control"
      }
    },
    async enviar(){
      console.log(this.plaza)
      console.log(this.token)
      
      const formData = new FormData();
      formData.append('direccion', this.plaza.direccion);
      formData.append('cp', this.plaza.cp);
      formData.append('localidad', this.plaza.localidad);
      formData.append('numero', this.plaza.numero);
      formData.append('ancho', this.plaza.ancho);
      formData.append('largo', this.plaza.largo);
      formData.append('latitud', this.plaza.latitud);
      formData.append('longitud', this.plaza.longitud);
      formData.append('precioMes', this.plaza.precioMes);
      formData.append('precioMando', this.plaza.precioMando);
      formData.append('startTime', this.plaza.startTime);
      formData.append('endTime', this.plaza.endTime);
      formData.append('fechaInicio', this.plaza.fechaInicio);
      formData.append('fechaFinal', this.plaza.fechaFinal);
      formData.append('descripcion', this.plaza.descripcion);
      formData.append('file', this.imagen);
      
      console.log(formData)
      try {
        const response = await axios.post('https://localhost:7207/Plazas', formData, {
          headers: {
            'Content-Type': 'multipart/form-data',
            'Authorization': `Bearer ${this.token}`
          }
        });
        console.log(response.data);
      } catch (error) {
        console.error(error);
      }
      this.$router.push('/MisPlazas');
    },
    cambioImagen(event) {
      this.imagen = event.target.files[0]
      const file = event.target.files[0];

      const reader = new FileReader();
      const vm = this; // Guardar la referencia al componente de Vue

      reader.onload = function() {
        const arrayBuffer = reader.result; // Obtener los datos de la imagen en formato ArrayBuffer
        const bytes = new Uint8Array(arrayBuffer); // Convertir los datos en un array de bytes
        
        // Guardar los bytes en la propiedad de la plaza
        vm.plaza.imagen = bytes; // Mostrar los bytes en la consola

        const blob = new Blob([bytes], {type: "image/png"});
        vm.imagenUrl = URL.createObjectURL(blob);
      }
      // Leer los datos de la imagen como un ArrayBuffer
      reader.readAsArrayBuffer(file);
    }

  }
  }
  </script>