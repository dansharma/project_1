import { StorageService } from './contact.service.js';

document.addEventListener('DOMContentLoaded', function() {
    const form = document.getElementById('contact-form');
    
    form.addEventListener('submit', function(event) {
        event.preventDefault();
        let valid = true;  

        const fullName = form.fullName.value.trim();
        const fullNameError = document.getElementById('fullnameError');
        if (fullName === "") {
            fullNameError.classList.remove('d-none');
            fullNameError.textContent = " name is required";
            valid = false;
        } else {
            fullNameError.classList.add('d-none');
            
        }

      
        const email = form.email.value.trim();
        const emailError = document.getElementById('emailError');
        if (!email.includes('@')) {
            emailError.classList.remove('d-none');
            emailError.textContent = "icorrect emsail";
            valid = false;
        } else {
            emailError.classList.add('d-none');
        }

        const phone = form.phone.value.trim();
        const phoneError = document.getElementById('phoneError');
        if (phone !== "" && !phone.match(/^\d+$/ )) {
            phoneError.classList.remove('d-none');
            phoneError.textContent = " numeric values are allowed";
            valid = false;
        } else {
            phoneError.classList.add('d-none');
        }


        const message = form.message.value.trim();
        const messageError = document.getElementById('messageError');
        if (message === "") {
            messageError.classList.remove('d-none');
            messageError.textContent = "Message cannot be empty";
            valid = false;
        } else {
            messageError.classList.add('d-none');
        }

        if (!valid) return;  

        const contactData = {
            fullName,
            email,
            phone,
            message
        };

    
        StorageService.saveContactData(contactData);
        console.log('Full Name:', fullName);
        console.log('Email:', email);
        console.log('Phone:', phone);
        console.log('Message:', message);
        successMessage.classList.remove('d-none');
        
        form.reset(); 
    });
});
