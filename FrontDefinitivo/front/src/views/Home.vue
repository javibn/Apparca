<template>
  <div>
    <div style="z-index: 3;" class="position-sticky">
    <nav class="navbar navbar-expand" style="height: 8vh;">
      <div class="container">
        <a class="navbar-brand ms-lg-0 ms-3" href="#">
          <img src="../../src/assets/logoA.svg" class="d-inline-block align-text-top">
        </a>
        <button class="navbar-toggler" type="button"
        data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
        aria-controls="navbarSupportedContent" aria-expanded="false"
        aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse" id="navbarSupportedContent">
          <ul class="me-auto mb-2 mb-lg-0">
          </ul>
          <ul class="navbar-nav">
            <img src="../../src/assets/llave.png" class="mt-1" height="30">
            <li class="nav-item">
              <a class="nav-link fw-bold text-white" aria-current="page" href="#">Login</a>
            </li>
            <li class="nav-item fw-bold d-none d-lg-block">
              <a class="nav-link text-white" aria-current="page" href="#">/</a>
            </li>
            <li class="nav-item fw-bold">
              <a class="nav-link text-white" href="#">Registro</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </div>
    <div class="position-absolute  top-0 contenedorFondo">
    </div>
    <div class="contenedorFondo2">
    </div>
    <div style="z-index: 2; position: absolute; width: 100%;">
      <div class="col-xl-3 col-lg-5 col-md-7 col-sm-9 col-10 mx-auto pb-3 logo" >
        <img src="../../src/assets/logo.svg" class="w-100">
      </div>
      <div class="col-xxl-6 col-xl-7 col-lg-9 col-11 mx-auto">
        <div class="bg-light col-12  filtro px-3" style="border-radius: 25px 25px 0px 0px;">
          <h2 class="text-center py-3 mb-0 fw-semibold"
          style="color:#133C44; font-size: 1.8rem;">Encuentra aparcamiento</h2>
          <div class="row m-0 ps-3 pe-3 mt-2 pb-3">
            <div class="col-md-3 p-0 pe-2 tbFiltro">
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
                          <i class="fa-solid fa-car fs-5 option-icon" ></i>
                          <span class="option-text ">Coche</span>
                        </div>
                    </li>
                    <li class="option">
                      <div class="mx-auto">
                        <i class="fa-solid fa-motorcycle fs-5 option-icon" ></i>
                        <span class="option-text">Moto</span>
                      </div>
                        
                    </li>
                </ul>
            </div>
            
            </div>
            <div class="col-md-5 tbFiltro">
              <p class="mb-2 fw-semibold">Dónde</p>
              <div class="select-menu" id="select-menu-provincia">
                <div class="select-btn" id="select-btn-provincia">
                  <d class="fa-solid fa-earth-europe fs-5"></d>
                    <input type="text" id="textbox-place" class="form-control ms-4" placeholder="Provincia">
                </div>
                <ul class="options" id="options-provincia" style="padding: 0px; max-height: 300px; overflow-y: scroll; width: 240px; ">
                  <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">Murcia</span>
                      </div>
                    </li>
                    <li class="option" id="option-provincia">
                      <div class="mx-auto">
                        <span class="option-text" id="option-text-provincia">almeria</span>
                      </div>
                    </li>
                    
                </ul>
            </div>
            </div>
            <div class="col-md-4">
              <p class="fw-semibold">Cuándo</p>
              
            </div>
          </div>
        </div>
        <div class="col-12 mx-auto p-0 botonEncontrar">
          <h5 class="text-center py-3 text-white fw-semibold">Encontrar aparcamiento</h5>
        </div>
      </div>
      <div class="col-xxl-5 col-xl-7 col-lg-9 col-11 mx-auto saberMas">
        <div class="bg-light" style="border-radius: 25px 25px 0px 0px;
        margin-top: 500px;">
          <h2 class="text-center pt-4 mb-0" style="color:#133C44;">Alquila tu plaza de garaje</h2>
          <p class="mt-3 text-center pb-3 mb-0" style="font-size: 1rem; padding: 0px 5rem 0rem 5rem;">
            Sácale partido a esa plaza de garaje que no usas. Date de alta en la app,
            configura tus preferencias y ¡empieza a ganar!</p>
        </div>
        <img class="chollo" src="../../src/assets/MegaChollo.png">
        <div class="p-0 " style="background-color: #90ABB0;">
          <p class="text-center pb-2 fw-bold pt-2 mb-0 ofertaMil">
            ¡SI ERES UNO DE LOS 1.000 PRIMEROS EN APUNTARSE NO PAGAS TARIFA DE PUBLICACIÓN
            DURANTE 1 AÑO!
          </p>
        </div>
        <div class="p-0 botonSaberMas">
          <h4 class="text-center p-2 fw-semibold">Saber más</h4>
        </div>
      </div>
      <footer class="col-md-10 mx-auto pb-5">
        <div class="row m-0">
          <div class="col-lg-6 col-12">
            <img src="../../src/assets/logo.svg" class="col-md-6 offset-md-3 offset-lg-0 offset-2 col-8">
          </div>
          <div class="col-lg-6 d-flex align-items-end  justify-content-lg-end justify-content-center">
            <p class="text-white align-text-bottom mb-2 fw-semibold">
              2023 - Todos los derechos reservados
            </p>
          </div>
        </div>
        <div class="row m-0 mt-4">
          <div class="col-md-12 offset-md-0 col-8 offset-2 d-flex align-items-center justify-content-center">
            <p class="mb-2 text-white text-center">
              <a class="me-2 text-decoration-none text-white">POLÍTICA DE PRIVACIDAD</a> ·
              <a class="me-2 ms-2 text-decoration-none text-white">TÉRMINOS Y CONDICIONES</a> ·
              <a class="me-2 ms-2 text-decoration-none text-white">COOKIES</a> ·
              <a class="me-2 ms-2 text-decoration-none text-white">AVISO LEGAL</a> ·
              <a class="me-2 ms-2 text-decoration-none text-white">ALQUILA TU PLAZA</a> ·
              <a class="ms-2 text-decoration-none text-white">SOBRE NOSOTROS</a>
            </p>
          </div>
          <div class="col-12 mt-2">
            <p class="mb-2 text-white text-center fw-semibold">
              SIGUENOS EN: REDES SOCIALES
            </p>
          </div>
        </div>
      </footer>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import { mapState } from 'vuex';

