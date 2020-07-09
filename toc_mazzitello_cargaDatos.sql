use tpc_Mazzitello_mfPrestamos
go
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
--TRIGGER
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
create trigger tr_creacion_cliente on usuario --100%
after insert
as 
begin
	declare @idUsuario bigint
	select @idUsuario= idUsuario from INSERTED

	insert into cliente values(getdate(), 1, @idUsuario, 'apellidoVacio', 'nombreVacio','dni'+cast(@idUsuario as varchar)+'Vacio',
	'sexoVacio','1111-11-11',1, 'domicilioVacio',1, 'telefonoVacio', 'telefonoAuxVacio', 'mailVacio',0, null, 0,0,null,0)
end
go
create trigger tr_eliminar_cliente on usuario -- 100%
after update
as
begin 
	declare @idUsuario bigint
	select @idUsuario= idUsuario from INSERTED

	update cliente set activo=0 where idUsuario=@idUsuario
end
go
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
--CARGA DE DATOS
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
go
insert into tipoUsuario values ('Administrador')
insert into tipoUsuario values ('Cliente')
go
insert into pais values('Argentina')
insert into pais values('Uruguay')
insert into pais values('Paraguay')
insert into pais values('Brasil')
insert into pais values('Perú')
go
insert into provincia values('Buenos Aires',1)
insert into provincia values('Entre Rios',1)
insert into provincia values('Misiones ',1)
insert into provincia values('Mendoza',1)
insert into provincia values('Salta',1)
insert into provincia values('Jujuy',1)
go
insert into ciudad values('San Miguel',1)
insert into ciudad values('Muñiz',1)
insert into ciudad values('Bella Vista',1)
insert into ciudad values('Hurlingham',1)
insert into ciudad values('Caseros',1)
insert into ciudad values('Villa del Parque',1)
go
insert into nacionalidad values('Argentino')
insert into nacionalidad values('Uruguayo')
insert into nacionalidad values('Paraguayo')
insert into nacionalidad values('Brasilero')
insert into nacionalidad values('Peruano')
go
insert into usuario values ('adm', '111', 1,1)
insert into usuario values ('nn', '123456', 1,2)
insert into usuario values ('dantebb', '123456', 1,2)
go
insert into gastosAdm values (500, 1, 'Se abona junto con la primer cuota')
insert into gastosAdm values (1000, 3, 'Se fracciona entre las 3 cuotas')
go
insert into producto values(2,'Celular', 'Samsung', 'Galaxy s7 EDGE', 'Ninguno', 'Nuevo', 0, 'https://www.movilzona.es/app/uploads/2016/02/Samsung-Galaxy-S7-EDGE-comparador.png')
insert into producto values(2, 'Playstation 4', 'Sony', 'PRO', 'Rallada la carcasa, por el uso', 'Usado', 0, 'https://d26lpennugtm8s.cloudfront.net/stores/297/948/products/ps4-pro-1tb-4k-envio-gratis-d_nq_np_686844-mla26607788262_012018-f11-949a33cd2c16dee9ef15244057327716-480-0.jpg')
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
--PROCEDIMIENTOS DE ALMACENADO
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
go
create procedure sp_agregar_usuario --100%
(
	@usuario varchar(30),
	@contra varchar(30),
	@estado bit,
	@idTipoUsuario int
)
as 
begin
	begin transaction
		insert into usuario values(@usuario, @contra, @estado, @idTipoUsuario)
	commit transaction
end
go
create procedure sp_eliminar_usuario --100%
(
	@idUsuario bigint
)
as
begin 
	update usuario set estado=0 where idUsuario=@idUsuario
end
go
create procedure sp_modificar_nombre_usuario --100%
(
	@idUsuario bigint,
	@nombreNuevo varchar(30)
)
as
begin
	update usuario set usuario=@nombreNuevo where idUsuario=@idUsuario
end
go
create procedure sp_modificar_contrasenia_usuario --100%
(
	@idUsuario bigint,
	@contraNueva varchar(30)
)
as
begin
	update usuario set contra=@contraNueva where idUsuario=@idUsuario
end
go
create procedure sp_alta_producto --100%
(
	@idCliente bigint ,
	@producto varchar(30),
	@marca varchar(30),
	@modelo varchar(30),
	@detalles varchar(100),
	@estado varchar(10),
	@imagen varchar(1000),
	@precio money
)
as
begin
	begin transaction
		insert into producto(idCliente, producto, marca, modelo , detalles,estado, imagen, precio) values(@idCliente, @producto, @marca, @modelo, @detalles, @estado, @imagen, @precio)
	commit transaction
end
go
create procedure sp_cargar_producto --100%
(
	@idCliente bigint
)
as
begin
	select idProducto, producto, marca, modelo, detalles, estado, imagen, precio from producto where idCliente=@idCliente
