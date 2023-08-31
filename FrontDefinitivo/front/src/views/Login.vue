<template>
    <div class="contenedor">
      <div class="forms-contenedor">
        <div class="signin-signup">
          <form @submit.prevent="IniciarSesion()" class="sign-in-form">
            <h2 class="title">Inicia Sesion</h2>
            <div class="input-field">
              <i class="fas fa-user"></i>
              <input v-model="usuarioLogin"  type="text" placeholder="Usuario" />
            </div>
            <div class="input-field" id="inputLoginFeedback">
              <i class="fas fa-lock"></i>
              <input v-model="passLogin" type="password" autocomplete="new-password" placeholder="Contraseña" />
            </div>
            <div class="invalid-feedback text-center">
                Datos Incorrectos
            </div>
            <input type="submit" value="Login" class="btn solid" />
            <p class="social-text">Visita nuestras Redes Socialessss</p>
            <div class="row redes">
              <a class="col p-0 pe-4" href="https://www.facebook.com/profile.php?id=100090094711157" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-facebook h-100" viewBox="0 0 16 16">
                  <path d="M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z"/>
                </svg>
              </a>
              <a class="col p-0 pe-4" href="https://www.instagram.com/apparca.es/?hl=es" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-instagram" viewBox="0 0 16 16">
                  <path d="M8 0C5.829 0 5.556.01 4.703.048 3.85.088 3.269.222 2.76.42a3.917 3.917 0 0 0-1.417.923A3.927 3.927 0 0 0 .42 2.76C.222 3.268.087 3.85.048 4.7.01 5.555 0 5.827 0 8.001c0 2.172.01 2.444.048 3.297.04.852.174 1.433.372 1.942.205.526.478.972.923 1.417.444.445.89.719 1.416.923.51.198 1.09.333 1.942.372C5.555 15.99 5.827 16 8 16s2.444-.01 3.298-.048c.851-.04 1.434-.174 1.943-.372a3.916 3.916 0 0 0 1.416-.923c.445-.445.718-.891.923-1.417.197-.509.332-1.09.372-1.942C15.99 10.445 16 10.173 16 8s-.01-2.445-.048-3.299c-.04-.851-.175-1.433-.372-1.941a3.926 3.926 0 0 0-.923-1.417A3.911 3.911 0 0 0 13.24.42c-.51-.198-1.092-.333-1.943-.372C10.443.01 10.172 0 7.998 0h.003zm-.717 1.442h.718c2.136 0 2.389.007 3.232.046.78.035 1.204.166 1.486.275.373.145.64.319.92.599.28.28.453.546.598.92.11.281.24.705.275 1.485.039.843.047 1.096.047 3.231s-.008 2.389-.047 3.232c-.035.78-.166 1.203-.275 1.485a2.47 2.47 0 0 1-.599.919c-.28.28-.546.453-.92.598-.28.11-.704.24-1.485.276-.843.038-1.096.047-3.232.047s-2.39-.009-3.233-.047c-.78-.036-1.203-.166-1.485-.276a2.478 2.478 0 0 1-.92-.598 2.48 2.48 0 0 1-.6-.92c-.109-.281-.24-.705-.275-1.485-.038-.843-.046-1.096-.046-3.233 0-2.136.008-2.388.046-3.231.036-.78.166-1.204.276-1.486.145-.373.319-.64.599-.92.28-.28.546-.453.92-.598.282-.11.705-.24 1.485-.276.738-.034 1.024-.044 2.515-.045v.002zm4.988 1.328a.96.96 0 1 0 0 1.92.96.96 0 0 0 0-1.92zm-4.27 1.122a4.109 4.109 0 1 0 0 8.217 4.109 4.109 0 0 0 0-8.217zm0 1.441a2.667 2.667 0 1 1 0 5.334 2.667 2.667 0 0 1 0-5.334z"/>
                </svg>
              </a>
              <a class="col p-0 pe-4" href="https://www.tiktok.com/@apparca" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-tiktok" viewBox="0 0 16 16">
                  <path d="M9 0h1.98c.144.715.54 1.617 1.235 2.512C12.895 3.389 13.797 4 15 4v2c-1.753 0-3.07-.814-4-1.829V11a5 5 0 1 1-5-5v2a3 3 0 1 0 3 3V0Z"/>
                </svg>
              </a>
              <a class="col p-0" href="https://twitter.com/Apparca_es" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-twitter" viewBox="0 0 16 16">
                  <path d="M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0 0 16 3.542a6.658 6.658 0 0 1-1.889.518 3.301 3.301 0 0 0 1.447-1.817 6.533 6.533 0 0 1-2.087.793A3.286 3.286 0 0 0 7.875 6.03a9.325 9.325 0 0 1-6.767-3.429 3.289 3.289 0 0 0 1.018 4.382A3.323 3.323 0 0 1 .64 6.575v.045a3.288 3.288 0 0 0 2.632 3.218 3.203 3.203 0 0 1-.865.115 3.23 3.23 0 0 1-.614-.057 3.283 3.283 0 0 0 3.067 2.277A6.588 6.588 0 0 1 .78 13.58a6.32 6.32 0 0 1-.78-.045A9.344 9.344 0 0 0 5.026 15z"/>
                </svg>
              </a>
            </div>
          </form>
          <form @submit.prevent="Registrarse()" class="sign-up-form">
            <h2 class="title">Regístrate</h2>
            <div class="w-100 p-0 m-0 d-flex align-items-center justify-content-center">
              <div class="w-100">
                <div class="input-field  mx-auto" id="inputuser">
                  <i class="fas fa-user"></i>
                  <input v-model="usuarioRegister" required autocomplete="new-password" type="text" placeholder="Usuario" />
                </div>
                <div class="invalid-feedback text-center">
                    Usuario ya existente
                </div>
              </div>
            </div>
            <div class="w-100 p-0 m-0 d-flex align-items-center justify-content-center">
              <div class="w-100">
                <div class="input-field  mx-auto" id="inputemail">
                  <i class="fas fa-envelope"></i>
                  <input v-model="emailRegister" required autocomplete="new-password" type="email" placeholder="Email" />
                </div>
                <div class="invalid-feedback text-center">
                    Email incorrecto
                </div>
              </div>
            </div>
            <div class="w-100 p-0 m-0 d-flex align-items-center justify-content-center">
              <div class="w-100">
                <div class="input-field  mx-auto" id="inputpass">
                  <i class="fas fa-lock"></i>
                  <input v-model="passRegister" required @input="ComprobarPass()" autocomplete="new-password" type="password" placeholder="Contraseña" />
                </div>
                <div class="invalid-feedback text-center">
                    La contraseña tiene que tener al menos 8 caracteres
                </div>
              </div>
            </div>
            <div class="w-100 p-0 m-0 d-flex align-items-center justify-content-center">
              <div class="w-100">
                <div class="input-field  mx-auto" id="inputpass2">
                  <i class="fas fa-lock"></i>
                  <input v-model="pass2Register" required @input="PassCoincidir()" autocomplete="new-password" type="password" placeholder="Confirmar Contraseña" />
                </div>
                <div class="invalid-feedback text-center">
                  Las contraseñas no coinciden
                </div>
              </div>
            </div>
            <input type="submit" class="btn" value="Registrarse" />
            <p class="social-text">Visita nuestras Redes Sociales</p>
            <div class="row redes iconsRegister">
              <a class="col p-0 pe-4" href="https://www.facebook.com/profile.php?id=100090094711157" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-facebook h-100" viewBox="0 0 16 16">
                  <path d="M16 8.049c0-4.446-3.582-8.05-8-8.05C3.58 0-.002 3.603-.002 8.05c0 4.017 2.926 7.347 6.75 7.951v-5.625h-2.03V8.05H6.75V6.275c0-2.017 1.195-3.131 3.022-3.131.876 0 1.791.157 1.791.157v1.98h-1.009c-.993 0-1.303.621-1.303 1.258v1.51h2.218l-.354 2.326H9.25V16c3.824-.604 6.75-3.934 6.75-7.951z"/>
                </svg>
              </a>
              <a class="col p-0 pe-4" href="https://www.instagram.com/apparca.es/?hl=es" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-instagram" viewBox="0 0 16 16">
                  <path d="M8 0C5.829 0 5.556.01 4.703.048 3.85.088 3.269.222 2.76.42a3.917 3.917 0 0 0-1.417.923A3.927 3.927 0 0 0 .42 2.76C.222 3.268.087 3.85.048 4.7.01 5.555 0 5.827 0 8.001c0 2.172.01 2.444.048 3.297.04.852.174 1.433.372 1.942.205.526.478.972.923 1.417.444.445.89.719 1.416.923.51.198 1.09.333 1.942.372C5.555 15.99 5.827 16 8 16s2.444-.01 3.298-.048c.851-.04 1.434-.174 1.943-.372a3.916 3.916 0 0 0 1.416-.923c.445-.445.718-.891.923-1.417.197-.509.332-1.09.372-1.942C15.99 10.445 16 10.173 16 8s-.01-2.445-.048-3.299c-.04-.851-.175-1.433-.372-1.941a3.926 3.926 0 0 0-.923-1.417A3.911 3.911 0 0 0 13.24.42c-.51-.198-1.092-.333-1.943-.372C10.443.01 10.172 0 7.998 0h.003zm-.717 1.442h.718c2.136 0 2.389.007 3.232.046.78.035 1.204.166 1.486.275.373.145.64.319.92.599.28.28.453.546.598.92.11.281.24.705.275 1.485.039.843.047 1.096.047 3.231s-.008 2.389-.047 3.232c-.035.78-.166 1.203-.275 1.485a2.47 2.47 0 0 1-.599.919c-.28.28-.546.453-.92.598-.28.11-.704.24-1.485.276-.843.038-1.096.047-3.232.047s-2.39-.009-3.233-.047c-.78-.036-1.203-.166-1.485-.276a2.478 2.478 0 0 1-.92-.598 2.48 2.48 0 0 1-.6-.92c-.109-.281-.24-.705-.275-1.485-.038-.843-.046-1.096-.046-3.233 0-2.136.008-2.388.046-3.231.036-.78.166-1.204.276-1.486.145-.373.319-.64.599-.92.28-.28.546-.453.92-.598.282-.11.705-.24 1.485-.276.738-.034 1.024-.044 2.515-.045v.002zm4.988 1.328a.96.96 0 1 0 0 1.92.96.96 0 0 0 0-1.92zm-4.27 1.122a4.109 4.109 0 1 0 0 8.217 4.109 4.109 0 0 0 0-8.217zm0 1.441a2.667 2.667 0 1 1 0 5.334 2.667 2.667 0 0 1 0-5.334z"/>
                </svg>
              </a>
              <a class="col p-0 pe-4" href="https://www.tiktok.com/@apparca" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-tiktok" viewBox="0 0 16 16">
                  <path d="M9 0h1.98c.144.715.54 1.617 1.235 2.512C12.895 3.389 13.797 4 15 4v2c-1.753 0-3.07-.814-4-1.829V11a5 5 0 1 1-5-5v2a3 3 0 1 0 3 3V0Z"/>
                </svg>
              </a>
              <a class="col p-0" href="https://twitter.com/Apparca_es" target="_blank">
                <svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi bi-twitter" viewBox="0 0 16 16">
                  <path d="M5.026 15c6.038 0 9.341-5.003 9.341-9.334 0-.14 0-.282-.006-.422A6.685 6.685 0 0 0 16 3.542a6.658 6.658 0 0 1-1.889.518 3.301 3.301 0 0 0 1.447-1.817 6.533 6.533 0 0 1-2.087.793A3.286 3.286 0 0 0 7.875 6.03a9.325 9.325 0 0 1-6.767-3.429 3.289 3.289 0 0 0 1.018 4.382A3.323 3.323 0 0 1 .64 6.575v.045a3.288 3.288 0 0 0 2.632 3.218 3.203 3.203 0 0 1-.865.115 3.23 3.23 0 0 1-.614-.057 3.283 3.283 0 0 0 3.067 2.277A6.588 6.588 0 0 1 .78 13.58a6.32 6.32 0 0 1-.78-.045A9.344 9.344 0 0 0 5.026 15z"/>
                </svg>
              </a>
            </div>
          </form>
        </div>
      </div>

      <div class="panels-contenedor">
        <div class="panel left-panel">
          <div class="content">
            <h3>Aún no estás registrado?</h3>
            <p>
              ¡Únete a nuestra comunidad y disfruta de todas las ventajas de Apparca!
            </p>
            <button class="btn transparent" id="sign-up-btn">
              Regístrate
            </button>
          </div>
          <img src="./../assets/ParkingIcon.png" class="image" alt="" />
        </div>
        <div class="panel right-panel ">
          <div class="content">
            <h3>Ya eres de los nuestros?</h3>
            <p>
              Tu Plaza, Tu Dinero, Tu Oportunidad, Apparca
            </p>
            <button class="btn transparent" id="sign-in-btn">
              Inicia Sesion
            </button>
          </div>
          <img src="./../assets/businessIcon.png" class="image" alt="" />
        </div>
      </div>
      <spinner-component id="spinner" class="d-none"></spinner-component>
    </div>
