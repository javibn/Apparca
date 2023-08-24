import { createApp } from 'vue'
import App from './App.vue'

import router from './router'
import store from './store'

import "jquery"
import "bootstrap/dist/css/bootstrap.css"
import "bootstrap/dist/js/bootstrap.js"
import "axios"

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'

import 'fontsource-montserrat/700.css';

createApp(App)
    .use(router)
    .use(store)
    .use(ElementPlus, { 
        // Establecer isCustomElement en true
        compilerOptions: { isCustomElement: tag => tag.startsWith('el-') } 
      })
    .mount('#app')
