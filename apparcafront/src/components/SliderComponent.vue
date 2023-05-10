<template>
  <div class="slider-demo-block row m-0">
    <el-slider v-model="precio" class="col-12 pe-5" :max="this.max"  :min="this.min" :marks="this.marks" @change="setData" :format-tooltip="formatValue" />
    <span class="col-2 text-grey">{{min}}€</span>
    <span class="offset-8 col-2 text-grey text-end  p-0">{{max}}€</span>
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
            precio:this.max,
            /*marks:{
              0: 0 + '€',
              100: "100€"
            }*/
            
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