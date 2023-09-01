<template>
    <div class="row container-lg mx-auto p-0 m-0">
        <div style="min-height: 90vh;width:100%;">
            <div style="height:200px; width:100%; overflow: hidden;" class="z-n1 p-0  opacity-75 d-none d-lg-block">
                <div id="mapa" style="height:140%; width:100%;"></div>
            </div>
            <div class="z-1 row d-none d-lg-flex" style="width: 82%; margin-left: 8%;">
                <div class="col-lg-4 pe-5 flex-column">
                    <div class="bg-white rounded-5 pt-3 ps-0 pe-0">
                        <div class="row px-1 m-0 mb-2">
                            <div class="col row d-flex align-items-center px-1 py-1 mx-1 rounded-3"
                            style="border: 1px solid #1C4F58;">
                                <p class="mb-1 fw-semibold">Cuándo</p>
                                <time-component class="agrandar" @getDataHoras="getDataHoras" ref="refInputHours"></time-component>
                            </div>
                        </div>
                        <div class="row p-1 m-0">
                            <p class="col-5 mx-auto mb-0 textoPrimario fw-semibold">Precio</p>
                            <p class="text-center text-black fw-bold fs-2 mb-0" style="margin-top: -10px;">91,90€</p>
                        </div>
                        <button class="btn rounded-bottom-5 rounded-top-0 col-12 text-white"
                            style="background-color: #205760;">Reservar</button>
                    </div>
                    <img class="rounded-5 mt-4 col-12" src="../assets/plaza.jpg">
                </div>
                <div class="col ps-5 mt-5 pt-3">
                    <div class="col">
                        <h3 class="mb-4 textoPrimario fw-semibold fs-4">Calle del Poeta Quintana 33, 03004, Alicante, España
                        </h3>
                        <h6 style="color: #133C44;" class="fw-semibold">Servicios</h6>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                            class="bi bi-badge-wc" style="color:#BEBEBE" viewBox="0 0 16 16">
                            <path
                                d="M10.348 7.643c0-1.112.488-1.754 1.318-1.754.682 0 1.139.47 1.187 1.108H14v-.11c-.053-1.187-1.024-2-2.342-2-1.604 0-2.518 1.05-2.518 2.751v.747c0 1.7.905 2.73 2.518 2.73 1.314 0 2.285-.792 2.342-1.939v-.114h-1.147c-.048.615-.497 1.05-1.187 1.05-.839 0-1.318-.62-1.318-1.727v-.742zM4.457 11l1.02-4.184h.045L6.542 11h1.006L9 5.001H7.818l-.82 4.355h-.056L5.97 5.001h-.94l-.972 4.355h-.053l-.827-4.355H2L3.452 11h1.005z" />
                            <path
                                d="M14 3a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h12zM2 2a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2H2z" />
                        </svg>
                        <span class="ms-2">Baño</span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                            class="bi bi-camera ms-5" style="color:#BEBEBE" viewBox="0 0 16 16">
                            <path
                                d="M15 12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V6a1 1 0 0 1 1-1h1.172a3 3 0 0 0 2.12-.879l.83-.828A1 1 0 0 1 6.827 3h2.344a1 1 0 0 1 .707.293l.828.828A3 3 0 0 0 12.828 5H14a1 1 0 0 1 1 1v6zM2 4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6a2 2 0 0 0-2-2h-1.172a2 2 0 0 1-1.414-.586l-.828-.828A2 2 0 0 0 9.172 2H6.828a2 2 0 0 0-1.414.586l-.828.828A2 2 0 0 1 3.172 4H2z" />
                            <path
                                d="M8 11a2.5 2.5 0 1 1 0-5 2.5 2.5 0 0 1 0 5zm0 1a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7zM3 6.5a.5.5 0 1 1-1 0 .5.5 0 0 1 1 0z" />
                        </svg>
                        <span class="ms-2">Videovigilancia</span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                            class="bi bi-door-open ms-5" style="color:#BEBEBE" viewBox="0 0 16 16">
                            <path d="M8.5 10c-.276 0-.5-.448-.5-1s.224-1 .5-1 .5.448.5 1-.224 1-.5 1z" />
                            <path
                                d="M10.828.122A.5.5 0 0 1 11 .5V1h.5A1.5 1.5 0 0 1 13 2.5V15h1.5a.5.5 0 0 1 0 1h-13a.5.5 0 0 1 0-1H3V1.5a.5.5 0 0 1 .43-.495l7-1a.5.5 0 0 1 .398.117zM11.5 2H11v13h1V2.5a.5.5 0 0 0-.5-.5zM4 1.934V15h6V1.077l-6 .857z" />
                        </svg>
                        <span class="ms-2">Abierto 24 horas</span>

                        <h6 style="color: #133C44;" class="fw-semibold mt-4">Distancia</h6>
                        <p>182.65m</p>

                        <h6 style="color: #133C44;" class="fw-semibold mt-3">Tamaño</h6>
                <p class="mb-0" style="color: #888888;"><img src="../../src/assets/iconoAltura.png" height="20">1,9m</p>

                        <h5 class="mt-4 fw-bold" style="color: #133C44;">Descripción</h5>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor
                            incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis
                            nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
                            fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in
                            culpa qui officia deserunt mollit anim id est laborum.</p>

                        <h5 class="mt-4">Contacta con el propietario</h5>
                        <a class="rounded-3 btn my-auto py-auto text-center fw-bold"
                            style="border: 1px solid #133C44">
                            Contactar
                        </a>
                    </div>
                </div>
            </div>
            <div class="z-1 row d-lg-none justify-content-center align-items-center" style="width: 82%; margin-left: 8%;">
                <img class="rounded-5 mt-4 col-10 mx-auto" src="img/plaza.jpg">
                <div class="col mt-5 pt-3 mx-auto">
                    <div class="col">
                        <h3 class="mb-4 textoPrimario fw-semibold fs-4">Calle del Poeta Quintana 33, 03004, Alicante, España
                        </h3>
                        <h6 style="color: #133C44;" class="fw-semibold">Servicios</h6>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                            class="bi bi-badge-wc" style="color:#BEBEBE" viewBox="0 0 16 16">
                            <path
                                d="M10.348 7.643c0-1.112.488-1.754 1.318-1.754.682 0 1.139.47 1.187 1.108H14v-.11c-.053-1.187-1.024-2-2.342-2-1.604 0-2.518 1.05-2.518 2.751v.747c0 1.7.905 2.73 2.518 2.73 1.314 0 2.285-.792 2.342-1.939v-.114h-1.147c-.048.615-.497 1.05-1.187 1.05-.839 0-1.318-.62-1.318-1.727v-.742zM4.457 11l1.02-4.184h.045L6.542 11h1.006L9 5.001H7.818l-.82 4.355h-.056L5.97 5.001h-.94l-.972 4.355h-.053l-.827-4.355H2L3.452 11h1.005z" />
                            <path
                                d="M14 3a1 1 0 0 1 1 1v8a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V4a1 1 0 0 1 1-1h12zM2 2a2 2 0 0 0-2 2v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2H2z" />
                        </svg>
                        <span class="ms-2">Baño</span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                            class="bi bi-camera ms-5" style="color:#BEBEBE" viewBox="0 0 16 16">
                            <path
                                d="M15 12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V6a1 1 0 0 1 1-1h1.172a3 3 0 0 0 2.12-.879l.83-.828A1 1 0 0 1 6.827 3h2.344a1 1 0 0 1 .707.293l.828.828A3 3 0 0 0 12.828 5H14a1 1 0 0 1 1 1v6zM2 4a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V6a2 2 0 0 0-2-2h-1.172a2 2 0 0 1-1.414-.586l-.828-.828A2 2 0 0 0 9.172 2H6.828a2 2 0 0 0-1.414.586l-.828.828A2 2 0 0 1 3.172 4H2z" />
                            <path
                                d="M8 11a2.5 2.5 0 1 1 0-5 2.5 2.5 0 0 1 0 5zm0 1a3.5 3.5 0 1 0 0-7 3.5 3.5 0 0 0 0 7zM3 6.5a.5.5 0 1 1-1 0 .5.5 0 0 1 1 0z" />
                        </svg>
                        <span class="ms-2">Videovigilancia</span>
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor"
                            class="bi bi-door-open ms-5" style="color:#BEBEBE" viewBox="0 0 16 16">
                            <path d="M8.5 10c-.276 0-.5-.448-.5-1s.224-1 .5-1 .5.448.5 1-.224 1-.5 1z" />
                            <path
                                d="M10.828.122A.5.5 0 0 1 11 .5V1h.5A1.5 1.5 0 0 1 13 2.5V15h1.5a.5.5 0 0 1 0 1h-13a.5.5 0 0 1 0-1H3V1.5a.5.5 0 0 1 .43-.495l7-1a.5.5 0 0 1 .398.117zM11.5 2H11v13h1V2.5a.5.5 0 0 0-.5-.5zM4 1.934V15h6V1.077l-6 .857z" />
                        </svg>
                        <span class="ms-2">Abierto 24 horas</span>

                        <h6 style="color: #133C44;" class="fw-semibold mt-4">Distancia</h6>
                        <p>182.65m</p>

                        <h6 style="color: #133C44;" class="fw-semibold mt-3">Tamaño</h6>
                        <p class="mb-0" style="color: #888888;"><img src="img/iconoAltura.png" height="20">1,9m</p>

                        <h5 class="mt-4 fw-bold" style="color: #133C44;">Descripción</h5>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor
                            incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis
                            nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
                            fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in
                            culpa qui officia deserunt mollit anim id est laborum.</p>

                        <div style="height:170px; width:100%; overflow: hidden;"
                            class="z-n1 p-0  opacity-75 d-lg-none d-block">
                            <div id="map" style="height:110%; width:100%;"></div>
                        </div>
                        <h5 class="mt-4 fw-bold">Contacta con el propietario</h5>
                        <a class="rounded-3 btn py-2 px-5 mt-2 textoPrimario fw-bold"
                            style="border: 1px solid #205760;">Contactar</a>
                    </div>
                </div>
                <div class="bg-white rounded-5 pt-3 mb-4 col-10 mx-auto">
                    <p class="px-4 fw-bold mb-0" style="font-size: 0.9rem;">Cuándo</p>
                    <div class="row px-1 m-0 mb-2">
                        <div class="col-12 mt-3 p-0">
                        </div>
                        <div class="col row d-flex align-items-center px-1 py-1 mx-1 rounded-3"
                            style="border: 1px solid #1C4F58;">
                            <p class="mb-1 fw-semibold">Cuándo</p>
                            <time-component class="agrandar" @getDataHoras="getDataHoras" ref="refInputHours"></time-component>
                        </div>

                    </div>
                    <div class="row p-1 m-0">
                        <p class="col-5 mx-auto mb-0 textoPrimario fw-semibold">Precio</p>
                        <p class="text-center text-black fw-bold fs-2 mb-0" style="margin-top: -10px;">91,90€</p>
                    </div>
                    <button class="btn rounded-bottom-5 rounded-top-0 col-12 text-white"
                        style="background-color: #205760;">Reservar</button>
                </div>
            </div>
        </div>
    </div>
