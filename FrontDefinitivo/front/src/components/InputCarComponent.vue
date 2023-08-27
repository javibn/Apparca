<template>
    <div class="select-menu">
        <div class="select-btn">
            <d class="fa-solid fa-car fs-5 sBtn-icon"></d>
            <span class="sBtn-text">Coche</span>
            <i class="bx bx-chevron-down"></i>
        </div>
        <ul class="options z-1" style="padding: 0px; width: 220px !important;">
            <li class="option ">
                <div class="mx-auto">
                    <i class="fa-solid fa-car fs-5 option-icon" ></i>
                    <span class="option-text ">Coche</span>
                </div>
            </li>
            <li class="option">
                <div class="mx-auto">
                <i class="fa-solid fa-motorcycle fs-5 option-icon" ></i>
                <span class="option-text">Moto</span>
                </div>
                
            </li>
        </ul>
    </div>   
</template>
  
  <script>
  
  export default {
    name: 'AddressBrowserComponent',
    data: function() {
          return {
            isCoche: true
          }
    },
    methods: {
        setData() {
            this.$emit("getDataCar", this.isCoche);
        }
    },
    async mounted(){
        
        const optionMenu = document.querySelector(".select-menu"),
        selectBtn = optionMenu.querySelector(".select-btn"),
        options = optionMenu.querySelectorAll(".option"),
        sBtn_text = optionMenu.querySelector(".sBtn-text"),
        sBtn_icon = optionMenu.querySelector(".sBtn-icon");

        console.log(selectBtn)

        selectBtn.addEventListener("click", () => {
            optionMenu.classList.toggle("active")
        });    

        options.forEach(option =>{
            option.addEventListener("click", ()=>{
                let selectedOption = option.querySelector(".option-text").innerText;
                let iconClass = option.querySelector(".option-icon").classList;
                sBtn_text.innerText = selectedOption;
                sBtn_icon.classList = iconClass + " sBtn-icon"
                if(selectedOption == "Moto"){
                    this.isCoche = false
                }
                else{
                    this.isCoche = true
                }
                optionMenu.classList.remove("active");
                this.setData()
            })
        })
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