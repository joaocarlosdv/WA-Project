

create table Tarefa(
	Id int NOT NULL AUTO_INCREMENT,
	Descricao varchar(100) not null,
	Feito boolean not null default true,
	
	CONSTRAINT PkTarefa primary key (Id)
);