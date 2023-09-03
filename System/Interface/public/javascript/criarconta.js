const showCreateAccount = () => {
    const customAlert = document.getElementById('criarconta-modal');
    customAlert.style.display = 'block';
}

const closeCreateAccount = () => {
    const customAlert = document.getElementById('criarconta-modal');
    customAlert.style.display = 'none';

    const inputs = document.getElementsByTagName('input');
    for (let i = 0; i < inputs.length; i++) {
        inputs[i].value = '';
    }
}
