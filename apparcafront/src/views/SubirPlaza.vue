<template>
    <div v-if="isLoggedIn" style="display: flex; flex-direction: column;">
        <div class="container" style="height:10%; margin-top:2%">
          <h2 class="text-dark">Sube tu plaza</h2>
          <hr class="border border-primary border-1 col-12 mx-auto opacity-50 m-0"> 
        </div>  
        <div class="container" style="min-height:80%;">
          <step-component />
        </div>
    </div>
    <div v-else>
      <denegate-component/>
    </div>
</template>

<script>
import { mapState } from 'vuex';
import StepComponent from '../components/StepComponent.vue'

import DenegateComponent from '../components/DenegateComponent.vue'

export default {
  name: 'SubirPlaza',
  components: {
    StepComponent,
    DenegateComponent
  },
  computed:{
    ...mapState(['isLoggedIn']),
  },
  methods: {
    login() {
      this.$store.commit('login');
    },
    logout() {
      this.$store.commit('logout');
    },
  }
}
</script>

<style>
  .el-input{
    height: 100% ;
  }
</style>