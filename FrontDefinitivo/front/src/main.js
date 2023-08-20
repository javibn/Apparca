import { createApp } from 'vue'
import App from './App.vue'

import router from './router'

import "jquery"
import "bootstrap/dist/css/bootstrap.css"
import "bootstrap/dist/js/bootstrap.js"


import 'fontsource-montserrat/700.css';

createApp(App)
    .use(router)
    .mount('#app')