</template>

<script>
import axios from 'axios';
import SpinnerComponent from '../components/SpinnerComponent.vue'
import { mapState } from 'vuex';

export default {
  name: 'LoginPage',
  data: function() {
      return {
        usuarioLogin: "",
        passLogin: "",
        usuarioRegister: "",
        passRegister: "",
        pass2Register: "",
        emailRegister: "",
        passCorrectas: false
      }
    },
    computed:{
        ...mapState(['isLoggedIn']),
        ...mapState(['token']),
        ...mapState(['name'])
    },
  components:{
    SpinnerComponent
  },
  mounted() {
    const sign_in_btn = document.querySelector("#sign-in-btn");
    const sign_up_btn = document.querySelector("#sign-up-btn");
    const container = document.querySelector(".contenedor");

    console.log(this.$route.meta.isLogin)

    if(!this.$route.meta.isLogin){
      this.MoverBola()
    }

    sign_up_btn.addEventListener("click", () => {
      this.MoverBola()
    });

    sign_in_btn.addEventListener("click", () => {
      container.classList.remove("sign-up-mode");
    });
  },
  methods:{
    MoverBola() {
      const container = document.querySelector(".contenedor");
      container.classList.add("sign-up-mode");
    },
    async IniciarSesion(){
      var spinner = document.getElementById("spinner")
      spinner.classList.remove("d-none")
      console.log(this.usuarioLogin + this.passLogin)
      try {
        const response = 
        await axios.get('https://api.mapbox.com/geocoding/v5/mapbox.places/'+ this.inputValue +'.json?access_token=pk.eyJ1IjoiamJuMjAwMSIsImEiOiJjbGt3cW95NjMwM2JsM2tueWVrMHV0MnJoIn0.nI9ULLd2W_4P0JCku50Iww&country=es&limit=5');
        console.log(response.data);
        this.$store.dispatch('setToken', response.data);
      } catch (error) {
        console.error(error);
      }
      var input = document.getElementById("inputLoginFeedback")
      input.classList += " is-invalid"

      spinner.classList.add("d-none")
    },
    async Registrarse(){
      var spinner = document.getElementById("spinner")
      spinner.classList.remove("d-none")
      console.log(this.usuarioRegister + this.passRegister + this.pass2Register + this.emailRegister)

      const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
      var inputEmail = document.getElementById("inputemail")
      if (emailRegex.test(this.emailRegister)) {
        inputEmail.classList.remove("is-invalid")
      } else {
        inputEmail.classList.add("is-invalid")
      }

      var inputUser = document.getElementById("inputuser")
      inputUser.classList.add("is-invalid")

      try {
        const response = 
        await axios.get('https://api.mapbox.com/geocoding/v5/mapbox.places/'+ this.inputValue +'.json?access_token=pk.eyJ1IjoiamJuMjAwMSIsImEiOiJjbGt3cW95NjMwM2JsM2tueWVrMHV0MnJoIn0.nI9ULLd2W_4P0JCku50Iww&country=es&limit=5');
        console.log(response.data);
      } catch (error) {
        console.error(error);
      }

      spinner.classList.add("d-none")
    },
    PassCoincidir(){
      var input = document.getElementById("inputpass2")
      if(this.passRegister != this.pass2Register){
        input.classList.add("is-invalid")
        this.passCorrectas = false
      }else{
        input.classList.remove("is-invalid")
        this.passCorrectas = true
      }
    },
    ComprobarPass(){
      var input = document.getElementById("inputpass")
      if(this.passRegister.length < 7){
        input.classList.add("is-invalid")
      }else{
        input.classList.remove("is-invalid")
      }
      this.PassCoincidir()
    }
  }
}

