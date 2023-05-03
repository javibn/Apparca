<template>
    <div v-if="plazaEncontrada" id="contenido">
        <div  style="height:180px; width:100%; overflow: hidden;" class="z-0 position-absolute opacity-75" >
            <div id="mapaDetail" style="height:110%; width:100%;">

            </div>
        </div>
        <div class="container z-1 position-absolute row col-10 offset-1"  style="height:auto; padding-top: 50px;">
            <div class="bg-white rounded-4 pt-4 ps-0 pe-0 col-3 ">
                <p class="text-center fw-bold mb-1" style="font-size: 0.9rem;">Cuándo?</p>
                <div class="row p-1 m-0 mb-3" v-if="this.plaza != null">
                    <div class="col border-bottom border-dark row m-0" >
                        <svg xmlns="http://www.w3.org/2000/svg" width="18" height="20" fill="currentColor" class="p-0 bi bi-arrow-right text-primary mb-1 col-3" viewBox="0 0 16 16">
                            <path fill-rule="evenodd" d="M1 8a.5.5 0 0 1 .5-.5h11.793l-3.147-3.146a.5.5 0 0 1 .708-.708l4 4a.5.5 0 0 1 0 .708l-4 4a.5.5 0 0 1-.708-.708L13.293 8.5H1.5A.5.5 0 0 1 1 8z"/>
                        </svg>
                        <span class="text-center ps-4 col-9">
                            {{ this.plaza.fechaInicio }}
                            {{ this.plaza.horaInicio }}
                        </span>
                    </div>
                    <div class="col ms-2 border-bottom border-dark row m-0" >
                        <svg xmlns="http://www.w3.org/2000/svg" width="18" height="20" fill="currentColor" class="p-0 bi bi-arrow-left text-primary mb-1 col-3" viewBox="0 0 16 16">
                            <path fill-rule="evenodd" d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z"/>
                        </svg>
                        <span class="text-center ps-4 col-8">
                            {{ this.plaza.fechaFinal }}
                            {{ this.plaza.horaFinal }}
                        </span>
                    </div>
                </div>
                <div class="row p-1 m-0" v-if="this.plaza != null">
                    <p class="text-center text-dark mb-0">Precio</p>
                    <p class="text-center text-black fw-bold fs-2 mb-0" style="margin-top: -10px;">{{ this.plaza.precioMes }}€</p>
                </div>
                <button class="btn rounded-bottom-4 rounded-top-0 col-12 text-white" style="background-color: #890094;">Reservar</button>
            </div>
            <div class="col-12 mt-5 row m-0 p-0" v-if="this.plaza != null">
                <img class="col-3 rounded-4 ps-0 pe-0" style="height: 250px;" :src="imagenCodificada">
                <div class="col ps-5">
                    <h3 class="mb-4">{{ this.plaza.direccion }}</h3>

                    <h6>Servicios</h6>
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-badge-wc" style="color:#BEBEBE" viewBox="0 0 16 16">
                        <path d="M10.348 7.643c0-1.112.488-1.754 1.318-1.754.682 0 1.139.47 1.187 1.108H14v-.11c-.053-1.187-1.024-2-2.342-2-1.604 0-2.518 1.05-2.518 2.751v.747c0 1.7.905 2.73 2.518 2.73 1.314 0 2.285-.792 2.342-1.939v-.114h-1.147c-.048.615-.497 1.05-1.187 1.05-.839 0-1.318-.62-1.318-1.727v-.742zM4.457 11l1.02-4.184h.045L6.542 11h1.006L9 5.001H7.818l-.82 4.355h-.056L5.97 5.001h-.94l-.972 4.355h-.053l-.827-4.355H2L3.452 11h1.005z"/>
                        <path d="M14 3a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h12zM2 2a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2H2z"/>
                    </svg>
                    <span class="ms-2">Baño</span>
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-camera ms-5" style="color:#BEBEBE" viewBox="0 0 16 16">
                        <path d="M15 12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V6a1 1 0 0 1 1-1h1.172a3 3 0 0 0 2.12-.879l.83-.828A1 1 0 0 1 6.827 3h2.344a1 1 0 0 1 .707.293l.828.828A3 3 0 0 0 12.828 5H14a1 1 0 0 1 1 1v6zM2 4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6a2 2 0 0 0-2-2h-1.172a2 2 0 0 1-1.414-.586l-.828-.828A2 2 0 0 0 9.172 2H6.828a2 2 0 0 0-1.414.586l-.828.828A2 2 0 0 1 3.172 4H2z"/>
                        <path d="M8 11a2.5 2.5 0 1 1 0-5 2.5 2.5 0 0 1 0 5zm0 1a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7zM3 6.5a.5.5 0 1 1-1 0 .5.5 0 0 1 1 0z"/>
                    </svg>
                    <span class="ms-2">Videovigilancia</span>
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-door-open ms-5" style="color:#BEBEBE" viewBox="0 0 16 16">
                        <path d="M8.5 10c-.276 0-.5-.448-.5-1s.224-1 .5-1 .5.448.5 1-.224 1-.5 1z"/>
                        <path d="M10.828.122A.5.5 0 0 1 11 .5V1h.5A1.5 1.5 0 0 1 13 2.5V15h1.5a.5.5 0 0 1 0 1h-13a.5.5 0 0 1 0-1H3V1.5a.5.5 0 0 1 .43-.495l7-1a.5.5 0 0 1 .398.117zM11.5 2H11v13h1V2.5a.5.5 0 0 0-.5-.5zM4 1.934V15h6V1.077l-6 .857z"/>
                    </svg>
                    <span class="ms-2">Abierto 24 horas</span>

                    <h6 class="mt-4">Características</h6>
                    <img src="../../src/assets/iconAncho.png" class="icono">
                    <span class="fw-bold ms-3">Ancho: {{ this.plaza.ancho }}cm</span>

                    <img src="../../src/assets/iconoLargo.png" class="icono ms-4 ">
                    <span class="fw-bold">Ancho: {{ this.plaza.largo }}cm</span>

                    <img src="../../src/assets/iconoMando.png" class="icono ms-5 ">
                    <span class="fw-bold ms-3">Precio del mando: {{ this.plaza.precioMando }}€</span>

                    <h5 class="mt-4">Descripción</h5>
                    <p>{{ this.plaza.descripcion }}</p>

                    <h5 class="mt-4">Contacta con el propietario</h5>
                    <a class="btn p-2 mt-2" style="color: #890094; border-color: #890094; width: 200px;">Contactar</a>
                </div>
            </div>
            
        </div>
        <div class="text-center d-flex align-items-center justify-content-center" style="position: absolute; top:0; bottom: 0; left: 0; right: 0;"   >
            <div class="spinner-border d-none" id="spinner" role="status">
            </div>
        </div>
    </div>
