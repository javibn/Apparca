<template >
    <div>
      <vue-google-autocomplete  id="mapControl" class="form-control" placeholder="Direccion" v-on:placechanged="getAddressData"> 
            </vue-google-autocomplete >
      <input-number-component></input-number-component>
    </div>
</template>
<script>
  import VueGoogleAutocomplete from "vue-google-autocomplete";
  import InputNumberComponent from './InputNumberComponent.vue'
  
  export default {
  name: 'PruebA',
  data: function() {
        return {
            
        }
    },
  components: {
    InputNumberComponent,
    VueGoogleAutocomplete
  },
  }
  </script>