export default {
  name: 'HomeA',
  data: function() {
        return {
            
            
        }
    },
  components: {
    
  },
  computed:{
      ...mapState(['isLoggedIn']),
      ...mapState(['name'])
  },
  async mounted() {
    await this.AddCitySelects()
    const optionMenu = document.querySelector(".select-menu"),
       selectBtn = optionMenu.querySelector(".select-btn"),
       options = optionMenu.querySelectorAll(".option"),
       sBtn_text = optionMenu.querySelector(".sBtn-text"),
       sBtn_icon = optionMenu.querySelector(".sBtn-icon");

    const optionTextBox = document.getElementById("textbox-place")

    selectBtn.addEventListener("click", () => optionMenu.classList.toggle("active"));    

    options.forEach(option =>{
        option.addEventListener("click", ()=>{
            let selectedOption = option.querySelector(".option-text").innerText;
            let iconClass = option.querySelector(".option-icon").classList;
            sBtn_text.innerText = selectedOption;
            sBtn_icon.classList = iconClass + " sBtn-icon"

            optionMenu.classList.remove("active");
        })
    })

    const optionMenuProvincia = document.getElementById("select-menu-provincia"),
       //selectBtnProvincia = optionMenuProvincia.querySelector("#select-btn-provincia"),
       optionsProvincia = optionMenuProvincia.querySelectorAll("#option-provincia");
       //sBtn_textProvincia = optionMenuProvincia.querySelector("#sBtn-text-provincia");

    //selectBtnProvincia.addEventListener("click", () => optionMenuProvincia.classList.toggle("active"));       
    optionTextBox.addEventListener("keydown", () => optionMenuProvincia.classList.toggle("active")); 
    console.log(optionsProvincia)
    optionsProvincia.forEach(option =>{
        option.addEventListener("click", ()=>{
            console.log(option)
            console.log(option.querySelector("#option-text-provincia"))
            let selectedOption = option.querySelector("#option-text-provincia").innerText;
            optionTextBox.value = selectedOption;

            optionMenuProvincia.classList.remove("active");
        })
    })

  },
  methods: {
    async AddCitySelects(){
      var provincias = []
      try {
        const response = await axios.get('https://organizacion-territorial-de-espana.p.rapidapi.com/provincia', {
          headers: {
            'X-RapidAPI-Key': 'af5fda20dfmshbbcbd119792f073p117a34jsn9c1efab267e7',
            'X-RapidAPI-Host' : 'organizacion-territorial-de-espana.p.rapidapi.com'
          }
        });
        console.log(response.data);
        provincias = response.data
      } catch (error) {
        console.error(error);
      }

      const cityUl = document.querySelector("#options-provincia")
      
      provincias.forEach(provincia => {
        var li = document.createElement("li")
        li.classList="option"
        li.id="option-provincia"
        cityUl.appendChild(li)

        var div = document.createElement("div")
        div.classList="mx-auto"
        li.appendChild(div)

        var span = document.createElement("span")
        span.classList="option-text"
        span.id="option-text-provincia"
        span.innerHTML=provincia[1]
        div.appendChild(span)
      })
    },
    logout() {
      this.$store.commit('logout');
    },
  }
}

