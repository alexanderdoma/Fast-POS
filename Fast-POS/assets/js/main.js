document.addEventListener('DOMContentLoaded', function () {
    iniciarApp();
})

function iniciarApp() {
    configMenuMobile();
}

function configMenuMobile() {
    const menu = document.querySelector('.icon-tabler-menu-2');
    menu.addEventListener('click', function () {
        const navegacion = document.querySelector('aside');
        if (navegacion.classList.contains('mostrar')) {
            navegacion.classList.remove('mostrar');
        } else {
            navegacion.classList.add('mostrar');
        }
    })
}