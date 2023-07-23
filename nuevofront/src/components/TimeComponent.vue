<template>
  <div class="demo-time-range row ">
    <el-time-select class="col-12 p-0"
      v-model="time.startTime"
      :max-time="endTime"
      placeholder="10:00"
      start="00:00"
      step="00:15"
      end="23:45"
      @change="setData"
    />
    <el-time-select class="col-12 p-0 mt-3"
      v-model="time.endTime"
      :min-time="time.startTime"
      placeholder="18:00"
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
<style scoped>
.el-select{
  border: 2px solid #133C44;
  border-radius: 5px;
}
</style>