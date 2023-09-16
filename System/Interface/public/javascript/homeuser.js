

const btnLogOff = document.getElementById("btn-logoff");
btnLogOff.onclick = () => {

    localStorage.removeItem('iduser');
    window.location.href = "../home.html";
}

const usernameHone = document.getElementById('username');
const GetMyData = async () => {

    const idUser = localStorage.getItem('iduser');    
    const url = "http://localhost:5090/User/GetmyData/" + idUser;

    const Get = await fetch(url, {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Content-type': 'application/json'
        }
    });

    const res = Get.json();
    res.then((data) => { 
        
        usernameHone.appendChild(document.createTextNode(data.nameuser));
    });
}

window.onload = async () =>{

    await GetMyData();
} 
