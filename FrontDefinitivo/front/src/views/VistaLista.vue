<template>
    <div class="row container-lg mx-auto p-0 m-0">
    <div class="col-3 d-none d-lg-block mt-5">
      <a class="col-12 btn fw-semibold text-white rounded-4 p-3" style="background-color: #205760;">Ver vista mapa</a>
      <div class="col-12 mx-auto">
        <div class="col-12  px-3" style="border-radius: 25px 25px 0px 0px;">
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

    <div class="col-lg-9 p-0 pt-lg-5 mt-lg-5 mt-3">
      <div class="col-12 d-lg-none mb-4 pb-3 filtroMovil">
        <div class="row m-0">
          <div class="col-6 p-0">
            <a class="text-center mb-0 fw-bold nav-link" data-bs-toggle="collapse" href="#collapseExample" role="button"
              aria-expanded="false" aria-controls="collapseExample" style="color:#205760; font-size: 1.1rem;">Filtros
              <span style="background-color: #fa8e00;" class="rounded-5 px-2">4</span></a>
          </div>
          <div class="col-6 p-0">
            <p class="text-center mb-0 fw-bold" style="color:#205760; font-size: 1.1rem;">Vista mapa</p>
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
      <div class="col-11 mx-auto">
        <div class="dropdown custom-dropdown mb-4">
          <a class=" dropdown-toggle" style="color: #205760; text-decoration: none;" type="button"
            id="dropdownMenuButton" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <span class="fw-semibold">Ordenar:</span> Más cercanos
          </a>
          <ul class="dropdown-menu mt-2" aria-labelledby="dropdownMenuButton">
            <li><a class="dropdown-item" href="#">Opción 1</a></li>
            <li><a class="dropdown-item" href="#">Opción 2</a></li>
            <li><a class="dropdown-item" href="#">Opción 3</a></li>
          </ul>
        </div>

        <div class="row m-0 rounded-4 plazaItem overflow-hidden">
          <img src="img/plaza.jpg" class="col-2 p-0 d-md-block d-none">
          <div class="col-md-6 ">
            <div class="row h-100 align-items-center">
              <p class="fw-bold mb-1 textoPrimario">Calle del Poeta Quintana 33, 03004, Alicante, España</p>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Distancia</p>
                <p class="mb-0">182.65m</p>
              </div>
              <div class="col-4">
                <p class="mb-1 fw-semibold textoPrimario">Tamaño</p>
                <p class="mb-0" style="color: #888888;"><img src="../../src/assets/iconoAltura.png" height="20">1,9m</p>
              </div>
            </div>
          </div>
          <div class="col-md-2 col-6 d-flex align-items-center justify-content-center">
            <div>
              <p class="fw-semibold mb-3" style="color: #133C44;">Servicios</p>
              <div class="m-0">
                <img class="icono p-1" src="img/iconoWc.png">
                <img class="icono p-1" src="img/iconoSeguridad.png">
                <img class="icono p-1" src="img/icono24horas.png">
              </div>
            </div>
          </div>
          <div class="col-md-2 col-6 d-flex align-items-center " style="background-color: #CFE2E4;">
            <div>
              <p class="fw-semibold mb-0 " style="color: #133C44;">Precio</p>
              <p class="fw-bold mb-0 fs-3 text-center" style="color: #000000;">91,90€</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  name: 'HomeA'
}

</script>

<style>
.row {
      width: auto;
    }

    header {
      border-bottom: 2px solid #205760;
    }

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

    @media screen and (max-width: 768px) {
      .divNav {
        border-radius: 0px 0px 20px 20px;
        background-color: white;
        margin-top: 8px;
        text-align: center;
        font-size: 1.1rem;
        border: 1px solid #dfebee;
        border-top: 0;
      }

      .divNav ul li {
        border-bottom: 2px solid #dfebee;
        padding-bottom: 5px;
      }

      .divNav ul li:last-child {
        border-bottom: 0px solid red;
        padding-bottom: 2px;
      }

      .icono {
        width: 15%;
      }

      .plazaItem {
        background-color: rgba(246, 246, 246, 0.511);
      }
    }
</style>