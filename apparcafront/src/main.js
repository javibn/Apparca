import { createApp } from 'vue'
import { ElDatePicker } from 'element-plus'
import App from './App.vue'
import router from './router'
import store from './store'

import "bootstrap/dist/css/bootstrap.css"
import "bootstrap/dist/js/bootstrap.min.js"
import "bootstrap"
import "jquery"

import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'




createApp(App)
  .use(router)
  .use(store)
  .use(ElementPlus, { 
    // Establecer isCustomElement en true
    compilerOptions: { isCustomElement: tag => tag.startsWith('el-') } 
  })
  .component('el-date-picker', ElDatePicker)
  .mount('#app')