</template>

<script>
import L from 'leaflet';

export default {
  name: 'PlazaDetails',
  data: function() {
        return {
            plazaEncontrada: true,
            plaza: null,
            mapa:null,
            imagenCodificada: null
        }
    },
  components: {

  },
  async mounted() {
    var spinner = document.getElementById("spinner");
    spinner.classList = "spinner-border";
    var contenido = document.getElementById("contenido");
    contenido.classList.add("opacity-50");
    const userId = this.$route.params.numero;
    await fetch('https://localhost:7207/Plazas/Details?id='+userId)
      .then(response => response.json())
      .then(data => {
            console.log(data);
            this.plaza = data;
            
        })
      .catch(error => console.error(error))
    console.log(this.plaza);

    this.mapa = L.map('mapaDetail').setView([this.plaza.latitud, this.plaza.longitud], 15)
    // Agregar una capa de mapa base
    L.tileLayer('https://{s}.basemaps.cartocdn.com/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
    maxZoom: 20,
    minZoom: 6
    }).addTo(this.mapa);
    this.imagenCodificada = URL.createObjectURL(this.base64ToBlob(this.plaza.imagen));
    console.log(this.imagenCodificada)
    var markers = L.layerGroup().addTo(this.mapa)
    var marker = L.marker([this.plaza.latitud, this.plaza.longitud])

    markers.clearLayers();
    marker.addTo(markers)

    spinner.classList.add("d-none");
    contenido.classList.remove("opacity-50");
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

<style>
.text-secondary{
    color: rgba(var(--bs-secondary-rgb), var(--bs-text-opacity)) !important;
}
.icono{
    width : 50px;
     height : 50px;
}

</style>