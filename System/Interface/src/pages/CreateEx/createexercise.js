const makecomponentsInfo = () => {

    const divinfo = document.createElement('div');
    divinfo.classList.add('info');

    const divExer = document.createElement('div');
    divExer.classList.add('blc-inp');

    const inpexer = document.createElement('input');
    inpexer.placeholder = 'Exercicio';
    divExer.appendChild(inpexer);

    const divSxR = document.createElement('div');
    divSxR.classList.add('blc-inp');

    const inpsxr = document.createElement('input');
    inpsxr.placeholder = 'Series x Repeticoes';
    divSxR.appendChild(inpsxr);

    const divTime = document.createElement('div');
    divTime.classList.add('blc-time');

    const seltime = makesltRestTime();
    divTime.appendChild(seltime);

    const divAquec = document.createElement('div');
    divAquec.classList.add('blc-sel');

    const selaquec = makeselectWeight();
    divAquec.appendChild(selaquec);

    const divMax = document.createElement('div');
    divMax.classList.add('blc-sel');

    const selmax = makeselectWeight();
    divMax.appendChild(selmax);
    
    const divImgtrash = document.createElement('div');
    divImgtrash.classList.add('blc-img');
    
    const btndelExer = document.createElement('button');

    const imgtrash = document.createElement('img');
    imgtrash.src = "../../../public/images/icon-trash.png";
    imgtrash.alt = 'icon trash';
    imgtrash.classList.add('img-trash');
    
    btndelExer.appendChild(imgtrash);
    divImgtrash.appendChild(btndelExer);

    divinfo.appendChild(divExer);
    divinfo.appendChild(divSxR);
    divinfo.appendChild(divTime);
    divinfo.appendChild(divAquec);
    divinfo.appendChild(divMax);
    divinfo.appendChild(divImgtrash);

    return divinfo;
}

const makeselectWeight = () => {

    const select = document.createElement('select');

    const optDefault = document.createElement('option');
    optDefault.appendChild(document.createTextNode('Carga'));
    optDefault.selected = true;

    select.appendChild(optDefault);

    let vl = 0;
    for(let i = 0; i < 10; i++){

        vl += 10;

        const opt = document.createElement('option');
        opt.value = vl + 'kg';
        opt.appendChild(document.createTextNode(vl + 'kg'))
    
        select.appendChild(opt);
    }

    return select;
}

const makesltRestTime = () => {
    
    const select = document.createElement('select');

    let vl = 0;
    for(let i = 1; i < 4; i++){

        vl += 15;

        const opt = document.createElement('option');
        opt.value = vl + 's';
        opt.appendChild(document.createTextNode(vl + 's'))
    
        select.appendChild(opt);
    }

    minuto = 1;
    seg = 0;
    for(let i = 1; i < 10; i++){

        let x = minuto < 10 ? "0" + minuto : minuto;
        let z = seg < 10 ? "0" + seg : seg;
    
        seg += 30;
        if(seg >= 60){
            minuto++
            seg = 0;
        }

        const opt = document.createElement('option');
        opt.value = x + ":" + z + "min";
        opt.appendChild(document.createTextNode(x + ":" + z + "min"));

        select.appendChild(opt)
    }

    return select;
} 

const days = document.getElementById('daysWeek');
const makesDayofWeek = () => {

    const diasSemana = ['Domingo', 'Segunda-feira', 'Terça-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sábado'];

    diasSemana.map(dia => {

        const opt = document.createElement('option');
        opt.appendChild(document.createTextNode(dia));
        opt.value = dia;

        days.appendChild(opt);
    });
}

const selTime = document.getElementById('TimeExercises');
const makesTimeExercises = () => {

    const time = [ '1 semana', '4 semanas', '3 meses', '6 meses', '1 ano', '+1 ano' ];
    
    time.map(day => {

        const opt = document.createElement('option');
        opt.appendChild(document.createTextNode(day));
        opt.value = day;

        selTime.appendChild(opt);
    })
}

const tbody = document.getElementById('table-body');
const applyInfo = () => {

    const info = makecomponentsInfo();
    tbody.appendChild(info);
}

window.onload = () => {

    applyInfo();
    makesDayofWeek();
    makesTimeExercises();
}