const optionMenu = document.querySelector(".select-menu"),
       selectBtn = optionMenu.querySelector(".select-btn"),
       options = optionMenu.querySelectorAll(".option"),
       sBtn_text = optionMenu.querySelector(".sBtn-text");
       sBtn_icon = optionMenu.querySelector(".sBtn-icon");

selectBtn.addEventListener("click", () => optionMenu.classList.toggle("active"));       

options.forEach(option =>{
    option.addEventListener("click", ()=>{
        let selectedOption = option.querySelector(".option-text").innerText;
        let iconClass = option.querySelector(".option-icon").classList;
        sBtn_text.innerText = selectedOption;
        sBtn_icon.classList = iconClass + " sBtn-icon"

        optionMenu.classList.remove("active");
    })
})

const optionMenuProvincia = document.getElementById("select-menu-provincia"),
       selectBtnProvincia = optionMenuProvincia.querySelector("#select-btn-provincia"),
       optionsProvincia = optionMenuProvincia.querySelectorAll("#option-provincia"),
       sBtn_textProvincia = optionMenuProvincia.querySelector("#sBtn-text-provincia");

selectBtnProvincia.addEventListener("click", () => optionMenuProvincia.classList.toggle("active"));       

optionsProvincia.forEach(option =>{
    option.addEventListener("click", ()=>{
        let selectedOption = option.querySelector("#option-text-provincia").innerText;
        sBtn_textProvincia.innerText = selectedOption;

        optionMenuProvincia.classList.remove("active");
    })
})