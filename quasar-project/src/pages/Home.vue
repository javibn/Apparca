<template>
  <div class="position-absolute z-n1 top-0 contenedorFondo">
    </div>
    <div class="contenedorFondo2">
    </div>
  <div>
    <div class="col-xl-3 col-lg-5 col-md-7 col-sm-9 col-10 mx-auto pb-3 logo" >
      <img src="../assets/logo.svg" class="w-100">
    </div>
    <div class="bg-light col-5 mx-auto filtro px-3" style="border-radius: 25px 25px 0px 0px;">
      <h2 class="text-center py-3 mb-0 fw-bold"
      style="color:#133C44; font-size: 2rem;">Encuentra aparcamiento</h2>
      <div class="row m-0 ps-3 pe-3 mt-2 pb-3">
        <div class="col-4 p-0 pe-2">
          <p class="mb-2 fw-semibold">Para qué vehiculo</p>
          <q-select filled v-model="model" :options="options"
            color="black" outlined label-class="label-custom-style"
            :options-html="optionsHtml" label="Coche">
          </q-select>
        </div>
        <div class="col-4">
          <p class="mb-2">Dónde</p>
          <vue-google-autocomplete  id="mapControl" class="form-control"
          placeholder="🙄Direccion, Ciudad..." v-on:placechanged="changeAddress">
          </vue-google-autocomplete >
        </div>
        <div class="col-4">
          <p>Cuándo</p>
          <time-component></time-component>
        </div>
      </div>
    </div>
    <div class="col-5 mx-auto p-0 " style="border-radius: 0px 0px 25px 25px;
    background-color: #205760;">
      <h5 class="text-center p-2 py-4 text-white">Encontrar aparcamiento</h5>
    </div>

    <div class="bg-light col-5 mx-auto " style="border-radius: 25px 25px 0px 0px;
    margin-top: 500px;">
      <h2 class="text-center pt-4 mb-0" style="color:#240d46;">Alquila tu plaza de garaje</h2>
      <p class="mt-5 text-center pb-4 mb-0" style="font-size: 1.1rem; padding: 0px 5rem 0rem 5rem;">
        Sácale partido a esa plaza de garaje que no usas. Date de alta en la app,
        configura tus preferencias y ¡empieza a ganar!</p>
    </div>
    <div class="col-5 mx-auto p-0 " style="background-color: #3e265a;">
      <p class="text-center pb-4 text-white fw-bold pt-2 mb-0" style="font-size: 1.2rem;
      padding: 0px 4rem 0rem 4rem;">
        ¡SI ERES UNO DE LOS 1.000 PRIMEROS EN APUNTARSE NO PAGAS TARIFA DE PUBLICACIÓN
         DURANTE 1 AÑO!
      </p>
    </div>
    <div class="col-5 mx-auto p-0 " style="border-radius: 0px 0px 25px 25px;
    background-color: #ff8e01;">
      <h4 class="text-center p-2" style="color: #380724;">Saber más</h4>
    </div>
  </div>
</template>

<script>
import { ref } from 'vue';
import VueGoogleAutocomplete from 'vue-google-autocomplete';
// import TimeComponent from "../components/TimeComponent.vue";
export default {
  name: 'HomePage',
  setup() {
    return {
      model: ref(null),
      optionsHtml: ref(true),

      options: [
        {
          label: '<img src="/src/assets/iconoCoche.png" height="28" width="28"><span class="ms-3 mt-5" style="font-size:1rem;">Coche</span>',
          value: 'Google',
        },
        {
          label: '<img src="/src/assets/iconoMoto.png" height="28" width="28"><span class="ms-3 mt-5" style="font-size:1rem;">Moto</span>',
          value: 'Google',
        },
      ],
    };
  },
  components: {
    VueGoogleAutocomplete,
    // TimeComponent
  },
  computed: {

  },
  methods: {

  },
};

</script>

<style>
.contenedorFondo {
  background-image: url(../assets/fondoApparca2.png);
  background-size: cover;
  width: 100%;
  height: 180%;
  background-position: center;
}
.contenedorFondo2 {
  position: absolute;
  background-color: red;
  width: 100%;
  height: 200px;
}
.row{
  width: auto;
}
.logo{
  margin-top: 7rem;
}

.filtro{
  margin-top: 5rem;
}

@media screen and (max-width: 992px) {
  .logo{
    margin-top: 4rem
  }
}
</style>
