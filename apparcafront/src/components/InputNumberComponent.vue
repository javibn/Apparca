<template>
    <div>
        <el-input-number class="w-100" v-model="ancho" :step="10" :min="100" :max="1000" @change="setData" />
    </div>
</template>

<script>
export default {
  name: 'NumberComponent',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            ancho:""
        }
    },
  methods: {
    setData() {
      console.log(this.ancho)
      this.$emit("getDataAncho", this.ancho);
    }
  }
}
</script>
<style>

</style>