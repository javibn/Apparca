<template>
  <div class="slider-demo-block">
    <el-slider v-model="precio" :marks="marks" @change="setData" :format-tooltip="formatValue" />
  </div>
</template>
<script>
export default {
  name: 'SliderComponent',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            precio:""
        }
    },
  methods: {
    setData() {
      this.$emit("getDataPrecio", this.precio);
    }
  }
}
</script>

<script setup>

const marks = {
  0: '0€',
  100: '100€',
}

const formatValue = (value) => {
  return `${value}€`
}
</script>
<style>
.slider-demo-block {
  display: flex;
  align-items: center;
}

.el-slider__stop{
  display: none !important;
}

.slider-demo-block .el-slider {
  margin-top: 0;
  margin-left: 12px;
}
</style>