window.showAlert = (message) =>{
    alert(message);
}


const fontSizes = document.querySelectorAll('.choose-size span');
const root = document.querySelector(':root');
const colorPalette = document.querySelectorAll('.choose-color span')

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