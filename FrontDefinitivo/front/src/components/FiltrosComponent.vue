<template>
    <div class="col-lg-3 mt-4">
      <a class="col-12 btn fw-semibold text-white rounded-4 p-3 botonFiltro" style="background-color: #205760;">Ver vista mapa</a>
      <div class="col-12 mx-auto bg-white">
        <form class="col-12  px-3" style="border-radius: 25px 25px 0px 0px;">
          <p class="text-center pt-3 mb-0 fw-semibold botonFiltro" style="color:#205760; font-size: 1.1rem;">Filtros <span
              style="background-color: #fa8e00;" class="rounded-5 px-2">4</span></p>
          <hr class="mt-2 text-warning botonFiltro">
          <div class="row m-0  mt-2 pb-3">
            <div class="col-lg-12 col-sm-6 p-0 pe-2 tbFiltro">
              <p class="mb-2 fw-semibold">Para qué vehiculo</p>
              <input-car @getDataCar="getDataCar" ref="refInputCar"></input-car>
            </div>
            <div class="col-lg-12 col-sm-6 m-0 p-0 mt-lg-3 tbFiltro">
              <p class="mb-2 fw-semibold">Dónde</p>
              <address-browser-component @getDataBrowser="getDataBrowser" ref="refInputAddress"></address-browser-component>
            </div>
            <div class="col-12 mt-3 p-0">
              <p class="mb-1 fw-semibold">Cuándo</p>
              <time-component class="agrandar" @getDataHoras="getDataHoras" ref="refInputHours"></time-component>
            </div>
            <div class="col-12 mt-3 p-0">
              <p class="mb-1 fw-semibold">Precio</p>
              <slider-price-component :max="100" :min="0" ref="sliderPrice"  @getDataPrecio="getDataPrecio"></slider-price-component>
            </div>
            <div class="col-12 mt-3 p-0">
              <p class="mb-1 fw-semibold">Disponibilidad</p>
              <v-combobox
                class="mt-3"
                v-model="select"
                :items="items"
                label="Dias"
                multiple
                chips
                @update:modelValue="onInput"
              />
            </div>
            <div class="accordion col-12 p-0" id="accordionPanelsStayOpenExample">
              <div class="accordion-item border-0">
                <h2 class="accordion-header">
                  <button class="accordion-button collapsed p-0 mb-3 mt-4 fw-semibold" type="button"
                    data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true"
                    aria-controls="panelsStayOpen-collapseOne">
                    Tamaño (m)
                  </button>
                </h2>
                <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse">
                  <div class="accordion-body px-0 pt-2 row">
                    <div class="col-6">
                      <input type="number" min="0" step="0.1" v-model="alto" @change="handleSize(true)" placeholder="Alto" class="form-control inputSize">
                    </div>
                    <div class="col-6">
                      <input type="number" min="0" step="0.1" v-model="ancho" @change="handleSize(false)" placeholder="Ancho" class="form-control inputSize">
                    </div>
                  </div>
                </div>
              </div>
              <div class="accordion-item border-0">
                <h2 class="accordion-header">
                  <button class="accordion-button collapsed p-0 mb-3 mt-4 fw-semibold" type="button"
                    data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseTwo" aria-expanded="false"
                    aria-controls="panelsStayOpen-collapseTwo">
                    Servicios
                  </button>
                </h2>
                <div id="panelsStayOpen-collapseTwo" class="accordion-collapse collapse">
                  <div class="accordion-body pt-1 px-1">
                    <div class="form-check form-switch d-flex align-items-center ms-4 mb-2" style="height: 40px;">
                      <input ref="myCheckbox0" class="form-check-input h-50 mt-0 me-3" type="checkbox" role="switch" @change="handleChange(0)">
                      <img src="../assets/iconoWc.png" class="h-100">
                    </div>
                    <div class="form-check form-switch d-flex align-items-center ms-4 mb-2" style="height: 40px;">
                      <input ref="myCheckbox1" class="form-check-input h-50 mt-0 me-3" type="checkbox" role="switch" @change="handleChange(1)">
                      <img src="../assets/iconoSeguridad.png" class="h-100">
                    </div>
                    <div class="form-check form-switch d-flex align-items-center ms-4" style="height: 40px;">
                      <input ref="myCheckbox2" class="form-check-input h-50 mt-0 me-3" type="checkbox" role="switch" @change="handleChange(2)">
                      <img src="../assets/icono24horas.png" class="h-100">
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <input class="text-center fw-bold mt-2" style="color: #205760;" @click="BorrarFiltros" value="Borrar filtros" type="reset"/>
          </div>
        </form>
      </div>
    </div>    