end
go
create procedure sp_traer_producto --100%
(
	@idProducto bigint
)
as 
begin 
	select idProducto, producto, marca, modelo, detalles, estado, imagen, precio from producto where idProducto=@idProducto
end
go
create procedure sp_guardar_cliente --100%
(
	@idUsuario bigint,
	@apellido varchar(30) ,
	@nombre varchar(30),
	@dni varchar(30),
	@sexo varchar(30),
	@fechaNac date ,
	@idNacionalidad int,
	@domicilio varchar(30) ,
	@idCiudad bigint,
	@telefonoPrin varchar(30) ,
	@telefonoAux varchar(30),
	@mail varchar(30) ,
	@trabaja bit,
	@rubro varchar(30),
	@sueldo money,
	@ingresoExtra bit,
	@razonIngExt varchar(30),
	@montoIngExt money
)
as 
begin
	update cliente set apellido= @apellido, nombre=@nombre, dni=@dni, sexo=@sexo, fechaNac=@fechaNac, 
	idNacionalidad=@idNacionalidad, domicilio=@domicilio, idCiudad=@idCiudad,telefonoPrin=@telefonoPrin, 
	telefonoAux=@telefonoAux, mail=@mail, trabaja=@trabaja, rubro=@rubro, sueldo=@sueldo,ingresoExtra=@ingresoExtra,
	razonIngExt=@razonIngExt, montoIngExt=@montoIngExt where idUsuario=@idUsuario
end
go
create procedure sp_agregar_gasto_adm --100%
(
	@monto money ,
	@meses int ,
	@detalles varchar(50)
)
as
begin
	insert into gastosAdm values(@monto, @meses, @detalles)
end
go
create procedure sp_modificar_gasto_adm --100%
(
	@idGastosAdm int,
	@monto money ,
	@meses int ,
	@detalles varchar(50)
)
as
begin
	update gastosAdm set monto=@monto, meses=@meses, detalles=@detalles where idGastosAdm=@idGastosAdm
end
go
create procedure sp_guardar_valor_cuota --100%
(
	@numeroCuota int,
	@idPrestamo bigint,
	@valorCuota money,
	@valorCuotaAtrasada money,
	@valorCuotaVencida money,
	@cuotaEstaAtrasada date,
	@cuotaEstaVencida date
)
as 
begin
	insert into valorCuota values(@numeroCuota, @idPrestamo, @valorCuota, @valorCuotaAtrasada, @valorCuotaVencida, @cuotaEstaAtrasada, 
	@cuotaEstaVencida, null,null)
end
go
create procedure sp_confirmar_pago_cuota --100%
(
	@numeroCuota int,
	@idPrestamo bigint,
	@comprobantePago varchar(500)
)
as
begin
	update valorCuota set fechaPagoCliente= GETDATE(), comprobantePago=@comprobantePago where idPrestamo=@idPrestamo and numeroCuota=@numeroCuota
end
go
create procedure sp_crear_prestamo --100%
(
	@monto money ,
	@cuotas int ,
	@idGastosAdm int ,
	@idProducto bigint
)
as
begin 
	insert into prestamo values(1, GETDATE(), @monto, @cuotas, @idGastosAdm, @idProducto)
end
go
create procedure sp_finalizar_prestamo -- 100%
(
	@idPrestamo bigint
)
as
begin
	update prestamo set estado=0 where idPrestamo=@idPrestamo
end
go
create procedure sp_alta_solicitud -- 100%
(
	@montoSolicitado money,
	@cantidadCuotas int,
	@idProducto bigint
)
as 
begin
	insert into solicitud(fecha, montoSolicitado, cantidadCuotas, estado, idProducto, observacion) values (GETDATE(), @montoSolicitado, 
	@cantidadCuotas, 2, @idProducto, 'nada')
end
go
create procedure sp_rechazo_solicitud --100%
(
	@observacion varchar(200),
	@idSolicitud bigint
)
as
begin
	update solicitud set estado=0, observacion= @observacion where idSolicitud=@idSolicitud
end
go
create procedure sp_cambiar_solicitud_a_aprobada --100%
(
	@idSolicitud bigint 
)
as
begin
	update solicitud set estado=1 where idSolicitud=@idSolicitud
end
-------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------
-- VISTA
-------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------
go
create view vw_listar_solicitudes as
select s.idSolicitud, s.fecha, s.montoSolicitado, s.cantidadCuotas, p.producto, p.marca, p.modelo, p.detalles, p.estado, p.imagen, cl.idCliente, s.estado as 'estatus', s.observacion from solicitud as s 
inner join producto as p on p.idProducto = s.idProducto 
inner join cliente as cl on cl.idCliente = p.idCliente
