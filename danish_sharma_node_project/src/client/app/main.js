import '../css/styles.css'; 
function addNavigationButtons() {
    const navbar = document.querySelector('.navbar ul');
    const pages = ['Index', 'About', 'List', 'Add', 'Contact'];

    pages.forEach(page => {
        const listItem = document.createElement('li');
        listItem.className = 'nav-item'; 
        const link = document.createElement('a');
        link.className = 'nav-link';
        link.href = page.toLowerCase().replace(' ', '') + '.html';
        link.textContent = page;
        listItem.appendChild(link);
        navbar.appendChild(listItem);
    });
}

// Function to dynamically update the footer with the current year
function footer() {
    const footerElement = document.querySelector('#mainfooter p');
    if (footerElement) {
        footerElement.innerHTML = `Copyright &copy; ${new Date().getFullYear()} Danish Sharma`;
    } else {
        console.error('Footer element not found');
    }
};

// Run the footer function when the DOM content is fully loaded
document.addEventListener('DOMContentLoaded', footer);

// Run the addNavigationButtons function when the DOM content is fully loaded
document.addEventListener('DOMContentLoaded', addNavigationButtons);
