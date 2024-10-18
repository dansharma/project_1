import tmplContact from './contact.ejs';

export default async () => {
    const strContact = tmplContact();
    document.getElementById('app').insertAdjacentHTML('beforeend', strContact);
}
