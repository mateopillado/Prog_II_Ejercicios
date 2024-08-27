
--create database Almacen
--use Almacen


create table productos(
codigo int identity(1,1),
n_producto varchar(50),
precio float,
stock int,
esta_activo bit
)

--create procedure SP_Recuperar_Productos
--AS
--begin
--	select * from productos
--end

----insert into productos values ('pan', 1000, 20, 1);