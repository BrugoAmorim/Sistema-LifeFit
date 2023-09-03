const showLogin = () => {
    const customAlert = document.getElementById('login-modal');
    customAlert.style.display = 'block';
}

const closeLogin = () => {
    const customAlert = document.getElementById('login-modal');
    customAlert.style.display = 'none';

    const inputs = document.getElementsByTagName('input');
    for (let i = 0; i < inputs.length; i++) {
        inputs[i].value = '';
    }
}