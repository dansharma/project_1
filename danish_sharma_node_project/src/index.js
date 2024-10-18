import Navigo from 'navigo';
import 'bootstrap';
import './scss/styles.scss';
import './client/img/red-panda1200.jpg';
import '@fortawesome/fontawesome-free';

import HeaderComponent from './client/app/components/header/header.js';
import FooterComponent from './client/app/components/footer/footer.js';
import HomeComponent from './client/app/pages/home/home.js';
import AboutComponent from './client/app/pages/about/about.js';

console.log("loaded javascript");

export const router = new Navigo('/');

window.addEventListener('load', () => {
    // Render Header and Footer
    HeaderComponent();
    FooterComponent();

    // Set up routes
    router
        .on('/', HomeComponent)
        .on('/about', AboutComponent)
        .resolve();

    // Handle dynamic routing with attribute 'route'
    document.addEventListener('click', event => {
        const route = event.target.getAttribute('route');
        if (route) {
            event.preventDefault();
            router.navigate(route);
        }
    });
});
