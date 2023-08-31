<template>
    <div class="spinner-container">
      <div class="spinner"></div>
    </div>
  </template>
  
  <style>
  /* Estilo para el contenedor del spinner */
  .spinner-container {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5); /* Fondo oscuro con opacidad */
    display: flex;
    justify-content: center;
    align-items: center;
    z-index: 999; /* Asegura que esté por encima de otros elementos */
  }
  
  /* Estilo para el spinner */
  .spinner {
    border: 4px solid #f3f3f3;
    border-top: 4px solid #0b2c33;
    border-radius: 50%;
    width: 50px;
    height: 50px;
    animation: spin 2s linear infinite; /* Animación de rotación */
  }
  
  @keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
  }
  </style>
  