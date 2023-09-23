import { modelohorarioBr } from "./datahorario.js";

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
    await GetMyWorkout();
}

const GetMyWorkout = async () => {
    
    const url = "http://localhost:5090/workoutroutine/getmyroutine/1";
    const getapi = await fetch(url, {
        method: 'GET',
        mode: 'cors'
    });

    const res = getapi.json();
    res.then(data => {
        data.map(item => {
            createContainerWorkout(item)
        })
    })
}

const listWk = document.getElementById('list-workout');
const createContainerWorkout = (workoutres) => {

    const ctninfoWk = document.createElement('div');
    ctninfoWk.classList.add('container-info-workout')

    const ctninfo = document.createElement('div');
    ctninfo.classList.add('container-info');

    const ins = document.createElement('ins');
    ins.appendChild(document.createTextNode(workoutres.routinename))

    const p = document.createElement('p');    
    p.appendChild(document.createTextNode('Criado em ' + modelohorarioBr(workoutres.routineCreated)))

    const ctnimgs = document.createElement('div');
    ctnimgs.classList.add("container-btn-download-delete");

    const divimgdown = document.createElement('div');
    divimgdown.classList.add('img-download');

    const imgdown = document.createElement('img');
    imgdown.classList.add('img-size');
    imgdown.src = "/public/images/icon-download.png";
    imgdown.alt = 'icon of a download';

    const divimgtrash = document.createElement('div');
    divimgtrash.classList.add('img-trash')

    const imgtrash = document.createElement('img');
    imgtrash.classList.add('img-size');
    imgtrash.src = "/public/images/icon-trash.png";
    imgtrash.alt = 'icon of a trash';

    divimgtrash.appendChild(imgtrash);
    divimgdown.appendChild(imgdown);
    ctnimgs.appendChild(divimgdown);
    ctnimgs.appendChild(divimgtrash);

    ctninfo.appendChild(ins);
    ctninfo.appendChild(p);

    ctninfoWk.appendChild(ctninfo);
    ctninfoWk.appendChild(ctnimgs);

    listWk.appendChild(ctninfoWk);
}
