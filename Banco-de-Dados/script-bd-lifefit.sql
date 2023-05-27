
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

select * from tb_usuario;
select * from tb_rotina_treino;
select * from tb_exercicio;
select * from tb_dia_semana;