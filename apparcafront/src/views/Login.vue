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
                    <div class="mb-3">
                        <label for="exampleInputEmail1" class="form-label">Email address</label>
                        <input type="" class="form-control" v-model="email" aria-describedby="emailHelp">
                    </div>
                    <div class="mb-3">
                        <label for="exampleInputPassword1" class="form-label">Password</label>
                        <input type="password" class="form-control" required v-model="password">
                    </div>
                    <div class="mb-3 form-check">
                        <input type="checkbox" class="form-check-input" v-model="remember">
                        <label class="form-check-label" for="exampleCheck1">Recuerdame</label>
                    </div>
                    <button type="submit" class="btn btn-outline-primary">Iniciar Sesion</button>
                    <a class="row text-decoration-none mt-3">¿No tienes cuenta? Registrate</a>
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

export default {
  name: 'IniciarSesion',
  data() {
    return {
      email: '',
      password: '',
      remember: false
    }
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
        .then(data => {
            console.log(data)
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