</script>

<style>
@import url("https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600;700;800&display=swap");

* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body,
input {
  font-family: "Poppins", sans-serif;
}

.contenedor {
  position: relative;
  width: 100%;
  background-color: #fff;
  min-height: 100vh;
  overflow: hidden;
}

.forms-contenedor {
  position: absolute;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
}

.signin-signup {
  position: absolute;
  top: 50%;
  transform: translate(-50%, -50%);
  left: 75%;
  width: 50%;
  transition: 1s 0.7s ease-in-out;
  display: grid;
  grid-template-columns: 1fr;
  z-index: 5;
}

form {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  padding: 0rem 5rem;
  transition: all 0.2s 0.7s;
  overflow: hidden;
  grid-column: 1 / 2;
  grid-row: 1 / 2;
}

form.sign-up-form {
  opacity: 0;
  z-index: 1;
}

form.sign-in-form {
  z-index: 2;
}

.title {
  font-size: 2.2rem;
  color: #444;
  margin-bottom: 10px;
}

.input-field {
  max-width: 380px;
  width: 100%;
  background-color: #f0f0f0;
  margin: 10px 0;
  height: auto;
  border-radius: 55px;
  display: grid;
  grid-template-columns: 15% 85%;
  padding: 0 0.4rem;
  position: relative;
}

