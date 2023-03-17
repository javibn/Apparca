<template>
  <div class="demo-date-picker w-100">
    <el-date-picker
      class="h-100 w-100"
      v-model="fecha"
      type="daterange"
      start-placeholder="Inicio"
      end-placeholder="Final"
      :default-time="defaultTime"
      @change="setData"
      :disabled-date="ComprobarFechas"
    />
  </div>
</template>

<script>

export default {
  name: 'DateComponent',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            fecha:""
        }
    },
  methods: {
    hola(){
      console.log("hola")
    },
    cambio(){
      console.log(this.fecha)
    },
    ComprobarFechas(date){
      const hoy = new Date();
      const ayer = new Date(hoy);
      ayer.setDate(hoy.getDate() - 1);
      return date < ayer;
    },
    setData() {
      //console.log(this.fecha);
      this.$emit("getDataFecha", this.fecha);
    }
  }
}



</script>
