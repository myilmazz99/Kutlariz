import { tns } from 'tiny-slider/src/tiny-slider';
import 'tiny-slider/src/tiny-slider.scss';

tns({
    container: '.birthday-slider',
    items: 1,
    slideBy: 1,
    loop: true,
    nav: false,
    controlsText:["<", ">"],
    center: true,
    controls: true,
    responsive: {
        768: {
            items: 2,
            gutter:10
        }
    },
    autoplay: false
});
