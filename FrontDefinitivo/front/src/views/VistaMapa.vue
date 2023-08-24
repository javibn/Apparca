<template>
    <div class="row p-0 m-0">
    <div class="col-12 d-lg-none mb-4 py-3 position-absolute z-3 filtroMovil bg-white">
      <div class="row m-0">
        <div class="col-6 p-0">
          <a class="text-center mb-0 fw-bold nav-link" data-bs-toggle="collapse" href="#collapseExample" role="button"
            aria-expanded="false" aria-controls="collapseExample" style="color:#205760; font-size: 1.1rem;">Filtros
            <span style="background-color: #fa8e00;" class="rounded-5 px-2">4</span></a>
        </div>
        <div class="col-6 p-0">
          <p class="text-center mb-0 fw-bold" style="color:#205760; font-size: 1.1rem;">Ver vista lista</p>
        </div>
        <div class="collapse" id="collapseExample">
          <div class="col-md-8 col-10  mx-auto mt-4">
            <div class="row">
              <div class="col-6  p-0 pe-2 tbFiltro">
                <p class="mb-2 fw-semibold">Para qué vehiculo</p>
                <div class="select-menu">
                  <div class="select-btn">
                    <d class="fa-solid fa-car fs-5 sBtn-icon"></d>
                    <span class="sBtn-text">Coche</span>
                    <i class="bx bx-chevron-down"></i>
                  </div>
                  <ul class="options" style="padding: 0px">
                    <li class="option ">
                      <div class="mx-auto">
                        <i class="fa-solid fa-car fs-5 option-icon"></i>
                        <span class="option-text ">Coche</span>
                      </div>
                    </li>
                    <li class="option">
                      <div class="mx-auto">
                        <i class="fa-solid fa-motorcycle fs-5 option-icon"></i>
                        <span class="option-text">Moto</span>
                      </div>
  
                    </li>
                  </ul>
                </div>
  
              </div>
              <div class="col-6 m-0 p-0 tbFiltro">
                <p class="mb-2 fw-semibold">Dónde</p>
                <div class="select-menu" id="select-menu-provincia">
                  <div class="select-btn" id="select-btn-provincia">
                    <d class="fa-solid fa-earth-europe fs-5"></d>
                    <span class="sBtn-text" id="sBtn-text-provincia">Alicante</span>
                    <i class="bx bx-chevron-down"></i>
                  </div>
                  <ul class="options" id="options-provincia"
                    style="padding: 0px; max-height: 300px; overflow-y: scroll; width: 240px; ">
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Alicante</span>
                      </div>
                    </li>
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Murcia</span>
                      </div>
                    </li>
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Murcia</span>
                      </div>
                    </li>
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Murcia</span>
                      </div>
                    </li>
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Murcia</span>
                      </div>
                    </li>
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Murcia</span>
                      </div>
                    </li>
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Murcia</span>
                      </div>
                    </li>
                  </ul>
                </div>
              </div>
              <div class="col-12 mt-3 p-0">
                <p class="fw-semibold">Cuándo</p>
              </div>
              <div class="accordion col-12 p-0" id="accordionPanelsStayOpenExample">
                <div class="accordion-item border-0">
                  <h2 class="accordion-header">
                    <button class="accordion-button collapsed p-0 mb-3 mt-3 fw-semibold" type="button"
                      data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true"
                      aria-controls="panelsStayOpen-collapseOne">
                      Espacio
                    </button>
                  </h2>
                  <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse">
                    <div class="accordion-body">
                      <strong>This is the first item's accordion body.</strong> It is shown by default, until the collapse
                      plugin adds the appropriate classes that we use to style each element. These classes control the
                      overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of
                      this with custom CSS or overriding our default variables. It's also worth noting that just about any
                      HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                    </div>
                  </div>
                </div>
                <div class="accordion-item border-0">
                  <h2 class="accordion-header">
                    <button class="accordion-button collapsed p-0 mb-3 mt-5 fw-semibold" type="button"
                      data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseTwo" aria-expanded="false"
                      aria-controls="panelsStayOpen-collapseTwo">
                      Servicios
                    </button>
                  </h2>
                  <div id="panelsStayOpen-collapseTwo" class="accordion-collapse collapse">
                    <div class="accordion-body">
                      <strong>This is the second item's accordion body.</strong> It is hidden by default, until the
                      collapse plugin adds the appropriate classes that we use to style each element. These classes
                      control the overall appearance, as well as the showing and hiding via CSS transitions. You can
                      modify any of this with custom CSS or overriding our default variables. It's also worth noting that
                      just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit
                      overflow.
                    </div>
                  </div>
                </div>
              </div>
              <p class="text-center fw-bold mt-2" style="color: #205760;">Borrar filtros</p>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div id="contenedor" class="oculto position-absolute z-3 d-none d-lg-block pt-3">
      <div id="contenedor1" >
        <div class="row m-0 rounded-5 plazaItem overflow-hidden">
          <img src="img/plaza.jpg" style="height: 130px;" class="col-4 p-0 rounded-start-5 d-md-block d-none">
          <div class="col-md-8 ">
            <div class="row align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="img/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
            <div class="row">
              <div class="col-7">
                <p class="fw-semibold mb-1 mt-2" style="color: #133C44;">Servicios</p>
                <div class="mx-auto" style="display: flex; justify-content: center;">
                  <img class="icono p-1" src="img/iconoWc.png">
                  <img class="icono p-1" src="img/iconoSeguridad.png">
                  <img class="icono p-1" src="img/icono24horas.png">
                </div>
              </div>
              <div class="col-5 p-2" style="background-color: #CFE2E4;">
                <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
                <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
              </div>
            </div>
          </div>
        </div>
        <div class="row m-0 mt-4 rounded-5 plazaItem overflow-hidden">
          <img src="img/plaza.jpg" style="height: 130px;" class="col-4 p-0 rounded-start-5 d-md-block d-none">
          <div class="col-md-8 ">
            <div class="row align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="img/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
            <div class="row">
              <div class="col-7">
                <p class="fw-semibold mb-1 mt-2" style="color: #133C44;">Servicios</p>
                <div class="mx-auto" style="display: flex; justify-content: center;">
                  <img class="icono p-1" src="img/iconoWc.png">
                  <img class="icono p-1" src="img/iconoSeguridad.png">
                  <img class="icono p-1" src="img/icono24horas.png">
                </div>
              </div>
              <div class="col-5 p-2" style="background-color: #CFE2E4;">
                <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
                <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
              </div>
            </div>
          </div>
        </div>
        <div class="row m-0 mt-4 rounded-5 plazaItem overflow-hidden">
          <img src="img/plaza.jpg" style="height: 130px;" class="col-4 p-0 rounded-start-5 d-md-block d-none">
          <div class="col-md-8 ">
            <div class="row align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="img/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
            <div class="row">
              <div class="col-7">
                <p class="fw-semibold mb-1 mt-2" style="color: #133C44;">Servicios</p>
                <div class="mx-auto" style="display: flex; justify-content: center;">
                  <img class="icono p-1" src="img/iconoWc.png">
                  <img class="icono p-1" src="img/iconoSeguridad.png">
                  <img class="icono p-1" src="img/icono24horas.png">
                </div>
              </div>
              <div class="col-5 p-2" style="background-color: #CFE2E4;">
                <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
                <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
              </div>
            </div>
          </div>
        </div>
        <div class="row m-0 mt-4 rounded-5 plazaItem overflow-hidden">
          <img src="img/plaza.jpg" style="height: 130px;" class="col-4 p-0 rounded-start-5 d-md-block d-none">
          <div class="col-md-8 ">
            <div class="row align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="img/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
            <div class="row">
              <div class="col-7">
                <p class="fw-semibold mb-1 mt-2" style="color: #133C44;">Servicios</p>
                <div class="mx-auto" style="display: flex; justify-content: center;">
                  <img class="icono p-1" src="img/iconoWc.png">
                  <img class="icono p-1" src="img/iconoSeguridad.png">
                  <img class="icono p-1" src="img/icono24horas.png">
                </div>
              </div>
              <div class="col-5 p-2" style="background-color: #CFE2E4;">
                <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
                <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
              </div>
            </div>
          </div>
        </div>
        <div class="row m-0 mt-4 mb-3 rounded-5 plazaItem overflow-hidden">
          <img src="img/plaza.jpg" style="height: 130px;" class="col-4 p-0 rounded-start-5 d-md-block d-none">
          <div class="col-md-8 ">
            <div class="row align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="img/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
            <div class="row">
              <div class="col-7">
                <p class="fw-semibold mb-1 mt-2" style="color: #133C44;">Servicios</p>
                <div class="mx-auto" style="display: flex; justify-content: center;">
                  <img class="icono p-1" src="img/iconoWc.png">
                  <img class="icono p-1" src="img/iconoSeguridad.png">
                  <img class="icono p-1" src="img/icono24horas.png">
                </div>
              </div>
              <div class="col-5 p-3" style="background-color: #CFE2E4;">
                <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
                <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <button class="btn bg-white p-2 position-absolute z-2 d-none d-lg-block botonLista" id="mostrarDiv">
      <img src="img/iconoDespliegueLista.png">
    </button>
    <button class="btn bg-white p-2 position-absolute z-2 d-none d-lg-block botonOcultarLista" id="ocultarDiv">
      <img src="img/iconoDespliegueLista.png" style="transform: rotate(180deg);">
    </button>
    <div class="d-none d-lg-block mt-5 position-absolute z-3 filtroCaja" style=" margin-left: 3%;">
      <a class="col-12 btn fw-semibold text-white rounded-4 p-2 mb-4" style="background-color: #205760;">Ver vista lista</a>
      <div class="col-12 mx-auto bg-white rounded-4">
        <div class="col-12  filtro px-3" style="border-radius: 25px 25px 0px 0px;">
          <p class="text-center pt-3 mb-0 fw-semibold" style="color:#205760; font-size: 1.1rem;">Filtros <span
              style="background-color: #fa8e00;" class="rounded-5 px-2">4</span></p>
          <hr class="mt-2 text-warning">
          <div class="row m-0  mt-2 pb-3">
            <div class="col-12 p-0 pe-2 tbFiltro">
              <p class="mb-2 fw-semibold">Para qué vehiculo</p>
              <div class="select-menu">
                <div class="select-btn">
                  <d class="fa-solid fa-car fs-5 sBtn-icon"></d>
                  <span class="sBtn-text">Coche</span>
                  <i class="bx bx-chevron-down"></i>
                </div>
                <ul class="options" style="padding: 0px">
                  <li class="option ">
                    <div class="mx-auto">
                      <i class="fa-solid fa-car fs-5 option-icon"></i>
                      <span class="option-text ">Coche</span>
                    </div>
                  </li>
                  <li class="option">
                    <div class="mx-auto">
                      <i class="fa-solid fa-motorcycle fs-5 option-icon"></i>
                      <span class="option-text">Moto</span>
                    </div>

                  </li>
                </ul>
              </div>

            </div>
            <div class="col-12 m-0 p-0 mt-3 tbFiltro">
              <p class="mb-2 fw-semibold">Dónde</p>
              <div class="select-menu" id="select-menu-provincia">
                <div class="select-btn" id="select-btn-provincia">
                  <d class="fa-solid fa-earth-europe fs-5"></d>
                  <span class="sBtn-text" id="sBtn-text-provincia">Alicante</span>
                  <i class="bx bx-chevron-down"></i>
                </div>
                <ul class="options" id="options-provincia"
                  style="padding: 0px; max-height: 300px; overflow-y: scroll; width: 240px; ">
                  <li class="option" id="option-provincia">
                    <div class="mx-auto">
                      <span class="option-text" id="option-text-provincia">Alicante</span>
                    </div>
                  </li>
                  <li class="option" id="option-provincia">
                    <div class="mx-auto">
                      <span class="option-text" id="option-text-provincia">Murcia</span>
                    </div>
                  </li>
                  <li class="option" id="option-provincia">
                    <div class="mx-auto">
                      <span class="option-text" id="option-text-provincia">Murcia</span>
                    </div>
                  </li>
                  <li class="option" id="option-provincia">
                    <div class="mx-auto">
                      <span class="option-text" id="option-text-provincia">Murcia</span>
                    </div>
                  </li>
                  <li class="option" id="option-provincia">
                    <div class="mx-auto">
                      <span class="option-text" id="option-text-provincia">Murcia</span>
                    </div>
                  </li>
                  <li class="option" id="option-provincia">
                    <div class="mx-auto">
                      <span class="option-text" id="option-text-provincia">Murcia</span>
                    </div>
                  </li>
                  <li class="option" id="option-provincia">
                    <div class="mx-auto">
                      <span class="option-text" id="option-text-provincia">Murcia</span>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
            <div class="col-12 mt-3 p-0">
              <p class="fw-semibold">Cuándo</p>
            </div>
            <div class="accordion col-12 p-0" id="accordionPanelsStayOpenExample">
              <div class="accordion-item border-0">
                <h2 class="accordion-header">
                  <button class="accordion-button collapsed p-0 mb-3 mt-3 fw-semibold" type="button"
                    data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true"
                    aria-controls="panelsStayOpen-collapseOne">
                    Espacio
                  </button>
                </h2>
                <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse">
                  <div class="accordion-body">
                    <strong>This is the first item's accordion body.</strong> It is shown by default, until the collapse
                    plugin adds the appropriate classes that we use to style each element. These classes control the
                    overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of
                    this with custom CSS or overriding our default variables. It's also worth noting that just about any
                    HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                  </div>
                </div>
              </div>
              <div class="accordion-item border-0">
                <h2 class="accordion-header">
                  <button class="accordion-button collapsed p-0 mb-3 mt-5 fw-semibold" type="button"
                    data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseTwo" aria-expanded="false"
                    aria-controls="panelsStayOpen-collapseTwo">
                    Servicios
                  </button>
                </h2>
                <div id="panelsStayOpen-collapseTwo" class="accordion-collapse collapse">
                  <div class="accordion-body">
                    <strong>This is the second item's accordion body.</strong> It is hidden by default, until the
                    collapse plugin adds the appropriate classes that we use to style each element. These classes
                    control the overall appearance, as well as the showing and hiding via CSS transitions. You can
                    modify any of this with custom CSS or overriding our default variables. It's also worth noting that
                    just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit
                    overflow.
                  </div>
                </div>
              </div>
            </div>
            <p class="text-center fw-bold mt-2" style="color: #205760;">Borrar filtros</p>
          </div>
        </div>
      </div>
    </div>
    <div id="map" class="position-absolute z-1 bg-danger" style="height: 90%;">
    </div>

  </div>