.input-field i {
  text-align: center;
  line-height: 55px;
  color: #acacac;
  transition: 0.5s;
  font-size: 1.1rem;
}

.input-field input {
  background: none;
  outline: none;
  border: none;
  line-height: 1;
  font-weight: 600;
  font-size: 1.1rem;
  color: #333;
}

.input-field input::placeholder {
  color: #aaa;
  font-weight: 500;
}

.social-text {
  padding: 0.7rem 0;
  font-size: 1rem;
}



.btn {
  width: 150px;
  border: none;
  outline: none;
  height: 49px;
  border-radius: 49px;
  color: #fff;
  text-transform: uppercase;
  font-weight: 600;
  margin: 10px 0;
  cursor: pointer;
  transition: 0.5s !important;
}

.btn:hover {
  background-color: #0b2c33 !important;
  color: white !important;
}
.panels-contenedor {
  position: absolute;
  height: 100%;
  width: 100%;
  top: 0;
  left: 0;
  display: grid;
  grid-template-columns: repeat(2, 1fr);
}

.contenedor:before {
  content: "";
  position: absolute;
  height: 2000px;
  width: 2000px;
  top: -10%;
  right: 48%;
  transform: translateY(-50%);
  background-image: linear-gradient(to bottom, white 0%, #0b2c33 70%);

  transition: 1.8s ease-in-out;
  border-radius: 50%;
  z-index: 6;
}

.image {
  width: 100%;
  transition: transform 1.1s ease-in-out;
  transition-delay: 0.4s;
}

.panel {
  display: flex;
  flex-direction: column;
  align-items: flex-end;
  justify-content: space-around;
  text-align: center;
  z-index: 6;
}

.left-panel {
  pointer-events: all;
  padding: 3rem 17% 2rem 12%;
}

.right-panel {
  pointer-events: none;
  padding: 3rem 12% 2rem 17%;
}

.panel .content {
  color: #fff;
  transition: transform 0.9s ease-in-out;
  transition-delay: 0.6s;
}

.panel h3 {
  font-weight: 600;
  line-height: 1;
  font-size: 1.5rem;
}

.panel p {
  font-size: 0.95rem;
  padding: 0.7rem 0;
}

.btn.transparent {
  margin: 0;
  background: none;
  border: 2px solid #fff;
  color: white;
  width: 130px;
  height: 41px;
  font-weight: 600;
  font-size: 0.8rem;
}

.right-panel .image,
.right-panel .content {
  transform: translateX(800px);
}

/* ANIMATION */

.contenedor.sign-up-mode:before {
  transform: translate(100%, -50%);
  right: 52%;
}

.contenedor.sign-up-mode .left-panel .image,
.contenedor.sign-up-mode .left-panel .content {
  transform: translateX(-800px);
}

.contenedor.sign-up-mode .signin-signup {
  left: 25%;
}

.contenedor.sign-up-mode form.sign-up-form {
  opacity: 1;
  z-index: 2;
}

.contenedor.sign-up-mode form.sign-in-form {
  opacity: 0;
  z-index: 1;
}

.contenedor.sign-up-mode .right-panel .image,
.contenedor.sign-up-mode .right-panel .content {
  transform: translateX(0%);
}

.contenedor.sign-up-mode .left-panel {
  pointer-events: none;
}

.contenedor.sign-up-mode .right-panel {
  pointer-events: all;
}

.redes{
  width: 250px;
}

.redes a svg path{
  color: #0b2c33;
}

@media (max-width: 870px) {
  .iconsRegister{
    display: none !important;
  }
  .contenedor:before {
    bottom: 72%;
    left: 50%;
    background-image: linear-gradient(to bottom, #0b2c33 0%, #0b2c33 10%);
  }
  .contenedor {
    min-height: 800px;
    height: 100vh;
  }
  .signin-signup {
    width: 100%;
    top: 95%;
    transform: translate(-50%, -100%);
    transition: 1s 0.8s ease-in-out;
  }

  .signin-signup,
  .contenedor.sign-up-mode .signin-signup {
    left: 50%;
  }

  .panels-contenedor {
    grid-template-columns: 1fr;
    grid-template-rows: 1fr 2fr 1fr;
  }

  .panel {
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    padding: 2.5rem 8%;
    grid-column: 1 / 2;
  }

  .right-panel {
    grid-row: 3 / 4;
  }

  .left-panel {
    grid-row: 1 / 2;
  }

  .image {
    width: 200px;
    transition: transform 0.9s ease-in-out;
    transition-delay: 0.6s;
  }

  .panel .content {
    padding-right: 15%;
    transition: transform 0.9s ease-in-out;
    transition-delay: 0.8s;
  }

  .panel h3 {
    font-size: 1.2rem;
  }

  .panel p {
    font-size: 0.7rem;
    padding: 0.5rem 0;
  }

  .btn.transparent {
    width: 110px;
    height: auto;
    font-size: 0.7rem;
  }

  .contenedor:before {
    width: 1500px;
    height: 1500px;
    transform: translateX(-50%);
    left: 30%;
    bottom: 68%;
    right: initial;
    top: initial;
    transition: 2s ease-in-out;
  }

  .contenedor.sign-up-mode:before {
    transform: translate(-50%, 100%);
    bottom: 32%;
    right: initial;
  }

  .contenedor.sign-up-mode .left-panel .image,
  .contenedor.sign-up-mode .left-panel .content {
    transform: translateY(-300px);
  }

  .contenedor.sign-up-mode .right-panel .image,
  .contenedor.sign-up-mode .right-panel .content {
    transform: translateY(0px);
  }

  .right-panel .image,
  .right-panel .content {
    transform: translateY(300px);
  }

  .contenedor.sign-up-mode .signin-signup {
    top: 5%;
    transform: translate(-50%, 0);
  }
}

@media (max-width: 570px) {
  form {
    padding: 0 1.5rem;
  }

  .image {
    display: none;
  }
  .panel .content {
    padding: 0.5rem 1rem;
  }
  .contenedor {
    padding: 1.5rem;
  }

  

  .contenedor.sign-up-mode:before {
    bottom: 28%;
    left: 50%;
  }
}

</style>