create database DBCrudCore
go
use DBCrudCore
go
create table contacto(
IdContacto int identity primary key,
Nombre varchar(50),
Telefono varchar(50),
Correo varchar(50)
)
go
create procedure sp_Listar as
begin
	select * from contacto
end
go
create procedure sp_Obtener(@idcontacto int) as
begin
	select * from contacto where IdContacto=@idcontacto 
end
go
create procedure sp_Guardar(@nombre varchar(50), @telefono varchar(50), @correo varchar(50)) as
begin
	insert contacto(Nombre,Telefono,Correo) values(@nombre ,@telefono,@correo)
end
go
create procedure sp_actualizar(@IdContacto int ,@nombre varchar(50), @telefono varchar(50), @correo varchar(50)) as
begin
	update contacto
	set
	Nombre=@nombre,
	Telefono=@Telefono,
	Correo=@Correo
	where IdContacto=@IdContacto
end
go
create procedure sp_eliminar(@idcontacto int) as
begin
	delete contacto where IdContacto=@idcontacto

end
go