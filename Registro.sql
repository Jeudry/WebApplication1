create database DBCRUDCORE
use DBCRUDCORE

CREATE TABLE CLIENTES(
Id_c int identity primary key,
nom_c varchar(50),
tel_c nvarchar(12),
cor_c nvarchar(50)
)

create procedure sp_Listar
as
begin
	select * from CLIENTES
end

create procedure sp_Obtener(
@Id_c int
)
as
begin
	select * from CLIENTES where Id_c = @Id_c
end

create procedure sp_Guardar(
@nom_c varchar(100),
@tel_c nvarchar(12),
@cor_c nvarchar(100)
)
as
begin
	insert into CLIENTES(nom_c, tel_c, cor_c) values (@nom_c, @tel_c ,@cor_c)
end

create procedure sp_Editar(
@Id_c int,
@nom_c varchar(100),
@tel_c nvarchar(12),
@cor_c nvarchar(100)
)
as
begin
	update CLIENTES set nom_c = @nom_c, tel_c = @tel_c, cor_c = @cor_c where Id_c = @Id_c
end

create procedure sp_Eliminar(
@Id_c int
)
as
begin
	delete from CLIENTES where Id_c = @Id_c
end