</template>
  
<script>
import L from 'leaflet';
import 'leaflet.markercluster';
import TimeComponent from './../components/TimeComponent.vue'

export default {
    name: 'DetailsPlaza',
    data: function(){
        return{
            map:{}
        }
    },
    computed: {
    },
    components: {
        TimeComponent
    },
    methods: {
    },
    async mounted() {

        this.map = L.map('mapa', {zoomControl: true,zoom:1,zoomAnimation:false,fadeAnimation:true,markerZoomAnimation:true}).setView([39.850931195377946, -3.1256103515625004], 7)
        console.log(this.map)

        L.tileLayer('https://%7Bs%7D.basemaps.cartocdn.com/rastertiles/voyager/%7Bz%7D/%7Bx%7D/%7By%7D%7Br%7D.png', {
            maxZoom: 20,
            minZoom: 6
        }).addTo(this.map);
        
        if(this.filtroStore != null){
        console.log("Aqui meto los datos en el filtro: vistaMapa")
        this.filtro = this.filtroStore
        if(typeof this.filtro.horas == 'string'){
            this.filtro.horas = JSON.parse(this.filtro.horas)
        }
        this.$store.dispatch('limpiar')
        this.$refs.refFiltro.MeterDatos(this.filtro)
        if(this.filtro.centro != null){
            this.map.setView([this.filtro.centro[1], this.filtro.centro[0]], 15)
        }
        }else{
        if(this.coordenadas != null){
            this.DatosHome()
            console.log(this.coordenadas)
            this.map.setView([this.coordenadas[1], this.coordenadas[0]], 15)
        }
        }
    } 
}

</script>
  
<style>
.textoPrimario {
    color: #133C44;
}

.custom-dropdown .dropdown-toggle::after {
    display: none;
    /* Ocultar el icono de desplegar predeterminado */
}

.custom-dropdown .dropdown-toggle {
    background-image: url('../../src/assets/desplegable.png');
    /* Reemplaza 'ruta_de_la_imagen.png' con la URL de tu imagen */
    background-repeat: no-repeat;
    background-position: right center;
    /* Puedes ajustar la posición de la imagen */
    background-size: 20px;
    /* Ajusta el tamaño de la imagen según tus necesidades */
    padding-right: 30px;
    /* Ajusta el espacio para que la imagen no se superponga con el texto */
}

.icono {
    width: 30%;
}

.filtroMovil {
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    border-radius: 0px 0px 20px 20px;
}

@media screen and (max-width: 992px) {
    .filtroVista {
        display: none;
    }
}

@media screen and (max-width: 768px) {
    .icono {
        width: 15%;
    }

    .plazaItem {
        background-color: rgba(246, 246, 246, 0.511);
    }
}</style>