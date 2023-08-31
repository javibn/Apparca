import { createApp } from 'vue'
import App from './App.vue'

import router from './router'
import store from './store'



import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'

import 'fontsource-montserrat/700.css';

import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
  components,
  directives,
})

import "jquery"
import "bootstrap/dist/css/bootstrap.css"
import "bootstrap/dist/js/bootstrap.js"
import "axios"

import 'bootstrap-icons/font/bootstrap-icons.css'; // Importa el archivo CSS de Bootstrap Icons
import 'bootstrap-icons/font/bootstrap-icons';

const app = createApp(App);


app
  .use(router)
  .use(store)
  .use(vuetify)
  .use(ElementPlus, {
    // Establecer isCustomElement en true
    compilerOptions: { isCustomElement: (tag) => tag.startsWith('el-') },
  })
  .mount('#app');

