--CREATE DATABASE COMERCIO_transacciones
--go
--USE COMERCIO_transacciones
--go

--CREATE TABLE ARTICULOS
--(cod_art int identity(1,1),
--nombre varchar(50),
--pre_unitario decimal(10,2)
--CONSTRAINT pk_articulo PRIMARY KEY (cod_art),
--);

--CREATE TABLE FORMA_PAGOS
--(id_forma_pago int identity(1,1),
--forma_pago varchar(50) NOT NULL,
--recargo decimal(10,2)
--CONSTRAINT pk_forma_pagos PRIMARY KEY (id_forma_pago)
--);

--CREATE TABLE CLIENTES
--(id_cliente int identity(1,1),
--nom_cliente varchar(50),
--ape_cliente varchar(50),
--cuit int,
--calle varchar(50),
--nro_calle int,
--telefono int
--CONSTRAINT pk_cliente PRIMARY KEY (id_cliente)
--);

--CREATE TABLE FACTURAS
--(nro_factura int identity(1,1), 
--fecha datetime,
--cliente int,
--forma_pago int,
--activo bit 
--CONSTRAINT pk_facturas PRIMARY KEY (nro_factura),
--CONSTRAINT fk_factura_cliente FOREIGN KEY (cliente)
--	REFERENCES clientes(id_cliente),
--CONSTRAINT fk_factura_pago FOREIGN KEY (forma_pago)
--	REFERENCES forma_pagos(id_forma_pago)
--);

--CREATE TABLE DETALLES_FACTURAS
--(id_detalle int identity(1,1),
--nro_factura int, 
--articulo int,
--cantidad int,
--pre_venta decimal (10,2)
--CONSTRAINT pk_detalle_factura PRIMARY KEY (id_detalle),
--CONSTRAINT fk_detalles_factura FOREIGN KEY (nro_factura)
--	REFERENCES facturas(nro_factura),
--CONSTRAINT fk_detalles_articulos FOREIGN KEY (articulo)
--	REFERENCES articulos(cod_art)
--);

--INSERTAR ARTÍCULOS
--CREATE PROCEDURE sp_insert_articulos
--				@nombre varchar(50), 
--				@pre_unitario decimal(10,2)
--AS 
--BEGIN
--	INSERT INTO ARTICULOS(nombre, pre_unitario )
--		VALUES	(@nombre, @pre_unitario)
--END;

--ACTUALIZAR ARTÍCULOS
--CREATE PROCEDURE sp_update_articulos
--				@cod_art int,
--				@nombre varchar(50), 
--				@pre_unitario decimal(10,2)
				
--AS 
--BEGIN
--	UPDATE ARTICULOS
--		SET nombre = @nombre, 
--			pre_unitario = @pre_unitario
--		WHERE cod_art = @cod_art
--END;

--BORRAR ARTICULOS
--CREATE PROCEDURE sp_delete_articulos
--				@cod_art int
--AS 
--BEGIN
--	DELETE FROM ARTICULOS
--		WHERE cod_art = @cod_art
--END;

--CONSULTAR TODOS LOS ARTÍCULOS
--CREATE PROCEDURE sp_consult_art
--AS 
--BEGIN
--	SELECT a.cod_art 'COD ARTÍCULO', a.nombre 'NOMBRE', a.pre_unitario 'PRECIO'
--	FROM ARTICULOS a 
--	ORDER BY 2
--END;

--CONSULTAR ARTÍCULOS POR ID
--CREATE PROCEDURE sp_consult_artID
--		@cod_art int
--AS 
--BEGIN
--	SELECT a.cod_art 'COD ARTÍCULO', a.nombre 'NOMBRE', a.pre_unitario 'PRECIO'
--	FROM ARTICULOS a 
--	ORDER BY 2
--END;