</template>
  
  <script>
    import AddressBrowserComponent from './AddressBrowserComponent.vue'
    import TimeComponent from './TimeComponent.vue'
    import SliderPriceComponent from './SliderPriceComponent.vue'
    import InputCar from './InputCarComponent.vue'
    export default {
        name: 'FiltrosComponent',
        data: function() {
            return {
              select: [],
              items: [
                'Lunes',
                'Martes',
                'Miercoles',
                'Jueves',
                'Viernes',
                'Sabado',
                'Domingo',
              ],
              alto: "Alto",
              ancho: "Ancho",
              diasSemana: {
                Lunes: 0,
                Martes: 1,
                Miercoles: 2,
                Jueves: 3,
                Viernes: 4,
                Sabado: 5,
                Domingo: 6,
              }
            }
        },
        components:{
            AddressBrowserComponent,
            TimeComponent,
            SliderPriceComponent,
            InputCar
        },
        methods: {
          getDataCar(data) {
            this.$emit("getDataCar", data);
          },
          getDataBrowser(inputValue, centro, isCorrect){
            this.$emit("getDataBrowser", inputValue, centro, isCorrect);
          },
          getDataHoras(data){
            this.$emit("getDataHoras", data);
          },
          getDataPrecio(data){
            this.$emit("getDataPrecio", data);
          },
          handleChange(servicio) {
            this.$emit("getDataServicio", servicio, this.$refs["myCheckbox"+servicio].checked);
          },
          onInput() {
            console.log(this.select)
            var arregloDias = [false, false, false, false, false, false, false];

            for (const key in this.select) {
              var nombreDia = this.select[key]
              console.log(nombreDia)
              const numeroDia = this.diasSemana[nombreDia];
              console.log(numeroDia)
              arregloDias[numeroDia] = true
            }
            this.$emit("getDataDias", arregloDias)
          },
          handleSize(esAlto){
            if(esAlto){
              this.$emit("getDataAlto", this.alto);
            }else{
              this.$emit("getDataAncho", this.ancho);
            }
          },
          CambiarOptionsHome(data){
            this.$refs.refInputCar.cambiarOption(document.getElementById(data.nombre))
            this.$refs.refInputAddress.CambiarDireccion(data.direccion)
            this.$refs.refInputHours.CambiarHoras(data.horas)
          },
          BorrarFiltros(){
            console.log("hola")
            this.select = []
            this.$refs.sliderPrice.Resetear()
            this.$refs.refInputCar.cambiarOption(document.getElementById("Coche"))
          }
        }
    }
  </script>
  
  <style>

.accordion-button{
  background-color: white !important;
  box-shadow: none !important;
}

.v-field__outline::before{
  border-bottom: 2px solid #1C4F58 !important;
}

.v-field__outline{
  --v-field-border-opacity:1 !important;
}

.v-chip__underlay{
  background-color: #1C4F58 !important;
}

.form-check-input:checked{
  background-color: #1C4F58 !important;
  border-color: #1C4F58 !important;
}

.inputSize{
  border: 2px solid #1C4F58 !important;
}

  @media screen and (max-width: 992px) {
    .botonFiltro{
      display: none !important;
    }
  }
  
  </style>