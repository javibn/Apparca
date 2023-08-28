<template>
  <div>
    <header v-if="$route.meta.showHeader">
      <nav class="navbar navbar-expand-md" style="min-height: 8vh;">
          <a class="navbar-brand ms-lg-0 ms-3" href="#">
            <img src="../src/assets/logoAverde.svg" class="d-inline-block align-text-top">
          </a>
          <button class="navbar-toggler border border-0 p-0 me-4" type="button" data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
            aria-label="Toggle navigation">
            <svg xmlns="http://www.w3.org/2000/svg" height="35" style="color: #205760;" fill="currentColor"
              class="bi bi-list" viewBox="0 0 16 16">
              <path fill-rule="evenodd"
                d="M2.5 12a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5zm0-4a.5.5 0 0 1 .5-.5h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5z" />
            </svg>
          </button>
          <div class="collapse navbar-collapse divNav" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto mb-2 mb-lg-0 ms-3 ">
              <li v-if="isLoggedIn" class="nav-item d-md-none d-block pt-2">
                <svg xmlns="http://www.w3.org/2000/svg" height="30" fill="currentColor" style="color:#205760;" class="bi bi-person-fill pb-1" viewBox="0 0 16 16">
                    <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z"/>
                </svg>
                <a class="fw-bold text-decoration-none" style="color: #205760" aria-current="page" href="#"> Mi cuenta</a>
                <a class="text-decoration-none" style="color: #205760" aria-current="page" href="#"> / </a>
                <a class="fw-bold text-decoration-none" style="color: #205760" href="#">Logout</a>
              </li>
              <li v-else class="nav-item d-md-none d-block pt-2">
                <img src="../src/assets/llaveVerde.png" class="mt-1" height="30">
                <a class="fw-bold text-decoration-none" style="color: #205760" aria-current="page" href="#">Login</a>
                <a class="text-decoration-none" style="color: #205760" aria-current="page" href="#">/</a>
                <a class="fw-bold text-decoration-none" style="color: #205760" href="#">Registro</a>
              </li>
              <li class="nav-item">
                <a class="nav-link fw-bold" style="color: #205760" aria-current="page" href="#">Encuentra aparcamiento</a>
              </li>
              <li class="nav-item fw-bold d-none d-lg-block">
                <a class="nav-link" style="color: #205760" aria-current="page" href="#">|</a>
              </li>
              <li class="nav-item">
                <a class="nav-link fw-bold" style="color: #205760" aria-current="page" href="#">Alquila tu plaza</a>
              </li>
            </ul>
            <ul class="navbar-nav d-none d-md-flex" v-if="isLoggedIn">
              <svg xmlns="http://www.w3.org/2000/svg" height="30" fill="currentColor" style="color:#205760" class="bi bi-person-fill mt-1" viewBox="0 0 16 16">
                  <path d="M3 14s-1 0-1-1 1-4 6-4 6 3 6 4-1 1-1 1H3Zm5-6a3 3 0 1 0 0-6 3 3 0 0 0 0 6Z"/>
              </svg>
              <li class="nav-item">
                <a class="nav-link fw-bold" style="color: #205760" aria-current="page" href="#">Mi cuenta</a>
              </li>
              <li class="nav-item fw-bold ">
                <a class="nav-link" style="color: #205760" aria-current="page" href="#">/</a>
              </li>
              <li class="nav-item fw-bold">
                <a class="nav-link" style="color: #205760" href="#">Logout</a>
              </li>
            </ul>
            <ul class="navbar-nav d-none d-md-flex" v-else>
              <img src="../src/assets/llaveVerde.png" class="mt-1" height="30">
              <li class="nav-item">
                <a class="nav-link fw-bold" style="color: #205760" aria-current="page" href="#">Login</a>
              </li>
              <li class="nav-item fw-bold ">
                <a class="nav-link" style="color: #205760" aria-current="page" href="#">/</a>
              </li>
              <li class="nav-item fw-bold">
                <a class="nav-link" style="color: #205760" href="#">Registro</a>
              </li>
            </ul>
        </div>
      </nav>
    </header>
    <router-view style="min-height: 75vh;width:100%;" />
    <div style="background-color: #0b2c33;">
      <footer class="col-md-10 mx-auto pb-5 pt-3">
        <div class="row m-0">
          <div class="col-lg-6 col-12">
            <img src="../src/assets/logo.svg" class="col-md-6 offset-md-3 offset-lg-0 offset-2 col-8">
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
import { mapState } from 'vuex';

export default {
  name: 'App',
  components: {
  },
  computed:{
      ...mapState(['isLoggedIn']),
      ...mapState(['name'])
  },
  mounted(){
  },
  methods:{
    logout() {
      this.$store.commit('logout');
    },
  }
}

</script>

<style>
* {
  font-family: 'Montserrat', sans-serif;
}

header {
  border-bottom: 2px solid #205760;
}

header nav{
  padding-left: 5% !important;
  padding-right: 5% !important;
}

.d-md-none{
  @import "/bootstrap/dist/css/bootstrap.css";
}

  @media screen and (max-width: 768px) {
    header nav{
      padding-left: 2% !important;
      padding-right: 2% !important;
    }
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
  }
</style>
