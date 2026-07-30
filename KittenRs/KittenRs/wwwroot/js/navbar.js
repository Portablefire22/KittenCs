
const navbarItems = document.getElementsByClassName("navbar-item");
let index = navbarItems.length - 1;

function navbarLeft() {
    navbarItems[index].id = "";
    index--;
    if (index < 0) {
        index = navbarItems.length - 1;
    }
    setCookie("navbar", index);
    navbarItems[index].id = "navbar-active";
}

function navbarRight() {
    navbarItems[index].id = "";
    index++;
    if (index > navbarItems.length - 1) {
        index = 0;
    }
    console.log(index);
    setCookie("navbar", index);
    navbarItems[index].id = "navbar-active";
}


function loadNavbar() {
    console.log(navbarItems.length);
    let cookie = getCookie("navbar");
    if (cookie === undefined) {
        setCookie("navbar", navbarItems.length - 1);
        cookie = navbarItems.length - 1;
    }
    index = cookie;


    
    for (let i = 0; i < navbarItems.length; i++) {
        navbarItems[i].id = "";
    }
    
    
    navbarItems[index].id = "navbar-active";
}

function getCookie(name) {
    const regex = new RegExp(`(^| )${name}=([^;]+)`)
    const match = document.cookie.match(regex)
    if (match) {
        return match[2]
    }
}

function setCookie(name,value,days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days*24*60*60*1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value)  + expires + "; path=/";
}