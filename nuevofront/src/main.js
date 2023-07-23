import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';

import PrimeVue from 'primevue/config';
import "primevue/resources/themes/lara-light-indigo/theme.css";     
import "primevue/resources/primevue.min.css";

// Vuetify
import 'vuetify/styles'
import { createVuetify } from 'vuetify'
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'
const vuetify = createVuetify({
    components,
    directives,
  })


// Element-Plus
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'

import Quasar from 'quasar'

createApp(App)
    .use(Quasar)
    .use(ElementPlus)
    .use(vuetify)
    .use(PrimeVue)
    .use(router)
    .mount('#app')
