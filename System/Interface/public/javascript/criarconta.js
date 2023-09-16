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

const usernameinp = document.getElementById("username-inp");
const emailinp = document.getElementById("useremail-inp");
const passwordinp = document.getElementById("password-inp");
const confirmpasswordinp = document.getElementById("confirmpassword-inp");

const CreateAccount = async () => {

    const url = "http://localhost:5090/access/createaccount";
    const reqCreateAcc = {
        username: usernameinp.value,
        emailuser: emailinp.value,
        newpassword: passwordinp.value,
        confirmpassword: confirmpasswordinp.value
    }

    const api = await fetch(url, {
        mode: 'cors',
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify(reqCreateAcc)
    });

    const res = api.json();
    res.then((data) => {

        if(data.error == 400)
            swal(data.message, "", "error");
        else{
            usernameinp.value = "";
            emailinp.value = "";
            passwordinp.value = "";
            confirmpasswordinp.value = "";
        
            swal("Account created successufly", "", "success");
        }
    })
}