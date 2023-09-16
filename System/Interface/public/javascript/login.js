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

const email = document.getElementById('input-email');
const password = document.getElementById('input-senha');

const SignupUser = async () => {

    const url = "http://localhost:5090/access/loginaccount";
    const req = {
        emailuser: email.value,
        passworduser: password.value
    }

    const Api = await fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(req)
    });     

    const res = Api.json();
    res.then((data) => {

        if(data.error == 400)
            swal(data.message, "", "error");
        else{

            localStorage.setItem('iduser', data.iduser);
            window.location.href = "../src/pages/homeuser.html"
        }
    });
}