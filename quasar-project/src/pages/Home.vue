<template>
  <div class="position-absolute z-n1 top-0 contenedorFondo">
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
          <select style="border-radius:10px; width:100%; height: 40%; text-align: center;
          border: 1px solid red">
            <option>
              <svg xmlns="http://www.w3.org/2000/svg" width="16"
               height="16" fill="currentColor" class="bi bi-airplane"
                viewBox="0 0 16 16">
                <path d="M6.428 1.151C6.708.591 7.213 0 8 0s1.292.592 1.572
                 1.151C9.861 1.73 10 2.431 10 3v3.691l5.17 2.585a1.5 1.5 0
                  0 1 .83 1.342V12a.5.5 0 0 1-.582.493l-5.507-.918-.375 2.253
                   1.318 1.318A.5.5 0 0 1 10.5 16h-5a.5.5 0 0 1-.354-.854l
                   1.319-1.318-.376-2.253-5.507.918A.5.5 0 0 1 0 12v-1.38
                   2a1.5 1.5 0 0 1 .83-1.342L6 6.691V3c0-.568.14-1.271.42
                   8-1.849Zm.894.448C7.111 2.02 7 2.569 7 3v4a.5.5 0 0 1
                   -.276.447l-5.448 2.724a.5.5 0 0 0-.276.447v.792l5.418
                   -.903a.5.5 0 0 1 .575.41l.5 3a.5.5 0 0 1-.14.437L6.708
                    15h2.586l-.647-.646a.5.5 0 0 1-.14-.436l.5-3a.5.5 0 0
                     1 .576-.411L15 11.41v-.792a.5.5 0 0 0-.276-.447L9.276
                      7.447A.5.5 0 0 1 9 7V3c0-.432-.11-.979-.322-1.401C8.
                      458 1.159 8.213 1 8 1c-.213 0-.458.158-.678.599Z"/>
              </svg>
              <div style="height: 20px; width: 20px; background-color: red;">
                hola
              </div>
              Coche
            </option>
            <option style="background-color: black;">Moto</option>
          </select>
        </div>
        <div class="col-4">
          <p class="mb-2">Dónde</p>
          <vue-google-autocomplete  id="mapControl" class="form-control"
          placeholder="Direccion, Ciudad..." v-on:placechanged="changeAddress">
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