--TABLA CLIENTES
--INSERTAR CLIENTE
--CREATE PROCEDURE sp_insert_clientes
--				@nom_cliente varchar(50), 
--				@ape_cliente varchar(50), 
--				@cuit int, 
--				@calle varchar(50), 
--				@nro_calle int,
--				@telefono int
--AS 
--BEGIN
--	INSERT INTO CLIENTES(nom_cliente, ape_cliente, cuit, calle, nro_calle, telefono)
--		VALUES	(@nom_cliente, @ape_cliente, @cuit, @calle, @nro_calle, @telefono)
--END;


--ACTUALIZAR CLIENTE
--CREATE PROCEDURE sp_update_clientes
--				@id_cliente int,
--				@nom_cliente varchar(50), 
--				@ape_cliente varchar(50), 
--				@cuit int, 
--				@calle varchar(50), 
--				@nro_calle int,
--				@telefono int
				
--AS 
--BEGIN
--	UPDATE CLIENTES
--		SET	nom_cliente = @nom_cliente, 
--			ape_cliente = @ape_cliente, 
--			cuit = @cuit, 
--			calle = @calle, 
--			nro_calle = @nro_calle, 
--			telefono = @telefono
--			WHERE id_cliente = @id_cliente
--END;


--BORRAR CLIENTE
--CREATE PROCEDURE sp_delete_clientes
--				@id int
--AS 
--BEGIN
--	DELETE FROM CLIENTES
--		WHERE id_cliente = @id
--END;


--CONSULTAR CLIENTES
--CREATE PROCEDURE sp_Consult_Clientes
--AS
--BEGIN
--SELECT nom_cliente 'NOMBRE', ape_cliente 'APELLIDO', cuit 'CUIT', telefono 'CONTACTO' FROM clientes
--END;


----CONSULTAR CLIENTES POR ID
--CREATE PROCEDURE sp_Consult_ClientesID
--		 @id_cliente int 
--AS 
--BEGIN
--SELECT id_cliente 'id', nom_cliente 'NOMBRE', ape_cliente 'APELLIDO', cuit 'CUIT', telefono 'CONTACTO' FROM clientes
--	WHERE id_cliente = @id_cliente
--END;


--TABLA FORMAS DE PAGO
--CREATE PROCEDURE sp_insert_formaPago
--				@forma_pago varchar(30),
--				@recargo decimal(10,2)
--AS
--BEGIN
--	INSERT INTO FORMA_PAGOS (forma_pago, recargo)
--		VALUES (@forma_pago, @recargo)
--END;

--CREATE PROCEDURE sp_Consult_formaPago
--AS
--BEGIN
--	SELECT *
--		FROM FORMA_PAGOS
--END;


--TABLA FACTURAS
--CREATE PROCEDURE sp_Consult_Facturas
--AS
--BEGIN
--SELECT f.nro_factura, f.fecha, a.nombre, df.cantidad, a.pre_unitario, (df.cantidad*df.pre_venta) 'TOTAL DETALLE'
--	FROM FACTURAS f
--	JOIN DETALLES_FACTURAS df ON f.nro_factura = df.nro_factura
--	JOIN ARTICULOS a ON df.articulo = a.cod_art
--END;


--CREATE PROCEDURE sp_Insert_Factura
--				@idCliente int,
--				@idFormaPago int,
--				@activo bit,
--				@nroFactura int OUTPUT
--AS
--BEGIN
--INSERT INTO FACTURAS (fecha, cliente, forma_pago, activo)
--			VALUES (GETDATE(), @idCliente, @idFormaPago, @activo)
--			SET @nroFactura = SCOPE_IDENTITY();
--END;


--TABLA DETALLES
--CREATE PROCEDURE sp_Insert_Detalles
--					@nroFactura int,
--					@articulo int,
--					@cantidad int,
--					@pre_venta decimal(10,2)
--AS 
--BEGIN
--INSERT INTO DETALLES_FACTURAS (nro_factura,articulo, cantidad, pre_venta)
--				VALUES (@nroFactura, @articulo, @cantidad, @pre_venta)
--END;