</script>

<style>
  header{
    display: none !important;
  }
      .contenedorFondo {
          background-image: url(/src/assets/fondoApparca2.png);
          background-size: cover;
          width: 100%;
          height: 180%;
          background-position: center;
          z-index: 2;
      }
      .contenedorFondo2 {
          position: fixed;
          background-color: #0b2c33;
          width: 100%;
          bottom: 0;
          height: 100%;
          z-index: 1;
      }
      .row{
          width: auto;
      }
      .logo{
          margin-top: 7rem;
      }

      .filtro{
          margin-top: 4rem;
      }
      .botonEncontrar{
        border-radius: 0px 0px 25px 25px;
        background-color: #205760;
        transition: 0.5s;
      }

      .botonEncontrar:hover{
        cursor: pointer;
        background-color: #fa8e00;
      }

      .saberMas{
        margin-bottom: 14rem;
      }

      .botonSaberMas{
        border-radius: 0px 0px 25px 25px;
        background-color: #FA8E00;
        transition: 0.5s;
        color: #0B2C33;
      }

      .botonSaberMas:hover{
        cursor: pointer;
        background-color: #205760;
        color: white;
      }

      .chollo{
        position: absolute;
        z-index: 100;
        margin-left: 38%;
        margin-top: -5rem;
        height: 110px;
        width: auto;
      }

      .ofertaMil{
        font-size: 1.1rem;
        padding: 0px 4rem 0rem 4rem;
        color: #0B2C33;
      }

      @media screen and (max-width: 1400px) {
          .chollo{
            margin-left: 55%;
          }
      }

      @media screen and (max-width: 1200px) {
          .chollo{
            margin-left: 70%;
          }
      }

      @media screen and (max-width: 992px) {
          .logo{
              margin-top: 4rem
          }
          .chollo{
            margin-left: 83%;
            height: 90px;
          }
      }
      @media screen and (max-width: 768px) {
          .tbFiltro{
              margin-bottom: 1rem
          }
          .filtro{
            margin-top: 2rem;
          }
          .chollo{
            margin-left: 83%;
            margin-top: -3rem;
            height: 70px;
          }
          .ofertaMil{
            padding: 0px 4rem 0rem 4rem;
          }
          .saberMas{
            margin-bottom: 6rem;
          }
      }
      @media screen and (max-width: 576px) {
          .chollo{
            margin-top: -3rem;
            height: 70px;
            margin-left: 76%;
          }
      }


      /* ===== Google Font Import - Poppins ===== */
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600&display=swap');

#textbox-place{
  border: 0px;
  box-shadow: 0px;
}

#textbox-place:focus{
  border: 0px;
}

.select-menu{
    width: 100%;
    
}
.select-menu .select-btn{
    display: flex;
    height: 55px;
    background: #fff;
    padding: 20px;
    font-size: 18px;
    font-weight: 400;
    border-radius: 8px;
    align-items: center;
    cursor: pointer;
    justify-content: space-between;
    box-shadow: 0 0 5px rgba(0,0,0,0.1);
    border: 2px solid #1C4F58;
    border-radius: 5px;
    color: #1C4F58;
}
.select-btn i{
    font-size: 25px;
    transition: 0.3s;
    color: #1C4F58;
}
.select-menu.active .select-btn i{
    transform: rotate(-180deg);
}
.select-menu .options{
    position: absolute;
    width: 180px;
    padding: 20px;
    margin-top: 10px;
    border-radius: 8px;
    background: #fff;
    box-shadow: 0 0 3px rgba(0,0,0,0.1);
    display: none;
    
}
.select-menu.active .options{
    display: block;
}
.options{
    padding: 0px;
    margin: 0px;
    background-color: red;
}
.options .option{
    display: flex;
    height: 55px;
    width: 100%;
    cursor: pointer;
    padding: 0px;
    border-radius: 8px;
    align-items: center;
    background: #fff;
}
.options .option:hover{
    background: #F2F2F2;
}
.option i{
    margin-right: 12px;
    color: #1C4F58;
}
.option .option-text{
    font-size: 18px;
    color: #333;
}

#options-provincia::-webkit-scrollbar{
    width: 5px;
}

#options-provincia::-webkit-scrollbar-thumb {
    background-image: linear-gradient(180deg, #1C4F58 0%, #659097 99%);
    box-shadow: inset 2px 2px 5px 0 rgba(#fff, 0.5);
    border-radius: 100px;
}

</style>