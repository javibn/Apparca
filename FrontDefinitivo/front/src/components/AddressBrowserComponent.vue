<template>
    <div class="select-menu" id="select-menu-provincia">
        <div class="select-btn" id="select-btn-provincia">
            <d class="fa-solid fa-earth-europe fs-5"></d>
            <input ref="miInput" autocomplete="off" id="textbox-place" @focus="handleFocus" @blur="handleBlur" v-model.lazy="inputValue" @input="handleInput" class="form-control ms-2" placeholder="Provincia">
        </div>
        <ul class="options z-1" id="options-provincia" style="padding: 0px; overflow-y: scroll; overflow-x: hidden; width: 240px; ">
        </ul>
    </div>    
</template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: 'AddressBrowserComponent',
    data: function() {
          return {
            inputValue: "",
            typingTimer: null,
            centro: null,
            isCorrect: false,
          }
    },
    methods: {
        cazado(){
            this.$refs.miInput.classList += " is-invalid"
            this.$refs.miInput.classList.remove("is-valid")
        },
        async AddCitySelects(){
            var provincias = []
            try {
                const response = 
                await axios.get('https://api.mapbox.com/geocoding/v5/mapbox.places/'+ this.inputValue +'.json?access_token=pk.eyJ1IjoiamJuMjAwMSIsImEiOiJjbGt3cW95NjMwM2JsM2tueWVrMHV0MnJoIn0.nI9ULLd2W_4P0JCku50Iww&country=es&limit=5');
                console.log(response.data);
                provincias = response.data.features
            } catch (error) {
                console.error(error);
            }

            const cityUl = document.querySelector("#options-provincia")

            cityUl.innerHTML=""
            
            provincias.forEach(provincia => {
                var li = document.createElement("li")
                li.classList="option"
                li.id="option-provincia"
                cityUl.appendChild(li)

                var div = document.createElement("div")
                div.classList="mx-auto"
                li.appendChild(div)

                var span = document.createElement("p")
                span.classList="option-text pb-1 pt-3"
                span.innerHTML=provincia.place_name;
                div.appendChild(span)
                //li.addEventListener("mousedown", this.clickProvincia);
                li.addEventListener("mousedown", () => {
                    this.$refs.miInput.value = provincia.place_name;
                    this.inputValue = provincia.place_name
                    this.centro = provincia.center
                    if(!this.$refs.miInput.classList.contains("is-valid")){
                        this.$refs.miInput.classList += " is-valid"
                        this.$refs.miInput.classList.remove("is-invalid")
                        this.isCorrect = true
                    }
                    this.PasarVariables()
                });
            })
        },
        handleInput() {
            
            if(!this.$refs.miInput.classList.contains("is-invalid")){
                this.$refs.miInput.classList += " is-invalid"
                this.$refs.miInput.classList.remove("is-valid")
                this.isCorrect = false
                
            }
            clearTimeout(this.typingTimer);

            // Iniciar un temporizador para verificar si el usuario ha dejado de escribir durante 1 segundo
            this.typingTimer = setTimeout(() => {
                this.onTypingStopped();
            }, 100);
            this.PasarVariables()
        },
        onTypingStopped() {
            this.inputValue = this.$refs.miInput.value
            this.AddCitySelects()
        },
        async handleFocus() {
            console.log("El input ha obtenido el foco");
            await this.AddCitySelects()
            const optionMenuProvincia = document.getElementById("select-menu-provincia")
            optionMenuProvincia.classList.toggle("active");
        },
        handleBlur() {
            // Este evento se ejecutará cuando el input pierda el foco
            console.log("El input ha perdido el foco");
            const optionMenuProvincia = document.getElementById("select-menu-provincia")
            optionMenuProvincia.classList.toggle("active");
        },
        PasarVariables(){
            this.$emit("getDataBrowser", this.inputValue, this.centro, this.isCorrect);
        },
        CambiarDireccion(direccion){
            document.getElementById("textbox-place").value = direccion
        }
    }
  }
  </script>
  
  <style>
/* ===== Google Font Import - Poppins ===== */
@import url('https://fonts.googleapis.com/css2?family=Poppins:wght@200;300;400;500;600&display=swap');

#textbox-place{
  border: 0px;
  box-shadow: 0px;
}

#textbox-place:focus{
  border: 0px;
}

.select-menu{
    width: 100%;
    
}
.select-menu .select-btn{
    display: flex;
    height: 55px;
    background: #fff;
    padding: 20px;
    font-size: 18px;
    font-weight: 400;
    border-radius: 8px;
    align-items: center;
    cursor: pointer;
    justify-content: space-between;
    box-shadow: 0 0 5px rgba(0,0,0,0.1);
    border: 2px solid #1C4F58;
    border-radius: 5px;
    color: #1C4F58;
}
.select-btn i{
    font-size: 25px;
    transition: 0.3s;
    color: #1C4F58;
}
.select-menu.active .select-btn i{
    transform: rotate(-180deg);
}
.select-menu .options{
    position: absolute;
    width: 400px !important;
    padding: 20px;
    margin-top: 10px;
    border-radius: 8px;
    background: #fff;
    box-shadow: 0 0 3px rgba(0,0,0,0.1);
    display: none;
    
}
.select-menu.active .options{
    display: block;
}
.options{
    padding: 0px;
    margin: 0px;
    background-color: red;
}
.options .option{
    display: flex;
    height: 55px;
    width: 100%;
    cursor: pointer;
    padding: 0px;
    border-radius: 8px;
    align-items: center;
    background: #fff;
}
.options .option:hover{
    background: #F2F2F2;
}
.option i{
    margin-right: 12px;
    color: #1C4F58;
}
.option .option-text{
    font-size: 1rem;
    color: #333;
    white-space: nowrap;       /* Evita que el texto se divida en varias líneas */
    overflow: hidden;          /* Oculta cualquier contenido que se desborde */
    text-overflow: ellipsis;
    width: 350px;
}

#options-provincia::-webkit-scrollbar{
    width: 5px;
}

#options-provincia::-webkit-scrollbar-thumb {
    background-image: linear-gradient(180deg, #1C4F58 0%, #659097 99%);
    box-shadow: inset 2px 2px 5px 0 rgba(#fff, 0.5);
    border-radius: 100px;
}
  
  </style>