<template>
  <div class="demo-time-range row h-75">
    <el-time-select class="col-6 h-100 p-0 pe-1"
      v-model="time.startTime"
      :max-time="endTime"
      placeholder="Entrada"
      start="00:00"
      step="00:15"
      end="23:45"
      @change="setData"
    />
    <el-time-select class="col-6 p-0 ps-1"
      v-model="time.endTime"
      :min-time="time.startTime"
      placeholder="Salida"
      start="00:00"
      step="00:15"
      end="23:45"
      @change="setData"
    />
  </div>
</template>

<script>
export default {
  name: 'TimeComponent',
  data: function() {
        return {
            // TODO: crear variables de datos para el funcionamiento del componente
            time:{
              startTime:"",
              endTime:""
            }
        }
    },
  methods: {
    setData() {
      console.log(this.time);
      this.$emit("getDataHoras", JSON.stringify(this.time));
    }
  }
}
</script>

<style>
.select-trigger{
    height: 100% !important;
    display: flex;
    justify-content: center;
    align-items: center;
}

.el-input{
    height: 100%;
}

</style>