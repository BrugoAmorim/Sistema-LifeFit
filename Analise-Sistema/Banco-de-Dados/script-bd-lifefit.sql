
create database dbLifeFit;
use dbLifeFit;

create table tb_usuario(
	id_usuario int primary key auto_increment,
    ds_nome varchar(100) not null,
    ds_email varchar(100) not null,
    ds_senha varchar(40) not null,
    dt_conta_criada datetime not null,
    dt_conta_atualizada datetime not null
);

create table tb_rotina_treino(
	id_rotina int primary key auto_increment,
    ds_nome_rotina varchar(100) not null,
    ds_tempo_duracao varchar(100) not null,
    dt_rotina_criada datetime not null,
    id_usuario int,
    
    foreign key(id_usuario) references tb_usuario(id_usuario)
);

create table tb_dia_semana(
	id_dia_semana int primary key auto_increment,
    ds_dia_semana varchar(20) not null
);

create table tb_exercicio(
	id_exercicio int primary key auto_increment,
    ds_series_e_repeticoes varchar(100) not null,
    ds_exercicio varchar(100) not null,
    ds_tempo_descanso varchar(100) not null,
    ds_carga_aquecimento varchar(30) not null,
    ds_carga_maxima varchar(30) not null,
    id_dia_semana int,
    id_rotina int,
    
    foreign key(id_dia_semana) references tb_dia_semana(id_dia_semana),
    foreign key(id_rotina) references tb_rotina_treino(id_rotina)
);



-- Inserts tb_usuario

insert into tb_usuario(ds_nome, ds_email, ds_senha, dt_conta_criada, dt_conta_atualizada)
values('Bruno Gomes', 'bruno123@gmail.com', '12345678', '2023-05-10', '2023-05-10');

insert into tb_usuario(ds_nome, ds_email, ds_senha, dt_conta_criada, dt_conta_atualizada)
values('Luisa Souza', 'luh_2023@gmail.com', '987654321', '2023-05-14', '2023-05-17');

-- Inserts tb_rotina_treino

insert into tb_rotina_treino(ds_nome_rotina, ds_tempo_duracao, dt_rotina_criada, id_usuario)
values('Rotina-1', '3 semanas', '2023-05-02', 1);

insert into tb_rotina_treino(ds_nome_rotina, ds_tempo_duracao, dt_rotina_criada, id_usuario)
values('Treino adaptação', '1 semana', '2023-05-05', 2);

insert into tb_rotina_treino(ds_nome_rotina, ds_tempo_duracao, dt_rotina_criada)
values('Minha rotina de treino', '6 meses', '2023-05-08');

-- Inserts tb_dia_semana

insert into tb_dia_semana(ds_dia_semana)
values('Segunda-feira');

insert into tb_dia_semana(ds_dia_semana)
values('Terça-feira');

insert into tb_dia_semana(ds_dia_semana)
values('Quarta-feira');

insert into tb_dia_semana(ds_dia_semana)
values('Quinta-feira');

insert into tb_dia_semana(ds_dia_semana)
values('Sexta-feira');

insert into tb_dia_semana(ds_dia_semana)
values('Sábado');

insert into tb_dia_semana(ds_dia_semana)
values('Domingo');

-- Inserts tb_exercicio

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'agachamento livre', '1 min', '10kg', '40kg', 1, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'leg press', '1 min', '20kg', '60kg', 1, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'cadeira extensora', '1 min', '40kg', '70kg', 1, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'agachamento unilateral', '1 min', '5kg', '10kg', 1, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'supino reto', '1 min', '10kg', '20kg', 2, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'supino com halters', '1 min', '8kg', '10kg', 2, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'rosca martelo', '1 min', '7kg', '10kg', 2, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'elevacao frontal com barra', '1 min', '10kg', '15kg', 2, 1);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'abdominal', '1 min', 'nenhum', 'nenhum', 1, 2);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'remada curvada', '1 min', '12kg', '20kg', 1, 2);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 6 repeticoes', 'barra fixa', '1 min', 'nenhum', 'nenhum', 1, 2);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'agachamento livre', '3 min', '30kg', '80kg', 1, 3);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'cadeira extensora', '3 min', '50kg', '80kg', 1, 3);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'leg press', '3 min', '10kg', '40kg', 1, 3);

insert into tb_exercicio(ds_series_e_repeticoes, ds_exercicio, ds_tempo_descanso, ds_carga_aquecimento, ds_carga_maxima, id_dia_semana, id_rotina)
values('4 series de 12 repeticoes', 'agachamento unilateral', '3 min', '15kg', '20kg', 1, 3);


