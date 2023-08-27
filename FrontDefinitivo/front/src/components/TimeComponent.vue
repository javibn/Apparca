<template>
  <div class="demo-time-range row m-0" >
    <el-time-select class="col-6 p-0 pe-1 select-menu" 
      v-model="time.startTime"
      :max-time="time.endTime"
      placeholder="Desde"
      start="00:00"
      step="00:15"
      end="23:45"
      @change="setData"
    />
    <el-time-select class="col-6 p-0 ps-1" 
      v-model="time.endTime"
      :min-time="time.startTime"
      placeholder="Hasta"
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
    box-shadow: 0 0 5px rgba(0,0,0,0.1);
    border: 2px solid #1C4F58;
    border-radius: 5px;
    color: #1C4F58;
}

.el-icon svg path{
  fill: #1C4F58;
  height: 200px !important;
}

.el-input__inner::placeholder{
  color: #1C4F58 !important;
}

.demo-time-range{
  height: 55px;
}

@media screen and (max-width: 1400px) {
  .agrandar .el-select{
    width: 100%;
    padding: 0px !important;
    margin-bottom: 10px !important;
  }

  .agrandar{
    height: 130px;
  }
}

@media screen and (max-width: 992px) {
  .agrandar .el-select{
    width: 49%;
    padding: 0px !important;
    margin-bottom: 0px !important;
  }

  .agrandar .el-select:first-child{
    margin-right: 2%;
  }

  .agrandar{
    height: 60px;
  }
}

@media screen and (max-width: 576px) {
  .agrandar .el-select{
    width: 100%;
    padding: 0px !important;
    margin-bottom: 15px !important;
  }
  .agrandar{
    height: 140px;
  }
}
</style>