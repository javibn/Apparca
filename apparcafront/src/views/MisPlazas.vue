<template>
    <div class="container p-0 pt-5">
        <div>
            <h2 class="text-center">Mis Plazas</h2>
            <div class="text-primary">
                <hr class="">
            </div>
        </div>
        <div v-for="(item, index) in this.plazas" :key="index" class="row rounded-5 m-0 mt-5" style="background-color: #fcfcfc;">
            <img class="col-2 rounded-start-5 p-0" :src=item.imagenSrc>
            <div class="col-3 row m-0">
                <p class="m-0 mt-4 fw-bold">{{ item.direccion }}</p>
                <div class="col-6 text-center">
                    <p>Ancho</p>
                    <p>{{ item.ancho }}cm</p>
                </div>
                <div class="col-6 text-center ">
                    <p>Largo</p>
                    <p>{{ item.largo }}cm</p>
                </div>
            </div>
            <div class="col-3 m-0 d-flex align-items-center">
                <div class="w-100">
                    <div class="row">
                        <div class="col-6 text-center">
                            <p class="mb-1">Desde</p>
                            <p class="mb-1">{{ item.fechaInicio }}</p>
                        </div>
                        <div class="col-6 text-center">
                            <p class="mb-1">Hasta</p>
                            <p class="mb-1">{{ item.fechaFinal }}</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6 text-center">
                            <p class="mb-1">Hora Entrada</p>
                            <p class="mb-1">{{ item.horaInicio }}</p>
                        </div>
                        <div class="col-6 text-center">
                            <p class="mb-1">Hora Salida</p>
                            <p class="mb-1">{{ item.horaFinal }}</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-2 p-0 d-flex align-items-center justify-content-center">
                <div class="pb-5">
                    <p class="mt-0 mb-5 fs-5 text-center">Servicios</p>
                    <div class="d-flex justify-content-center w-100">
                        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-badge-wc" viewBox="0 0 16 16">
                            <path d="M10.348 7.643c0-1.112.488-1.754 1.318-1.754.682 0 1.139.47 1.187 1.108H14v-.11c-.053-1.187-1.024-2-2.342-2-1.604 0-2.518 1.05-2.518 2.751v.747c0 1.7.905 2.73 2.518 2.73 1.314 0 2.285-.792 2.342-1.939v-.114h-1.147c-.048.615-.497 1.05-1.187 1.05-.839 0-1.318-.62-1.318-1.727v-.742zM4.457 11l1.02-4.184h.045L6.542 11h1.006L9 5.001H7.818l-.82 4.355h-.056L5.97 5.001h-.94l-.972 4.355h-.053l-.827-4.355H2L3.452 11h1.005z"/>
                            <path d="M14 3a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h12zM2 2a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2H2z"/>
                        </svg>
                        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-camera ms-5" viewBox="0 0 16 16">
                            <path d="M15 12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V6a1 1 0 0 1 1-1h1.172a3 3 0 0 0 2.12-.879l.83-.828A1 1 0 0 1 6.827 3h2.344a1 1 0 0 1 .707.293l.828.828A3 3 0 0 0 12.828 5H14a1 1 0 0 1 1 1v6zM2 4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6a2 2 0 0 0-2-2h-1.172a2 2 0 0 1-1.414-.586l-.828-.828A2 2 0 0 0 9.172 2H6.828a2 2 0 0 0-1.414.586l-.828.828A2 2 0 0 1 3.172 4H2z"/>
                            <path d="M8 11a2.5 2.5 0 1 1 0-5 2.5 2.5 0 0 1 0 5zm0 1a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7zM3 6.5a.5.5 0 1 1-1 0 .5.5 0 0 1 1 0z"/>
                        </svg>
                        <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-door-open ms-5" viewBox="0 0 16 16">
                            <path d="M8.5 10c-.276 0-.5-.448-.5-1s.224-1 .5-1 .5.448.5 1-.224 1-.5 1z"/>
                            <path d="M10.828.122A.5.5 0 0 1 11 .5V1h.5A1.5 1.5 0 0 1 13 2.5V15h1.5a.5.5 0 0 1 0 1h-13a.5.5 0 0 1 0-1H3V1.5a.5.5 0 0 1 .43-.495l7-1a.5.5 0 0 1 .398.117zM11.5 2H11v13h1V2.5a.5.5 0 0 0-.5-.5zM4 1.934V15h6V1.077l-6 .857z"/>
                        </svg>
                    </div>
                </div>
            </div>
            <div class="rounded-end-5 col-2 p-0 " style="background-color: #f9f9f9;">
                <div class="row p-0 me-5 mb-2 mt-3 justify-content-end" >
                    <div class="col-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                        </svg>
                    </div>
                    <div class="col-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3-fill" viewBox="0 0 16 16">
                        <path d="M11 1.5v1h3.5a.5.5 0 0 1 0 1h-.538l-.853 10.66A2 2 0 0 1 11.115 16h-6.23a2 2 0 0 1-1.994-1.84L2.038 3.5H1.5a.5.5 0 0 1 0-1H5v-1A1.5 1.5 0 0 1 6.5 0h3A1.5 1.5 0 0 1 11 1.5Zm-5 0v1h4v-1a.5.5 0 0 0-.5-.5h-3a.5.5 0 0 0-.5.5ZM4.5 5.029l.5 8.5a.5.5 0 1 0 .998-.06l-.5-8.5a.5.5 0 1 0-.998.06Zm6.53-.528a.5.5 0 0 0-.528.47l-.5 8.5a.5.5 0 0 0 .998.058l.5-8.5a.5.5 0 0 0-.47-.528ZM8 4.5a.5.5 0 0 0-.5.5v8.5a.5.5 0 0 0 1 0V5a.5.5 0 0 0-.5-.5Z"/>
                        </svg>
                    </div>
                    
                    <!--<img src="../assets/iconoEditar.png" class="col-2">
                    <img src="../assets/iconoEliminar.png" class="col-2">-->
                </div>
                <p class="mb-0 fs-5 ps-5">Precio</p>
                <h2 class="text-center">{{ item.precioMes }}€</h2>
            </div>
            
        </div>
    </div>
</template>
<script>
import axios from 'axios';
import { mapState } from 'vuex';

export default {
  name: 'MisPlazas',
  data: function() {
        return {
            plazas:null
        }
    },
  components: {

  },
  computed:{
        ...mapState(['isLoggedIn']),
        ...mapState(['token']),
        ...mapState(['name'])
    },
  async mounted() {
    try {
        const response = await axios.get('https://localhost:7207/Plazas/MisPlazas', {
          headers: {
            'Authorization': `Bearer ${this.token}`
          }
        });
        console.log(response.data);
        this.plazas = response.data
      } catch (error) {
        console.error(error);
      }
      this.plazas.forEach(plaza => {
        var imagenCodificada = URL.createObjectURL(this.base64ToBlob(plaza.imagen));
        console.log(imagenCodificada)
        plaza.imagenSrc = imagenCodificada;
      });
  },
  methods:{
    base64ToBlob(base64) {
      const binaryString = window.atob(base64);
      const byteNumbers = new Array(binaryString.length);
      for (let i = 0; i < binaryString.length; i++) {
        byteNumbers[i] = binaryString.charCodeAt(i);
      }
      const byteArray = new Uint8Array(byteNumbers);
      return new Blob([byteArray], { type: 'image/jpeg' });
    }
  }
}

</script>