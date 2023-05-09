<template>
  <div class="slider-demo-block">
    <el-slider v-model="precio" :max="this.max" :min="this.min" :marks="marks" @change="setData" :format-tooltip="formatValue" />
  </div>
</template>
<script>

export default {
  name: 'SliderComponent',
  props:{
    max: {
      type: Number,
      default: 0
    },
    min: {
      type: Number,
      default: 0
    }
  },
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            precio:"",
            marks : {
              [this.min]: this.min + '€',
              [this.max]: this.max + '€',
            }
        }
    },
    mounted(){
      console.log(this.min+this.max)
    },
  methods: {
    setData() {
      this.$emit("getDataPrecio", this.precio);
    },
    formatValue(value){
      return `${value}€`
    }
  }
}
</script>

<script setup>


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