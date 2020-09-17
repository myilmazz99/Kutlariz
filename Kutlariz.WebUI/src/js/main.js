import '@fortawesome/fontawesome-free/js/all.js';
import alertify from 'alertifyjs';
import 'alertifyjs/build/css/alertify.css';
import '../scss/style.scss';
import '../img/birthdayBG.jpg';
import '../img/404.svg';
import '../img/500.svg';

window.alertify = alertify;

if (document.querySelector('.birthday-slider') !== null)
    import(/* webpackChunkName: "slider" */ './slider');

if (document.querySelector('.payment-form') !== null)
    import(/* webpackChunkName: "order" */ './order');

function expandNav() {
    document.querySelector(".nav-expand").classList.toggle("expand");
    const btn = document.querySelector(".nav-expand-btn").children;

    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.toggle("expand");
    }
}
document.querySelector('.nav-expand-btn').addEventListener('click', expandNav);

export const throwAlert = () => alertify;