<template>
    <div>
        <div class="container bg-danger" style="height:10%; margin-top:2%">
          <h2 class="text-dark">Sube tu plaza</h2>
          <hr class="border border-dark border-1 col-12 mx-auto opacity-50 m-0"> 
        </div>  
        <step-component/>
    </div>
</template>

<script>

import StepComponent from '../components/StepComponent.vue'

export default {
  name: 'SubirPlaza',
  components: {
    StepComponent
  },
}

</script>

<style>

</style>