<template>
  <div>
    <nav class="navbar navbar-expand" style="height: 8vh;">
      <div class="container">
        <a class="navbar-brand ms-lg-0 ms-3" href="#">
          <img src="/src/assets/logoA.svg" class="d-inline-block align-text-top">
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
            <img src="/src/assets/llave.png" class="mt-1" height="30">
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
  <router-view style="min-height: 87vh;width:100%;"/>
  <footer class="text-muted container-fluid border-top bg-dark px-md-5 align-items-center"
  style="height: 5vh;width:100%;" >
        Apparca
  </footer>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'App',
});
</script>