</template>

<script>


export default {
  name: 'VistaMapa',
  async mounted() {
    // Agregar una capa de mapa base
  }
}

</script>

<style>
  .textoPrimario {
      color: #133C44;
    }

    .textPopUp{
      font-size: 1rem;
    }

    .iconoPop {
      width: 20%;
    }

    .icono {
      width: 20%;
    }

    .marcador p{
      border:0px;
      margin:0px;
      font-weight:600;
      text-align:center;
      font-size: 0.9rem;
      color: white;
    }

    .marcador{
      background-color: #2b7a64;
      padding: 4px;
      width: 55px;
      border-radius: 5px;
    }

    .flecha-down {
        width: 0px;
        height: 0px;
        border-left: 7px solid transparent; /* izquierda flecha */
        border-right: 7px solid transparent; /* derecha flecha */
        border-top: 7px solid #2b7a64; /* base flecha y color*/
        font-size: 0px;
    }

    .leaflet-div-icon{
        width: 55px !important;
        border:0px;
        background-color: transparent;
    }

    .leaflet-popup-content-wrapper{
      margin: 0px;
      border-radius: 25px;
      padding: 0px;
    }

    .leaflet-popup{
      margin-bottom: 5px;
    }

    .leaflet-popup-close-button, .leaflet-popup-tip-container{
      display: none;
    }

    .leaflet-popup-content{
      margin: 0px;
      width: auto !important;
    }

    .filtroCaja{
      width: 22%;
    }
    .botonLista{
      width: 40px;
      left: 24%;
      top: 250px
    }

    .botonOcultarLista{
      width: 40px;
      left: -10%;
      top: 250px;
      transition: 1s;
    }

    .botonOcultarLista img{
      width: 100%;
      height: auto;
    }

    .botonLista img{
      width: 100%;
      height: auto;
    }

    .listaDesplegable{
      margin-left: 24%;
      height: 90vh;
      width: 200px;
      background-color: white;
    }

    #contenedor {
        left: -60%; /* Comienza fuera de la pantalla */
        width: 60%;
        height: 90vh;
        padding-left: 27%;
        background-color: white;
        overflow: hidden;
        transition: 1s;
    }

    #contenedor1{
      height: 100%;
      overflow-y: scroll;
      padding-right: 20px;
    }

    #contenedor1::-webkit-scrollbar{
        width: 10px;
    }

    #contenedor1::-webkit-scrollbar-thumb {
        background-image: linear-gradient(180deg, #287381 10%, #8cbdc5 90%);
        box-shadow: inset 2px 2px 5px 0 rgba(#fff, 0.5);
        border-radius: 100px;
    }

    @media screen and (max-width: 1450px) {
      .filtroCaja{
        width: 25%;
      }
      .botonLista{
        left: 27%;
      }
      #contenedor{
        padding-left: 28%;
        width: 65%;
        left: -65%;
      }
    }

    @media screen and (max-width: 1200px) {
      .filtroCaja{
        width: 30%;
      }
      .botonLista{
        left: 31%;
      }
      #contenedor{
        padding-left: 33%;
        width: 80%;
        left: -80%;
      }
    }
</style>