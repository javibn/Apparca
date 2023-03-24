<template>
  <el-scrollbar>
    <div class="scrollbar-flex-content ps-2">
      <div v-for="item in numberOfItems"  :key="item" >
        <div v-if="abierto==item.id" class="scrollbar-demo-item row border border-2 border-success ms-1" style="transform: scale(1);">
          <img src="../../src/assets/plaza.jpg"  class="col-4 h-100 p-0">
          <div class="col-8 row p-0 m-0">
              <h6>
                  <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo-alt-fill" viewBox="0 0 16 16">
                      <path d="M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10zm0-7a3 3 0 1 1 0-6 3 3 0 0 1 0 6z"/>
                  </svg>
                  {{item.direccion}}
              </h6>
              <hr class="border border-black border-1 opacity-100 w-75 mx-auto">
              <div class="row p-0 m-0">
                  <h7 class="col-6" style="font-size:1rem;">{{item.horaInicio}} - {{item.horaFinal}}</h7>
                  <h7 class="col-5 bg-primary  text-white rounded" style="font-size:1rem;">{{item.precioMes}}€/mes</h7>
              </div>
              <a class="col-8 mx-auto p-0 btn btn-light text-dark fw-bold mt-3">VISITAR PLAZA</a>
          </div>
        </div>
        <div v-else class="scrollbar-demo-item row ms-1" style="transform: scale(0.9);">
          <img src="../../src/assets/plaza.jpg"  class="col-4 h-100 p-0">
          <div class="col-8 row p-0 m-0">
              <h6>
                  <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo-alt-fill" viewBox="0 0 16 16">
                      <path d="M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10zm0-7a3 3 0 1 1 0-6 3 3 0 0 1 0 6z"/>
                  </svg>
                  {{item.direccion}}
              </h6>
              <hr class="border border-black border-1 opacity-100 w-75 mx-auto">
              <div class="row p-0 m-0">
                  <h7 class="col-6" style="font-size:1rem;">{{item.horaInicio}} - {{item.horaFinal}}</h7>
                  <h7 class="col-5 bg-primary  text-white rounded" style="font-size:1rem;">{{item.precioMes}}€/mes</h7>
              </div>
              <a class="col-8 mx-auto p-0 btn btn-light text-dark fw-bold mt-3">VISITAR PLAZA</a>
          </div>
        </div>
      </div>
    </div>
  </el-scrollbar>
</template>

<script>
export default {
  props: {
    numberOfItems: [],
    abierto: {
      type: Number,
      default: 0
    }
  }
}
</script>

<style scoped>
.scrollbar-flex-content {
  display: flex;
  height:17vh;
}

.scrollbar-demo-item img{
    object-fit: cover;
}


.scrollbar-demo-item {
  flex-shrink: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 350px;
  height: 100%;
  margin-right: 20px;
  text-align: center;
  border-radius: 4px;
  background: white;
  color: black;
}
</style>
