import tmplAbout from './about.ejs';
import '../../../img/path_to_your_image.jpg';  // Import the image or images used in the EJS file

export default async () => {
    const strAbout = tmplAbout();
    document.getElementById('app').insertAdjacentHTML('beforeend', strAbout);
}
