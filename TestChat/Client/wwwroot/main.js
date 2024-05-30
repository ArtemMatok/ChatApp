window.triggerFileInputClick = function (inputId) {
    document.getElementById(inputId).click();
};




window.showAlert = (message) => {
    alert(message);
}


const fontSizes = document.querySelectorAll('.choose-size span');
const root = document.querySelector(':root');
const colorPalette = document.querySelectorAll('.choose-color span')
const Bg1 = document.querySelector('.bg-1');
const Bg2 = document.querySelector('.bg-2');
const Bg3 = document.querySelector('.bg-3');





window.changeSize = (numberSize) => {

   
        let fontSize;

        if (numberSize == 1) {
            fontSize = '10px';
            root.style.setProperty('----sticky-top-left:5', '5.4rem');
            root.style.setProperty('----sticky-top-right:5', '5.4rem');
        } else if (numberSize == 2) {
            fontSize = '11px';
            root.style.setProperty('----sticky-top-left:5', '5.4rem');
            root.style.setProperty('----sticky-top-right:5', '-7rem');
        } else if (numberSize == 3) {
            fontSize = '13px';
            root.style.setProperty('----sticky-top-left:5', '-2rem');
            root.style.setProperty('----sticky-top-right:5', '-17rem');
        } else if (numberSize == 4) {
            fontSize = '16px';
            root.style.setProperty('----sticky-top-left:5', '-5rem');
            root.style.setProperty('----sticky-top-right:5', '-25rem');
        } else if (numberSize == 5) {
            fontSize = '17px';
            root.style.setProperty('----sticky-top-left:5', '-10rem');
            root.style.setProperty('----sticky-top-right:5', '-35rem');
        }
        document.querySelector('html').style.fontSize = fontSize;



}



window.changeColor = (colorNumber) => {
    

    if (colorNumber == 1) {
        primaryHue = 252;
    } else if (colorNumber == 2) {
        primaryHue = 52;
    } else if (colorNumber == 3) {
        primaryHue = 352;
    } else if (colorNumber == 4) {
        primaryHue = 152;
    } else if (colorNumber == 5) {
        primaryHue = 202;
    }

    root.style.setProperty('--primary-color-hue', primaryHue);
}

let lightColorLightness;
let whiteColorLightness;
let darkColorLightness;

const changeBG = () => {
    root.style.setProperty('--light-color-lightness', lightColorLightness);
    root.style.setProperty('--white-color-lightness', whiteColorLightness);
    root.style.setProperty('--dark-color-lightness', darkColorLightness);
}

window.changeBackColor = (backColorNumber) => {


    if (backColorNumber == 1) {
        
        window.location.reload();
    } else if (backColorNumber == 2) {
        darkColorLightness = '95%';
        whiteColorLightness = '15%';
        lightColorLightness = '20%';

      
        changeBG();
    } else if (backColorNumber == 3) {
        darkColorLightness = '95%';
        whiteColorLightness = '0%';
        lightColorLightness = '10%';

        
        changeBG();
    }
}