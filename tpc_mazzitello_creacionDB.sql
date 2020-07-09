create database tpc_Mazzitello_mfPrestamos
go 
use tpc_Mazzitello_mfPrestamos
go
create table tipoUsuario
(
	idTipoUsuario int not null identity(1,1) primary key,
	tipoUsuario varchar(15) not null
)
go
create table usuario
(
	idUsuario bigint not null identity(1,1) primary key,
	usuario varchar(30) not null unique,
	contra varchar(30) not null,
	estado bit not null,	--activo/inactivo
	idTipoUsuario int not null foreign key references tipoUsuario(idTipoUsuario)
)
go
create table nacionalidad
(
	idNacionalidad int not null identity(1,1) primary key,
	nacionalidad varchar(30) not null
)
go
create table pais
(
	idPais int not null identity(1,1) primary key,
	pais varchar(30) not null
)
go
create table provincia
(
	idProvincia bigint not null identity(1,1) primary key,
	provincia varchar(30) not null,
	idPais int not null foreign key references pais(idPais)
)
go
create table ciudad
(
	idCiudad bigint not null identity(1,1) primary key,
	ciudad varchar(30) not null,
	idProvincia bigint not null foreign key references provincia(idProvincia)
)
go
create table cliente
(
	idCliente bigint not null identity(1,1) primary key,
	fechaReg date not null,
	activo bit not null, --activo/inactivo, para borrado logico
	idUsuario bigint not null unique foreign key references usuario(idUsuario),
	apellido varchar(30) not null,
	nombre varchar(30) not null,
	dni varchar(30) not null unique,
	sexo varchar(30) not null,
	fechaNac date not null,
	idNacionalidad int not null foreign key references nacionalidad(idNacionalidad),
	domicilio varchar(30) not null,
	idCiudad bigint not null foreign key references ciudad(idCiudad),
	telefonoPrin varchar(30) not null,
	telefonoAux varchar(30) not null,
	mail varchar(30) not null,
	trabaja bit not null, --si trabaja,1
	rubro varchar(30),
	sueldo money,
	ingresoExtra bit not null, --si tiene, 1
	razonIngExt varchar(30),
	montoIngExt money,
)
go
create table producto
(
	idProducto bigint not null identity(1,1) primary key,
	idCliente bigint not null foreign key references cliente(idCliente),
	producto varchar(30) not null,
	marca varchar(30) not null,
	modelo varchar(30) not null,
	detalles varchar(100)not null,
	estado varchar(10) not null,
	precio money not null, --representa el valor al que el adm va a tomar el producto
	imagen varchar(1000)
)
go
create table solicitud
(
	idSolicitud bigint not null identity(1,1) primary key,
	fecha date not null,
	montoSolicitado money not null,
	cantidadCuotas int not null,
	estado int not null,  --si es 0, se rechazo. Si es 1, se aprobo. Si es 2, esta en revision del adm
	idProducto bigint not null foreign key references producto(idProducto),
	observacion varchar(200) --razon por la cual no se entrego el prestamo
)
go
create table gastosAdm
(
	idGastosAdm int not null identity(1,1) primary key,
	monto money not null,
	meses int not null,
	detalles varchar(50) not null
)
go
create table prestamo
(
	idPrestamo bigint not null identity(1,1) primary key,
	estado bit not null, --1 activo, 2 finalizado
	fecha date not null,
	monto money not null,
	cuotas int not null, --cantidad
	idGastosAdm int not null foreign key references gastosAdm(idGastosAdm),
	idProducto bigint not null foreign key references producto(idProducto),
)
go
create table valorCuota
(
	numeroCuota int not null,
	idPrestamo bigint not null foreign key references prestamo(idPrestamo),
	valorCuota money not null,
	valorCuotaAtrasada money not null,
	valorCuotaVencida money not null,
	cuotaEstaAtrasada date not null, --fecha desde que empieza a correr el interes(11 de cada mes)
	cuotaEstaVencida date not null,
	fechaPagoCliente date, --fecha cuando se paga la cuota
	comprobantePago varchar(500)
	primary key (numeroCuota, idPrestamo)
)
go
--insert into valorCuota values (1, 6, 3000, 3900, 4800, '2020-8-8','2020-8-18',null)
--insert into valorCuota values (2, 6, 2500, 3250, 4000, '2020-9-8','2020-9-18',null)
--insert into valorCuota values (3, 6, 2500, 3250, 4000, '2020-10-8','2020-10-18',null)

--select *, datediff(day, val.cuotaEstaAtrasada, p.fecha)as 'diasFaltan' from prestamo as p
--inner join valorCuota as val on val.idPrestamo=p.idPrestamo

--select *, datediff(day, p.fecha, val.cuotaEstaAtrasada)as 'diasFaltan' from prestamo as p
--inner join valorCuota as val on val.idPrestamo=p.idPrestamo

--create table telefonoAux
--(
--	idTelefonoAux bigint not null identity(1,1) primary key,
--	idCliente bigint not null foreign key references cliente(idCliente),
--	telefonoAux varchar(30) not null
--)
--go 
--create table marca
--(
--	idMarca bigint not null identity(1,1) primary key,
--	marca varchar(30) not null
--)
--go

--select fechaPagoCliente from valorCuota 
--where idPrestamo=11 and numerocuota=1
--select vc.fechaPagoCliente from valorCuota as vc
--where idPrestamo=11 and numerocuota=2
--select vc.fechaPagoCliente from valorCuota as vc
--where idPrestamo=11 and numerocuota=3

--select * from prestamo

