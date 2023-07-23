<template>
    <div class="container row mx-auto" >
        <div class="col-lg-6  d-flex align-items-center justify-content-center">
            <div class="text-center position-absolute d-flex align-items-center justify-content-center" style="height:86vh;" >
                <div class="spinner-border d-none" id="spinner" role="status">
                </div>
            </div>
            <div class="row col-10" id="formulario">
                <img src="../assets/APPARCA.png" class="col-lg-3 col-6 mb-3">
                <h3>Sign in to your account</h3>
                <form class="col-12" @submit.prevent="login">
                    <div class="mb-3 mt-4">
                        <v-text-field type="email" class=""
                            v-model="email"
                            :rules="nameRules"
                            :counter="50"
                            label="Email"
                            required
                            ref="emailInput"
                        ></v-text-field>
                    </div>
                    <div class="mb-3">
                        <v-text-field  type="password"
                            v-model="password"
                            :rules="nameRules"
                            :counter="20"
                            label="Contraseña"
                            required
                            ref="passwordInput"
                        ></v-text-field>
                        <div id="label" class="invalid-feedback d-none" style="font-size:1rem;">
                            Email o contraseña incorrecta
                        </div>
                    </div>
                    <div class="mb-3 form-check">
                        <input type="checkbox" checked class="form-check-input" v-model="remember">
                        <label class="form-check-label" for="exampleCheck1">Recuerdame</label>
                    </div>
                    <button type="submit" class="btn btn-outline-primary">Iniciar Sesion</button>
                    <a class="row text-decoration-none mt-3" href="/Register">¿No tienes cuenta? Registrate</a>
                </form>
                <div class="mt-3 row">

                </div>
            </div>
            
        </div>
        <div class="col-6 d-lg-block d-none photo" >
            <img src="../assets/loginImage.jpg">
        </div>
    </div>
</template>
<script>
import { mapState } from 'vuex';
export default {
  name: 'IniciarSesion',
  data() {
    return {
      email: '',
      password: '',
      camposCorrectos: true,
      remember: false,
      nameRules: [
        v => !!v || 'Campo Requerido',
        v => (v && this.camposCorrectos) || '',
      ],
    }
  },
    computed:{
        ...mapState(['isLoggedIn']),
        ...mapState(['token']),
        ...mapState(['name'])
    },
  methods: {
    async login() {
        var spinner = document.getElementById("spinner");
        spinner.classList = "spinner-border";
        var form = document.getElementById("formulario");
        form.style.opacity = 0.7;
        console.log(this.email)
        console.log(this.password)

        await fetch('https://localhost:7207/usuario/login?email='+this.email+'&password='+this.password, {
        method: 'POST'
        })
        .then(response => response.json())
        .then(data => {
            console.log(data)
            if(!data.success){
                document.getElementById("label").classList = "invalid-feedback d-block"
                this.camposCorrectos = false
                if (this.$refs.passwordInput) {
                    this.$refs.passwordInput.validate();
                }
                if (this.$refs.emailInput) {
                    this.$refs.emailInput.validate();
                }
            }else{
                var usuario = data.user.nombre.toString();
                console.log(usuario)
                console.log(data)
                this.$store.dispatch('setToken', data);
                console.log(this.name)
                var referrer = document.referrer.substring(21);
                console.log(referrer);
                if (referrer) {
                    this.$router.push(referrer);
                } else {
                    // Si no hay URL de referencia, redirigir a una página predeterminada
                    this.$router.push('/Home');
                }
            }
        })
        .catch(error => console.error(error))

        spinner.classList += "d-none";
        form.style.opacity = 1;
    },
  }
}

</script>

<style>
.photo img{
    width: 100%;
    height: 86vh;
    object-fit: cover;
}
</style>