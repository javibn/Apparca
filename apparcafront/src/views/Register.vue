<template>
    <div class="container row mx-auto" >
        <div class="col-6 d-lg-block d-none photoR" >
            <img src="../assets/registerImage.jpg">
        </div>
        <div class="col-lg-6  d-flex align-items-center justify-content-center">
            <div class="text-center position-absolute d-flex align-items-center justify-content-center" style="height:86vh;" >
                <div class="spinner-border d-none" id="spinner" role="status">
                </div>
            </div>
            <div class="row col-10" id="formulario">
                <img src="../assets/APPARCA.png" class="col-lg-3 col-6 mb-3">
                <h3>Registrate GRATIS!</h3>
                <form class="col-12 mt-4" @submit.prevent="Register">
                    <div class="mb-2">
                        <v-text-field  type="text"
                            v-model="name"
                            :counter="50"
                            label="Nombre Competo"
                            required
                        ></v-text-field>
                    </div>
                    <div class="mb-2">
                        <v-text-field  type="Email"
                            v-model="email"
                            :counter="50"
                            label="Email"
                            required
                        ></v-text-field>
                    </div>
                    <div class="mb-2">
                        <v-text-field  type="password"
                            v-model="password"
                            :counter="20"
                            label="Contraseña"
                            required
                        ></v-text-field>
                    </div>
                    <div class="mb-4">
                        <v-text-field  type="password"
                            v-model="repeatPassword"
                            :rules="nameRules"
                            :counter="20"
                            label="Repetir Contraseña"
                            required
                            ref="passwordInput"
                        ></v-text-field>
                    </div>
                    <button type="submit" class="btn btn-outline-primary">Registrarme</button>
                    <a href="/Login" class="row text-decoration-none mt-3">¿Ya tienes cuenta? Inicia Sesion</a>
                </form>
            </div>
            
        </div>
        
    </div>
</template>
<script>
import { mapState } from 'vuex';
export default {
  name: 'RegistrarseView',
  data() {
    return {
        name:"",
        email: '',
        password: '',
        repeatPassword: '',
        nameRules: [
            v => !!v || 'Campo Requerido',
            v => (v && this.password == this.repeatPassword) || 'Las contraseñas no coinciden',
        ],
    }
  },
    computed:{
        ...mapState(['isLoggedIn']),
        ...mapState(['token'])
    },
  methods: {
    async Register() {
        var spinner = document.getElementById("spinner");
        spinner.classList = "spinner-border";
        var form = document.getElementById("formulario");
        form.style.opacity = 0.7;
        console.log(this.email)
        console.log(this.password)

        if(this.password === this.repeatPassword  && this.password.length>4){
            await fetch('https://localhost:7207/usuario/registro?email='+this.email+'&password='+this.password+'&nombre='+this.name, {
            method: 'POST'
            })
            .then(response => response.json())
            .then(data => {
                var usuario = data.user.nombre.toString();
                console.log(usuario)
                console.log(data)
                this.$store.dispatch('setToken', data);
                console.log(this.name)
                this.$router.push('/');
                
            })
            .catch(error => console.error(error))
        }else{
            console.log("no entro")
            document.getElementById("inputRPassword").classList = "pac-target-inputis-valid is-invalid form-control"
        }

        spinner.classList += "d-none";
        form.style.opacity = 1;
    },
  }
}

</script>

<style>
.photoR img{
    width: 100%;
    height: 86vh;
    object-fit: cover;
}
</style>