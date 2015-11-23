USE [GD2C2015]
GO

--creacion esquema del grupo
if not exists(select * from sys.schemas where name = 'NORMALIZADOS')
execute('CREATE SCHEMA [NORMALIZADOS] AUTHORIZATION [gd]')

else print('No te creo nada')
GO

/**************************************
				ROL
**************************************/

CREATE TABLE [NORMALIZADOS].Rol(
	[Id] numeric(18,0) PRIMARY KEY IDENTITY(0,1),
	[Nombre] nvarchar(255) UNIQUE NOT NULL,
	[Activo] BIT DEFAULT 1 NOT NULL
)
GO

INSERT INTO [NORMALIZADOS].Rol(Nombre)
	VALUES
	('Administrador'),
	('Guest')
GO

/**************************************
			FUNCIONALIDADES
**************************************/

CREATE TABLE [NORMALIZADOS].Funcionalidad(
	[Id] numeric(18,0) PRIMARY KEY IDENTITY(0,1),
	[Descripcion] nvarchar(255) UNIQUE not null
)
GO

INSERT INTO [NORMALIZADOS].Funcionalidad(Descripcion)
	VALUES
	('ABM DE ROL'),
	('ABM DE CIUDADES'),
	('ABM DE RUTA AEREA'),
	('ABM DE AERONAVES'),
	('GENERAR VIAJE'),
	('REGISTRO LLEGADA A DESTINO'),
	('COMPRA PASAJE/ENCOMIENDA'),
	('CANCELAR PASAJE/ENCOMIENDA'),
	('CONSULTA DE MILLAS'),
	('CANJE DE MILLAS'),
	('LISTADO ESTADISTICO')
GO
	
/**************************************
		FUNCIONALIDAD DE CADA ROL
**************************************/

CREATE TABLE [NORMALIZADOS].RolxFuncionalidad(
	[Rol] numeric(18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].Rol(Id) NOT NULL,
	[Funcionalidad] numeric(18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].Funcionalidad(Id) NOT NULL
	PRIMARY KEY(Rol,Funcionalidad)
)
GO

INSERT INTO [NORMALIZADOS].RolxFuncionalidad(Rol,Funcionalidad)
(
	SELECT R.ID,F.ID
	FROM [NORMALIZADOS].Rol R,[NORMALIZADOS].Funcionalidad F
	WHERE R.Nombre='Administrador'
	OR (R.Nombre='Guest' AND (F.Descripcion='COMPRA PASAJE/ENCOMIENDA' OR F.Descripcion='CONSULTA DE MILLAS'
		OR F.Descripcion='CANJE DE MILLAS')
		)
)
GO

/**************************************
				CLIENTES
**************************************/

CREATE TABLE [NORMALIZADOS].Cliente(
	[Id] numeric(18,0) PRIMARY KEY IDENTITY(0,1),
	[Nombre] nvarchar(255) NOT NULL,
	[Apellido] nvarchar(255) NOT NULL,
	[Dni] numeric(18,0) NOT NULL,
	[Telefono] numeric(18,0),
	[Direccion] nvarchar(255) NOT NULL,
	[Fecha_Nac] datetime NOT NULL,
	[Mail] nvarchar(255)
)
GO

INSERT INTO [NORMALIZADOS].[Cliente](Nombre, Apellido, Dni, Fecha_Nac, Direccion, Telefono, Mail)
(
	SELECT  DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni,Cli_Fecha_Nac, Cli_Dir,Cli_Telefono,Cli_Mail
	FROM [gd_esquema].[Maestra]
)
GO
 
/**************************************
				USUARIO
**************************************/

CREATE TABLE [NORMALIZADOS].Usuario(
	[Id] numeric(18,0) PRIMARY KEY IDENTITY(0,1),
	[Username] nvarchar(255) UNIQUE,
	[Rol] numeric(18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].Rol(Id) NOT NULL,
	[Habilitado] BIT DEFAULT 1 NOT NULL,
	[Intentos] numeric(1,0) DEFAULT 0 NOT NULL,
	[SHA256] binary(32),
	[Mail] nvarchar(255) NOT NULL
)
GO

DECLARE @hash binary(32)
SET @hash =  CONVERT(binary(32),'0xe6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',1)
INSERT INTO NORMALIZADOS.Usuario(Username,SHA256,Mail,Rol)
VALUES
	('admin', @hash,'admin@gdd.com',0),
	('Alan', @hash,'alan@gdd.com',0),
	('Gonzalo', @hash,'gonzalo@gdd.com',0),
	('David', @hash,'david@gdd.com',0),
	('Martin', @hash,'martin@gdd.com',0)
GO
/*****************************************
				CIUDAD
******************************************/

CREATE TABLE [NORMALIZADOS].[Ciudad](
	[Id][int] PRIMARY KEY IDENTITY(0,1),
	[Nombre] [nvarchar](255) UNIQUE NOT NULL
)
GO
	
-- Ingreso todas las ciudades que figuran como origen o destino.
-- El unique se va a encargar de no ingresar ciudades repetidas.	
INSERT INTO [NORMALIZADOS].[Ciudad](Nombre)

 SELECT Ruta_Ciudad_Destino FROM gd_esquema.Maestra
 UNION 
 SELECT Ruta_Ciudad_Origen FROM gd_esquema.Maestra
GO

/*****************************************
				SERVICIO
******************************************/
CREATE TABLE [NORMALIZADOS].[Servicio](
	[Id][int] PRIMARY KEY IDENTITY(0,1),
	[Descripcion] [nvarchar](255) UNIQUE NOT NULL,
	[Porcentaje_Adicional] [numeric](3,2) NOT NULL,
	CHECK(Porcentaje_Adicional BETWEEN 0 AND 1) -- Debe ser un valor entre 0 y 100%
) 
GO

INSERT INTO NORMALIZADOS.Servicio(Descripcion, Porcentaje_Adicional)
(	
	SELECT Tipo_Servicio, MAX(Pasaje_Precio/Ruta_Precio_BasePasaje -1)
	FROM [gd_esquema].[Maestra]
	WHERE Ruta_Precio_BasePasaje > 0
	GROUP BY Tipo_Servicio
)
GO

/*****************************************
			   RUTAS AEREAS 
******************************************/

CREATE TABLE [NORMALIZADOS].[#RutasTemporal]
(
	[Id] [numeric](18,0) IDENTITY(0,1) PRIMARY KEY,
	[Ruta_Codigo] [int],
	[Ciudad_Origen]  varchar(250),
	[Ciudad_Destino] varchar(250),
	[Precio_BasePasaje] [numeric](18, 2) NOT NULL,
	[Precio_BaseKG] [numeric](18, 2) NOT NULL,
	[Tipo_Servicio] [nvarchar](255),
	CHECK(Precio_BaseKG >= 0),
	CHECK(Precio_BasePasaje >= 0),
)
GO
INSERT INTO [NORMALIZADOS].#RutasTemporal(Ruta_Codigo,Ciudad_Origen,Ciudad_Destino,Precio_BasePasaje,Precio_BaseKG,Tipo_Servicio)
	SELECT Distinct M.Ruta_Codigo, M.Ruta_Ciudad_Origen, M.Ruta_Ciudad_Destino, M.Ruta_Precio_BasePasaje, M.Ruta_Precio_BaseKG, M.Tipo_Servicio
	FROM gd_esquema.Maestra M
GO
CREATE TABLE [NORMALIZADOS].[Ruta_Aerea]
(
	[Id] [numeric](18,0) IDENTITY(0,1) PRIMARY KEY,
	[Ruta_Codigo] [numeric](18,0),
	[Ciudad_Origen]  [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Ciudad](Id) NOT NULL,
	[Ciudad_Destino] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Ciudad](Id) NOT NULL,
	[Precio_BasePasaje] [numeric](18, 2) NOT NULL,
	[Precio_BaseKG] [numeric](18, 2) NOT NULL,
	[Tipo_Servicio] [numeric](18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].[Servicio](Id) NOT NULL,,
	[Habilitada] [bit] DEFAULT 1,
	UNIQUE(Ciudad_Origen,Ciudad_destino,Tipo_Servicio),
	CHECK(Precio_BaseKG >= 0),
	CHECK(Precio_BasePasaje >= 0),
)
GO
INSERT INTO [NORMALIZADOS].Ruta_Aerea(Ruta_Codigo,Ciudad_Origen,Ciudad_Destino,Precio_BasePasaje,Precio_BaseKG,Tipo_Servicio)
	select R.ruta_codigo, C1.ID, C2.ID, R.precio_basepasaje, R2.precio_basekg, S.ID from normalizados.#RutasTemporal R
	JOIN NORMALIZADOS.Ciudad C1 ON C1.Nombre = R.ciudad_origen
	JOIN NORMALIZADOS.Ciudad C2 ON C2.Nombre = R.ciudad_Destino
	JOIN NORMALIZADOS.Servicio S ON S.Descripcion = R.Tipo_servicio
	JOIN NORMALIZADOS.#RutasTemporal R2 ON R.ruta_codigo = R2.ruta_codigo AND R.ciudad_origen = R2.ciudad_origen AND R.ciudad_destino = R2.ciudad_destino
	where R.precio_basepasaje > 0 AND R2.precio_basekg > 0
GO

/********************************************
					FABRICANTE
*********************************************/	

CREATE TABLE [NORMALIZADOS].[Fabricante](
	[Id] [int] PRIMARY KEY IDENTITY(0,1),
	[Nombre] [nvarchar](255) UNIQUE NOT NULL
)
GO

INSERT INTO [NORMALIZADOS].[Fabricante]([Nombre])
(
	SELECT DISTINCT [Aeronave_Fabricante]
	FROM[gd_esquema].[Maestra]
)
GO

/********************************************
					MODELO
*********************************************/	

CREATE TABLE [NORMALIZADOS].[Modelo](
	[Id] [int] PRIMARY KEY IDENTITY(0,1),
	[Modelo_Desc] [nvarchar](255) UNIQUE NOT NULL
)
GO

INSERT INTO [NORMALIZADOS].[Modelo]([Modelo_Desc])
(
	SELECT DISTINCT [Aeronave_Modelo]
	FROM[gd_esquema].[Maestra]
)
GO
/********************************************
					ESTADO AERONAVE
*********************************************/	
CREATE TABLE [NORMALIZADOS].[Estado_Aeronave](
	[Id] [int] PRIMARY KEY IDENTITY(1,1),
	[Descripcion] [nvarchar](255) NOT NULL
)
GO
INSERT INTO [NORMALIZADOS].[Estado_Aeronave](Descripcion)
	VALUES('Dado de alta'),
			('Fuera de servicio'),
			('Dado de baja por vida util')
GO
/********************************************
					AERONAVES
*********************************************/	

CREATE TABLE [NORMALIZADOS].[Aeronave](
	[Numero][int] PRIMARY KEY IDENTITY(1,1),
	[Matricula] [nvarchar](255) UNIQUE NOT NULL,
	[Fecha_Alta] [datetime],
	[Modelo] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Modelo] (Id) NOT NULL,
	[Fabricante] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Fabricante] (Id) NOT NULL,
	[Fecha_Baja_Definitiva] [datetime],
	[KG_Disponibles] [numeric](18,0) NOT NULL,
	[Tipo_Servicio] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Servicio] (Id) NOT NULL,
	[Estado] [int] DEFAULT 1 FOREIGN KEY REFERENCES [NORMALIZADOS].[Estado_Aeronave](Id)
	)
GO
INSERT INTO [NORMALIZADOS].[Aeronave](
	[Matricula],
	[Modelo],
	[Fabricante],
	[KG_Disponibles], --Total de Kg que puede llevar la Aeronave 
	[Tipo_Servicio]
	)
(
	SELECT DISTINCT A.Aeronave_Matricula, M.Id,F.Id,A.Aeronave_KG_Disponibles,S.Id
	FROM [gd_esquema].[Maestra] A
	JOIN [NORMALIZADOS].[Servicio] S ON A.Tipo_Servicio = S.Descripcion AND A.Pasaje_Codigo > 0
	JOIN [NORMALIZADOS].[Modelo] M ON M.Modelo_Desc = A.Aeronave_Modelo
	JOIN [NORMALIZADOS].[Fabricante] F ON A.Aeronave_Fabricante = F.Nombre
)
GO

/************************************************
					BAJA TEMPORAL AERONAVE
**************************************************/

CREATE TABLE [NORMALIZADOS].[Baja_Temporal_Aeronave](
	[Id] [int] PRIMARY KEY IDENTITY (0,1),
	[Aeronave] [int] FOREIGN KEY REFERENCES NORMALIZADOS.Aeronave(Numero) NOT NULL,
	[Fecha_Fuera_Servicio] [datetime] NOT NULL,
	[Fecha_Vuelta_Al_Servicio] [datetime] NOT NULL,
	)
GO


/************************************************
					VIAJE
**************************************************/

CREATE TABLE [NORMALIZADOS].[#ViajeTemporal](
	[Id] [int] PRIMARY KEY IDENTITY (0,1),
	Fecha_Salida [datetime],
	Fecha_LLegada [datetime],
	Fecha_LLegada_Estimada [datetime],
	Ruta_Codigo [numeric](18,0),
	[Ciudad_Origen] nvarchar(255),
	[Ciudad_Destino] nvarchar(255),
	Aeronave_Matricula nvarchar(255)
	)
GO

INSERT INTO [NORMALIZADOS].[#ViajeTemporal](Fecha_Salida,Fecha_LLegada,Fecha_LLegada_Estimada,Ruta_Codigo,Ciudad_Origen,Ciudad_Destino,Aeronave_Matricula)
	
	SELECT DISTINCT M.FechaSalida,M.FechaLLegada,M.Fecha_LLegada_Estimada,M.Ruta_Codigo,M.Ruta_Ciudad_Origen,M.Ruta_Ciudad_Destino,M.Aeronave_Matricula
	FROM [gd_esquema].[Maestra] M
	
GO

CREATE TABLE [NORMALIZADOS].[Viaje](
	[Id] [int] PRIMARY KEY IDENTITY (0,1),
	[Fecha_Salida] [datetime] NOT NULL,
	[Fecha_Llegada] [datetime],
	[Fecha_Llegada_Estimada] [datetime] NOT NULL,
	[Ruta_Aerea] [numeric](18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].[Ruta_Aerea](Id),
	[Aeronave] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Aeronave] (Numero)
	)
GO

INSERT INTO [NORMALIZADOS].[Viaje](
	[Fecha_Salida],
	[Fecha_Llegada],
	[Fecha_Llegada_Estimada],
	[Ruta_Aerea],
	[Aeronave]
	)
(

	SELECT V.Fecha_Salida,V.Fecha_Llegada,V.Fecha_LLegada_Estimada,R.Id,A.Numero
	FROM [NORMALIZADOS].[#ViajeTemporal] V
	JOIN [NORMALIZADOS].[Aeronave] A ON V.Aeronave_Matricula = A.Matricula
	JOIN [NORMALIZADOS].[Ciudad] C1
	ON C1.Nombre=V.Ciudad_Origen
	JOIN [NORMALIZADOS].[Ciudad] C2
	ON C2.Nombre=V.Ciudad_Destino
	JOIN [NORMALIZADOS].[Ruta_Aerea] R ON  V.Ruta_Codigo = R.Ruta_Codigo AND R.Ciudad_Origen = C1.ID AND R.Ciudad_Destino = C2.ID

)
GO



/******************************************************************
					  TIPO_BUTACA
*******************************************************************/

CREATE TABLE [NORMALIZADOS].[Tipo_Butaca]
(
	[Id] [int] PRIMARY KEY IDENTITY (0,1),
	[Descripcion] [nvarchar](255) NOT NULL
)
GO

INSERT INTO [NORMALIZADOS].[Tipo_Butaca](Descripcion)
(
	SELECT DISTINCT Butaca_Tipo
	FROM [gd_esquema].[Maestra]
)
GO

/*****************************************************************
							BUTACA
******************************************************************/

CREATE TABLE [NORMALIZADOS].[Butaca]
(
	[Id] [int] PRIMARY KEY IDENTITY (0,1),
	[Numero] [numeric](18,0) NOT NULL,
	[Piso] [numeric](18,0) NOT NULL DEFAULT 1,
	[Tipo_Butaca] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Tipo_Butaca] (Id) NOT NULL DEFAULT 0,
	[Aeronave] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Aeronave] (Numero) NOT NULL,
	[Habilitada] [bit] DEFAULT 1
)
GO
	
INSERT INTO [NORMALIZADOS].[Butaca](
	[Numero],
	[Piso],
	[Tipo_Butaca],
	[Aeronave]
	)
(
	SELECT DISTINCT A.Butaca_Nro,A.Butaca_Piso,TB.Id,N.Numero
	FROM [gd_esquema].[Maestra] A
	JOIN [NORMALIZADOS].[Tipo_Butaca] TB ON TB.Descripcion = A.Butaca_Tipo
	JOIN [NORMALIZADOS].[Aeronave] N ON A.Aeronave_Matricula = N.Matricula
	WHERE Pasaje_Codigo > 0
	
)
GO

/*****************************************************************
							TIPO_PAGO
******************************************************************/
CREATE TABLE [NORMALIZADOS].[Tipo_Pago](
	[Id] [int] PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Descripcion] [nvarchar](255) NOT NULL
)
GO
INSERT INTO [NORMALIZADOS].[Tipo_Pago](Descripcion)
	VALUES('Tarjeta de credito'),
	('Efectivo')

GO
/*****************************************************************
							Tipo_Tarjeta
******************************************************************/
CREATE TABLE [NORMALIZADOS].[Tipo_Tarjeta](
	[Id] [int] PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Nombre] [nvarchar](255) NOT NULL
)
GO
/*****************************************************************
							Tarjeta_Credito
******************************************************************/
CREATE TABLE [NORMALIZADOS].[Tarjeta_Credito](
	[Nro] [bigint] PRIMARY KEY,
	[Codigo] INT NOT NULL,
	[Fecha_Vencimiento] INT NOT NULL,
	[Tipo_Tarjeta] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Tipo_Tarjeta](Id)
)
GO
/*****************************************************************
							COMPRA
******************************************************************/

CREATE TABLE [NORMALIZADOS].[Compra](
	[Id] [int] PRIMARY KEY IDENTITY (0,1),
	[PNR] [int],
	[Fecha] [datetime] NOT NULL,
	[Comprador] [numeric](18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].[Cliente] (Id) NOT NULL,
	[Medio_Pago] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Tipo_Pago](Id) NOT NULL,
	[Tarjeta_Credito] [bigint] FOREIGN KEY REFERENCES [NORMALIZADOS].[Tarjeta_Credito](Nro) NULL,
	[Pasaje_Codigo] [numeric](18,0),
	[Paquete_Codigo] [numeric](18,0),
	[Viaje] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Viaje] (Id) NOT NULL
	)
GO
CREATE NONCLUSTERED INDEX ix_compra_paquetecodigo ON [Normalizados].[Compra]([Paquete_Codigo])
GO
CREATE NONCLUSTERED INDEX ix_compra_pasajecodigo ON [Normalizados].[Compra]([Pasaje_Codigo])
/***********************************************
					PASAJE
***********************************************/

CREATE TABLE [NORMALIZADOS].[Pasaje](
	[Id] [int] PRIMARY KEY IDENTITY(0,1),
	[Codigo] [numeric](18,0),
	[Precio]  [numeric](18,2) NOT NULL,
	[Pasajero] [numeric](18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].[Cliente] (Id) NOT NULL,
	[Compra] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Compra] (Id) NOT NULL,
	[Butaca] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Butaca] (Id) NOT NULL
	)
GO

INSERT INTO [NORMALIZADOS].[Compra](
	[Fecha],
	[Comprador],
	[Medio_Pago],
	[Pasaje_Codigo],
	[Viaje]
	)
(
	SELECT DISTINCT M.Pasaje_FechaCompra, CLI.Id, 1, M.Pasaje_Codigo,V.Id -- Pago en efectivo porque no aclara otra cosa..
	FROM gd_esquema.Maestra M
	JOIN [NORMALIZADOS].[Cliente] CLI
	ON CLI.Apellido = M.Cli_Apellido AND CLI.Dni = M.Cli_Dni AND CLI.Nombre = M.Cli_Nombre
	JOIN [NORMALIZADOS].[Aeronave] A
	ON A.Matricula = M.Aeronave_Matricula
	JOIN NORMALIZADOS.Servicio S
	ON S.Descripcion=M.Tipo_Servicio
	JOIN NORMALIZADOS.Ciudad C1
	ON C1.Nombre=M.Ruta_Ciudad_Origen
	JOIN NORMALIZADOS.Ciudad C2
	ON C2.Nombre=M.Ruta_Ciudad_Destino
	JOIN NORMALIZADOS.Ruta_Aerea R
	ON R.Ruta_Codigo=M.Ruta_Codigo
	AND R.Ciudad_Origen=C1.Id
	AND R.Ciudad_Destino=C2.Id
	AND R.Tipo_Servicio=S.Id
	JOIN [NORMALIZADOS].[Viaje] V
	ON V.Aeronave = A.Numero AND V.Fecha_Salida = M.FechaSalida AND V.Ruta_Aerea =R.Id
	WHERE M.Pasaje_Codigo != 0

)
GO

INSERT INTO [NORMALIZADOS].[Pasaje](
	[Codigo],
	[Precio],
	[Pasajero],
	[Compra],
	[Butaca]
	)
(
SELECT M.Pasaje_Codigo, M.Pasaje_Precio, CLI.Id, C.Id, B.Id
FROM gd_esquema.Maestra M
JOIN [NORMALIZADOS].[Cliente] CLI
ON CLI.Apellido = M.Cli_Apellido AND CLI.Dni = M.Cli_Dni AND CLI.Nombre = M.Cli_Nombre
JOIN [NORMALIZADOS].[Compra] C
ON C.Pasaje_Codigo = M.Pasaje_Codigo
JOIN [NORMALIZADOS].[Aeronave] A
ON A.Matricula = M.Aeronave_Matricula
JOIN [NORMALIZADOS].[Butaca] B
ON B.Numero = M.Butaca_Nro AND B.Aeronave = A.Numero
WHERE M.Pasaje_Codigo != 0
)
GO

/***********************************************
					ENCOMIENDA
***********************************************/

CREATE TABLE [NORMALIZADOS].[Encomienda](
	[Id] [int] PRIMARY KEY IDENTITY(0,1),
	[Codigo] [numeric](18,0),
	[Precio]  [numeric](18,2) NOT NULL,
	[Kg] [numeric](18,0) NOT NULL,
	[Cliente] [numeric](18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].[Cliente] (Id) NOT NULL,
	[Compra] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Compra] (Id) NOT NULL,
)
GO

INSERT INTO [NORMALIZADOS].[Compra](
	[Fecha],
	[Comprador],
	[Medio_Pago],
	[Paquete_Codigo],
	[Viaje]
	)
(
SELECT M.Paquete_FechaCompra, CLI.Id, 1, M.Paquete_Codigo,V.Id -- Pago en efectivo porque no aclara otra cosa..
	FROM gd_esquema.Maestra M
	JOIN [NORMALIZADOS].[Cliente] CLI
	ON CLI.Apellido = M.Cli_Apellido AND CLI.Dni = M.Cli_Dni AND CLI.Nombre = M.Cli_Nombre
	JOIN [NORMALIZADOS].[Aeronave] A
	ON A.Matricula = M.Aeronave_Matricula
	JOIN NORMALIZADOS.Servicio S
	ON S.Descripcion=M.Tipo_Servicio
	JOIN NORMALIZADOS.Ciudad C1
	ON C1.Nombre=M.Ruta_Ciudad_Origen
	JOIN NORMALIZADOS.Ciudad C2
	ON C2.Nombre=M.Ruta_Ciudad_Destino
	JOIN NORMALIZADOS.Ruta_Aerea R
	ON R.Ruta_Codigo=M.Ruta_Codigo
	AND R.Ciudad_Origen=C1.Id
	AND R.Ciudad_Destino=C2.Id
	AND R.Tipo_Servicio=S.Id
	JOIN [NORMALIZADOS].[Viaje] V
	ON V.Aeronave = A.Numero AND V.Fecha_Salida = M.FechaSalida AND V.Ruta_Aerea =R.Id
	WHERE M.Paquete_Codigo != 0
)
GO

INSERT INTO [NORMALIZADOS].[Encomienda](
	[Codigo],
	[Precio],
	[Cliente],
	[Compra],
	[Kg]
	)
(
SELECT M.Paquete_Codigo, M.Paquete_Precio, CLI.Id, C.Id, M.Paquete_KG
FROM gd_esquema.Maestra M
JOIN [NORMALIZADOS].[Cliente] CLI
ON CLI.Apellido = M.Cli_Apellido AND CLI.Dni = M.Cli_Dni AND CLI.Nombre = M.Cli_Nombre
JOIN [NORMALIZADOS].[Compra] C
ON C.Paquete_Codigo = M.Paquete_Codigo
JOIN [NORMALIZADOS].[Aeronave] A
ON A.Matricula = M.Aeronave_Matricula
WHERE M.Paquete_Codigo != 0
)
GO

DROP INDEX [NORMALIZADOS].[Compra].ix_compra_pasajecodigo
GO

DROP INDEX [NORMALIZADOS].[Compra].ix_compra_paquetecodigo
GO

ALTER TABLE [NORMALIZADOS].[Compra]
DROP COLUMN Pasaje_Codigo
GO

ALTER TABLE [NORMALIZADOS].[Compra]
DROP COLUMN Paquete_Codigo
GO
DROP TABLE [NORMALIZADOS].[#RutasTemporal]
GO
DROP TABLE [NORMALIZADOS].[#ViajeTemporal]
/*****************************************************************
							DETALLE_CANCELACION
******************************************************************/

CREATE TABLE [NORMALIZADOS].[Detalle_Cancelacion](
	[Id] [int] PRIMARY KEY IDENTITY (0,1),
	[Fecha] [datetime] NOT NULL,
	[Motivo] [nvarchar](255)
	)
GO

/***********************************************
				PASAJES CANCELADOS
***********************************************/
CREATE TABLE [NORMALIZADOS].[Pasajes_Cancelados](
	[Id] [int] PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Pasaje] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].Pasaje(Id) NOT NULL,
	[Cancelacion] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].Detalle_Cancelacion(Id) NOT NULL
)
GO
/***********************************************
			ENCOMIENDAS CANCELADAS
***********************************************/
CREATE TABLE [NORMALIZADOS].[Encomiendas_Canceladas](
	[Id] [int] PRIMARY KEY IDENTITY(0,1) NOT NULL,
	[Encomienda] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].Encomienda(Id) NOT NULL,
	[Cancelacion] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].Detalle_Cancelacion(Id) NOT NULL
)
GO

	
/******************************************************************
					  RECOMPENSAS
*******************************************************************/

CREATE TABLE [NORMALIZADOS].[Recompensa](
		[Id][int] PRIMARY KEY IDENTITY(0,1),
		[Descripcion][nvarchar](255) UNIQUE NOT NULL,
		[Puntos][int],
		[Stock] [int],
		CHECK (Stock>-1)
)
GO

INSERT INTO NORMALIZADOS.Recompensa(Descripcion, Puntos,Stock)
	VALUES 
		('Control remoto Selfie',70,1500),
		('Billetera',450,500),
		('Brujula',1000,10),
		('Audifonos',500,100),
		('Notebook Sony Vaio i5 4GB RAM',10000,1),
		('Planchita para el pelo', 700,430),
		('Plancha',800,50),
		('Juego de sillones',20000,2)
GO

/******************************************************************
					  CANJES
*******************************************************************/

CREATE TABLE [NORMALIZADOS].[Canje](
		[Id][int] PRIMARY KEY IDENTITY(0,1),
		[Cliente][numeric](18,0) FOREIGN KEY REFERENCES [NORMALIZADOS].[Cliente](Id) NOT NULL,
		[Recompensa] [int] FOREIGN KEY REFERENCES [NORMALIZADOS].[Recompensa](Id) NOT NULL,
		[Cantidad][int] NOT NULL,
		[Fecha][Datetime] NOT NULL, 
		CHECK(Cantidad>0)
)
GO


/******************************************************************
			STORED PROCEDURES, TRIGGERS Y FUNCTIONS
*******************************************************************/

------------------------------------------------------------------
--             STORED PROCEDURE PARA LOGIN 
------------------------------------------------------------------
-- Incrementa o resetea la cantidad de intentos fallidos
--        y deshabilita la cuenta si supero los 3.
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[LOGIN](@Username nvarchar(255),@SHA256 binary(32)) 
AS
	DECLARE @U_name nvarchar(255)
	DECLARE @Id int
	DECLARE @U_SHA256  binary(32)
	DECLARE @U_habilitado bit
	DECLARE @Cant_intentos int
	--Busqueda de usuario
	SELECT @Id=Id,@U_name=Username,@U_SHA256=SHA256,@U_habilitado=Habilitado,@Cant_intentos=Intentos
	FROM [NORMALIZADOS].Usuario
	WHERE Username=@Username
	
	IF @U_name IS NULL BEGIN
		raiserror('No existe ningun usuario con ese username.', 11, 1)
		RETURN -1 
	END
	-- 
	IF @U_habilitado=0 BEGIN
		raiserror('El usuario se encuentra desahabilitado',16,1)
		RETURN -2
	END
	--Caso de contrasenia incorrecta
	IF @U_SHA256<>@SHA256 BEGIN
		SET @Cant_intentos=@Cant_intentos+1
		IF  @Cant_intentos=3 BEGIN	--Si el usuario llega al max de intentos
			SET @U_habilitado=0		--queda deshabilitado
			SET @Cant_intentos=0 
		END
		UPDATE [NORMALIZADOS].Usuario
		SET Intentos=@Cant_intentos,Habilitado=@U_habilitado
		WHERE Username=@Username
		raiserror('Contrasenia incorrecta',16,1)
		RETURN -3 
	END
	
	IF @U_SHA256=@SHA256 BEGIN
		UPDATE [NORMALIZADOS].Usuario
		SET Intentos=0
		WHERE Username=@Username
		RETURN @Id
	END
	
GO

------------------------------------------------------------------
--            FUNCIONES PARA PUNTOS
------------------------------------------------------------------

CREATE FUNCTION NORMALIZADOS.Puntos_Generados(@Precio numeric(18,2))
RETURNS int
AS BEGIN
	RETURN FLOOR(@Precio/10) -- Cada diez pesos 1 punto.
	END
GO

--Funcion para obtener los puntos de un cliente particular hasta una fecha determinada. 
CREATE FUNCTION NORMALIZADOS.Puntos_a_la_Fecha(@Cliente numeric(18,0), @Fecha datetime)
RETURNS int
AS 
BEGIN
	DECLARE @Total int
	SELECT @Total = ISNULL(SUM(P.Puntos),0) --Si es nulo le damos el valor 0.
		FROM
		(
			SELECT P.Cliente AS Cliente, ISNULL(NORMALIZADOS.Puntos_Generados(P.Precio),0) AS Puntos  
					FROM NORMALIZADOS.Pasaje P
					JOIN NORMALIZADOS.Viaje V ON 
						P.Cliente = @Cliente --Es del cliente
						AND P.Cancelacion IS NULL  --No fue cancelado
						AND P.Viaje = V.Id
						AND V.Fecha_Llegada IS NOT NULL --La llegada del viaje fue registrada 
						AND V.Fecha_Llegada <= @Fecha --El viaje se realizó antes de la fecha
						AND DATEDIFF(DAY, V.Fecha_Llegada, @Fecha)<365 --No está vencido
			UNION ALL
					SELECT E.Cliente, ISNULL(NORMALIZADOS.Puntos_Generados(E.Precio),0)
					FROM NORMALIZADOS.Encomienda E 
					JOIN NORMALIZADOS.Viaje V ON 
						E.Cliente = @Cliente --Es del cliente
						AND E.Cancelacion IS NULL  --No fue cancelado
						AND E.Viaje = V.Id
						AND V.Fecha_Llegada IS NOT NULL --La llegada del viaje fue registrada 
						AND V.Fecha_Llegada <= @Fecha --El viaje ya se realizó 
						AND DATEDIFF(DAY, V.Fecha_Llegada, @Fecha)<365 --No esta vencido
			) P
		
	RETURN @Total

END
GO

--Devuelve una tabla con los detalles de todos los puntos (disponibles, canjeados y vencidos)
CREATE FUNCTION [NORMALIZADOS].[Listado_Puntos](@Cliente numeric(18,0))
RETURNS @Listado TABLE
	 (Descripcion nvarchar(255), Puntos int, Fecha datetime)

AS

BEGIN
	
		INSERT INTO @Listado
	
				 SELECT ('Pasaje ' + CONVERT(char(18),P.Codigo)) AS Descripcion,NORMALIZADOS.Puntos_Generados(P.Precio) AS Cantidad,  C.Fecha AS Fecha
					FROM NORMALIZADOS.Pasaje P 
					JOIN NORMALIZADOS.Viaje V ON 
						P.Viaje = V.Id
						AND P.Cliente = @Cliente 
						AND P.Cancelacion IS NULL --El vuelo no fue cancelado
						AND NORMALIZADOS.Puntos_Generados(P.Precio) > 0
						AND V.Fecha_Llegada IS NOT NULL	-- El enunciado explicita que solo es si los vuelos se concretaron					
					JOIN NORMALIZADOS.Compra C	ON C.PNR = P.Compra						
					
						
				 UNION 
				 
					SELECT ('Encomienda ' + CONVERT(char(18),E.Codigo)) AS Descripcion, NORMALIZADOS.Puntos_Generados(E.Precio) AS Cantidad, C.Fecha AS Fecha
					FROM NORMALIZADOS.Encomienda E 
					JOIN NORMALIZADOS.Viaje V ON
						E.Viaje = V.Id
						AND E.Cliente = @Cliente 
						AND E.Cancelacion IS NULL 
						AND NORMALIZADOS.Puntos_Generados(E.Precio) > 0 
						AND V.Fecha_Llegada IS NOT NULL	
					JOIN NORMALIZADOS.Compra C ON C.PNR = E.Compra
						
				 UNION 
				 
					SELECT (R.Descripcion+'('+CONVERT(nvarchar(11),Ca.Cantidad)+')') AS Descripcion, Ca.Cantidad*R.Puntos*-1 AS Cantidad, Ca.Fecha AS Fecha
						FROM NORMALIZADOS.Canje Ca 
						JOIN NORMALIZADOS.Recompensa R ON Ca.Cliente = @Cliente AND R.Id = Ca.Recompensa
						
				 ORDER BY Fecha DESC

	RETURN

END
GO 

------------------------------------------------------------------
--            TRIGGER QUE DESCUENTA STOCK Y PUNTOS
------------------------------------------------------------------

CREATE TRIGGER NORMALIZADOS.PERSISTIR_STOCK_PUNTOS  ON [NORMALIZADOS].[Canje]
INSTEAD OF INSERT
AS
BEGIN
	
	DECLARE @Cliente numeric(18,0)
	DECLARE @Recompensa int
	DECLARE @Cantidad int
	DECLARE @Puntos int
	DECLARE @Puntos_Usados int
	DECLARE @Stock int
	DECLARE @Costo int
	DECLARE @Fecha datetime
	DECLARE @FechaCompra datetime
	DECLARE @Canjeados TABLE(Tipo bit, PasajeEncomienda int, Cantidad int)
	DECLARE @Contador_Transact int;
    SET @Contador_Transact = @@TRANCOUNT;
		
	

	SET NOCOUNT ON
	
	BEGIN TRY
		
		IF @Contador_Transact = 0 BEGIN TRANSACTION
		ELSE SAVE TRANSACTION SP
			
		IF (SELECT COUNT(*) FROM inserted)> 1 
		  raiserror('Inserte los canjes de uno en uno.', 16, 1)
		
			
		--Obtengo registro insertado
		SELECT @Cliente = Cliente, @Recompensa = Recompensa, @Cantidad = Cantidad, @Fecha = Fecha
			FROM Inserted
			
		--Obtengo datos de la recompensa
		SELECT @Stock = Stock, @Costo=Puntos FROM NORMALIZADOS.Recompensa WHERE Id = @Recompensa
		
				
					 
		--Actualizo stock
		IF @Stock < @Cantidad
			 raiserror('Stock insuficiente.', 16, 1)
				
		SET @Stock =  @Stock - @Cantidad
		UPDATE NORMALIZADOS.Recompensa SET Stock=@Stock WHERE Id = @Recompensa		
		
				
		--Calculo puntos a usar.
		SET @Puntos_Usados = @Costo*@Cantidad
			
		--Creo un cursor para poder recorrer los puntos del cliente.
		DECLARE Puntos CURSOR FOR 
			SELECT P.Id, NORMALIZADOS.Puntos_Generados(P.Precio) AS Restantes, V.Fecha_Llegada AS Fecha
			FROM NORMALIZADOS.Pasaje P
			JOIN NORMALIZADOS.Viaje V ON P.Cliente=@Cliente AND P.Cancelacion IS NULL AND P.Viaje = V.Id AND V.Fecha_Llegada IS NOT NULL AND DATEDIFF(DAY, V.Fecha_Llegada, @Fecha)<365
			GROUP BY P.Id, P.Precio, V.Fecha_Llegada
			ORDER BY Fecha
	    
		
		OPEN Puntos
		
		DECLARE @IdPasajeEncomienda int 
	
		DECLARE @Restantes int --Puntos que le quedan al cliente
		
		
		--Obtengo primer registro de puntos
		FETCH NEXT FROM Puntos
		INTO @IdPasajeEncomienda, @Restantes, @FechaCompra


		WHILE @@FETCH_STATUS = 0 AND @Puntos_Usados>0 --Mientras haya registros y los puntos que use no hayan sido quitados
		BEGIN

			--Si con los puntos actuales es suficiente, los quito y actualizo
			IF @Restantes > @Puntos_Usados
			BEGIN			
				INSERT INTO @Canjeados(PasajeEncomienda,Cantidad) VALUES(@IdPasajeEncomienda, @Puntos_Usados)
				SET @Puntos_Usados = 0
				BREAK			
			END
		
			--Si no fuesen suficientes, los marco como canjeados y sigo con el proximo.
			SET @Puntos_Usados = @Puntos_Usados - @Restantes
			INSERT INTO @Canjeados(PasajeEncomienda,Cantidad) VALUES(@IdPasajeEncomienda, @Restantes)
				
			
			FETCH NEXT FROM Puntos
			INTO @IdPasajeEncomienda, @Restantes, @FechaCompra
		
		END
		
		--Cierro y libero el cursor
		CLOSE Puntos
		DEALLOCATE Puntos
		
		IF @Puntos_Usados > 0 
			raiserror('Puntos insuficientes.', 16, 1)
		
		--Creo el canje del producto y le seteo los puntos canjeados.
		INSERT INTO NORMALIZADOS.Canje(Cliente,Recompensa,Cantidad,Fecha)
			VALUES(@Cliente, @Recompensa, @Cantidad, @Fecha)
		
		
		IF @Contador_Transact = 0 COMMIT TRAN 
	END TRY
	
	BEGIN CATCH 
		--Rollback y muestro el error.
		
		DECLARE @ErrorMessage nvarchar(4000)
		DECLARE @ErrorSeverity int
		DECLARE @ErrorState int
		DECLARE @xstate int
		
		SELECT 
			@ErrorMessage = ERROR_MESSAGE(),
			@ErrorSeverity = ERROR_SEVERITY(),
			@ErrorState = ERROR_STATE(),
		    @xstate = XACT_STATE();
		    
        IF @xstate = -1
            ROLLBACK;
        IF @xstate = 1 and @Contador_Transact = 0
            ROLLBACK
        IF @xstate = 1 and @Contador_Transact > 0
            ROLLBACK TRANSACTION usp_my_procedure_name;
		
		RAISERROR (@ErrorMessage, 
				   @ErrorSeverity, 
				   @ErrorState 
				   );
		
	END CATCH   
END
GO

------------------------------------------------------------------
-- Las llegadas se registran durante el día pero se ingresan al
-- sistema todas juntas.
------------------------------------------------------------------
CREATE TYPE [NORMALIZADOS].[Tipo_Arrivos] AS TABLE
(
	Aeronave int,
	FechaArrivo datetime	
)
GO

CREATE PROCEDURE [NORMALIZADOS].[Registrar_Arrivos] (@Arrivos [NORMALIZADOS].[Tipo_Arrivos] READONLY) 
AS
BEGIN
	DECLARE @Aeronave int
	DECLARE @FechaArrivo datetime
	DECLARE Arrivos_Cursor CURSOR FOR SELECT * FROM @Arrivos
	DECLARE @Viaje int
	
	OPEN Arrivos_Cursor
	
	FETCH NEXT FROM Arrivos INTO @Aeronave, @FechaArrivo

	WHILE @@FETCH_STATUS = 0 
	BEGIN

		--Obtengo el viaje de la aeronave.
		SELECT TOP 1 @Viaje= Id FROM NORMALIZADOS.Viaje 
		WHERE Fecha_Salida < @FechaArrivo --La aeronave ya partió.
			 AND Fecha_Llegada IS NULL --Aun no se registró un arrivó. 
			 AND Aeronave=@Aeronave --Era la aeronave que arrivó.
		ORDER BY Fecha_Salida
	
		--Registro el arrivo.
		UPDATE NORMALIZADOS.Viaje SET Fecha_Llegada=@FechaArrivo WHERE Id=@Viaje
		
		FETCH NEXT FROM Arrivos_Cursor INTO @Aeronave, @FechaArrivo
		
	END
	
	CLOSE Arrivos_Cursor
	DEALLOCATE Arrivos_Cursor
END
GO

------------------------------------------------------------------
--                       ESTADISTICAS                           --
------------------------------------------------------------------
CREATE FUNCTION NORMALIZADOS.TOP5_Destinos_Con_Mas_Pasajes(@Desde datetime, @Hasta datetime)
RETURNS @Top5 TABLE (Ciudad nvarchar(255), [Pasajes vendidos] int)
AS
BEGIN
	INSERT INTO @Top5 
		SELECT TOP 5 C.Nombre AS Ciudad, 
			COUNT(*) AS Pasajes FROM NORMALIZADOS.Ciudad C 
			JOIN NORMALIZADOS.Ruta_Aerea R ON R.Ciudad_Destino = C.Id 
			JOIN NORMALIZADOS.Viaje V ON V.Ruta_Aerea = R.Id 
			JOIN NORMALIZADOS.Pasaje P ON P.Viaje=V.Id AND P.Cancelacion IS NULL 
			JOIN NORMALIZADOS.Compra Com ON Com.PNR = P.Compra 
			AND Com.Fecha BETWEEN @Desde AND @Hasta
			 GROUP BY C.Nombre ORDER BY Pasajes DESC
			 
	RETURN
END
GO


CREATE FUNCTION NORMALIZADOS.TOP5_Destinos_Pasajes_Cancelados(@Desde datetime, @Hasta datetime)
RETURNS @Top5 TABLE (Ciudad nvarchar(255), [Cantidad de pasajes cancelados] int)
AS
BEGIN
	INSERT INTO @Top5
		SELECT TOP 5 C.Nombre AS Ciudad, 
			COUNT(*) AS Pasajes FROM NORMALIZADOS.Ciudad C 
			JOIN NORMALIZADOS.Ruta_Aerea R ON R.Ciudad_Destino = C.Id 
			JOIN NORMALIZADOS.Viaje V ON V.Ruta_Aerea = R.Id 
			JOIN NORMALIZADOS.Pasaje P ON P.Viaje=V.Id AND P.Cancelacion IS NOT NULL 
			JOIN NORMALIZADOS.Compra Com ON Com.PNR = P.Compra 
			AND Com.Fecha BETWEEN @Desde AND @Hasta
			 GROUP BY C.Nombre ORDER BY Pasajes DESC
			 
	RETURN
END
GO

CREATE FUNCTION NORMALIZADOS.TOP5_Aeronaves_Dias_Fuera_De_Servicio(@Desde datetime, @Hasta datetime)
RETURNS @Top5 TABLE (Matricula nvarchar(255), Numero int, [Dias fuera de servicio] int)
AS
BEGIN
	INSERT INTO @Top5 
		SELECT TOP 5 N.Matricula, N.Numero, 
		SUM(
			DATEDIFF(DAY,
				CASE WHEN(B.Fecha_Fuera_Servicio < @Desde) THEN @Desde ELSE B.Fecha_Fuera_Servicio END,
				CASE WHEN(B.Fecha_Vuelta_Al_Servicio > @Hasta) THEN @Hasta ELSE B.Fecha_Vuelta_Al_Servicio END 
				
			 )
			 ) AS Dias
		FROM NORMALIZADOS.Aeronave N
		JOIN NORMALIZADOS.Baja_Temporal_Aeronave B 
			ON B.Aeronave = N.Id
			AND NOT (B.Fecha_Fuera_Servicio > @Hasta)
			AND NOT (B.Fecha_Vuelta_Al_Servicio < @Desde)
		GROUP BY N.Matricula, N.Numero
		ORDER BY Dias DESC
	
	RETURN
END
GO

CREATE FUNCTION NORMALIZADOS.TOP5_Clientes_Puntos_Generados(@Desde datetime, @Hasta datetime)
RETURNS @Top5 TABLE (Dni numeric(18,0), Apellido nvarchar(255), Nombre nvarchar(255), Puntos int)
AS
BEGIN
	INSERT INTO @Top5 
	
		SELECT TOP 5 C.Dni, C.Apellido, C.Nombre, ISNULL(SUM(P.Puntos),0) AS TotalPuntos
		FROM
			(
			SELECT P.Cliente AS Cliente, ISNULL(NORMALIZADOS.Puntos_Generados(P.Precio),0) AS Puntos  
					FROM NORMALIZADOS.Pasaje P
					JOIN NORMALIZADOS.Viaje V ON 
						P.Cancelacion IS NULL
						AND P.Viaje = V.Id
						AND V.Fecha_Llegada IS NOT NULL
						AND V.Fecha_Llegada BETWEEN @Desde AND @Hasta
						
			UNION ALL
					SELECT E.Cliente, ISNULL(NORMALIZADOS.Puntos_Generados(E.Precio),0)
					FROM NORMALIZADOS.Encomienda E 
					JOIN NORMALIZADOS.Viaje V ON  
						E.Cancelacion IS NULL  
						AND E.Viaje = V.Id						
						AND V.Fecha_Llegada IS NOT NULL
						AND V.Fecha_Llegada BETWEEN @Desde AND @Hasta

			) P
		JOIN NORMALIZADOS.Cliente C ON C.Id = P.Cliente
		GROUP BY C.Dni, C.Apellido, C.Nombre
		ORDER BY TotalPuntos DESC					
	RETURN
END
GO

CREATE FUNCTION NORMALIZADOS.TOP5_Clientes_Puntos_a_la_Fecha(@Fecha datetime) 
RETURNS @Top5 TABLE (Dni numeric(18,0), Apellido nvarchar(255), Nombre nvarchar(255), Puntos int)
AS
BEGIN

	INSERT INTO @Top5 
	
		SELECT TOP 5 C.Dni, C.Apellido, C.Nombre, ISNULL(SUM(P.Puntos),0) AS TotalPuntos
		FROM
			(
			SELECT P.Cliente AS Cliente, ISNULL(NORMALIZADOS.Puntos_Generados(P.Precio),0) AS Puntos  
					FROM NORMALIZADOS.Pasaje P
					JOIN NORMALIZADOS.Viaje V ON 
						P.Cancelacion IS NULL
						AND P.Viaje = V.Id
						AND  V.Fecha_Llegada IS NOT NULL AND V.Fecha_Llegada <= @Fecha
						AND DATEDIFF(DAY, V.Fecha_Llegada, @Fecha)<365 --No venció
			UNION ALL
					SELECT E.Cliente, ISNULL(NORMALIZADOS.Puntos_Generados(E.Precio),0)
					FROM NORMALIZADOS.Encomienda E 
					JOIN NORMALIZADOS.Viaje V ON  
						E.Cancelacion IS NULL  
						AND E.Viaje = V.Id
						AND  V.Fecha_Llegada IS NOT NULL AND V.Fecha_Llegada <= @Fecha 
						AND DATEDIFF(DAY, V.Fecha_Llegada, @Fecha)<365 --No venció
			) P
		JOIN NORMALIZADOS.Cliente C ON C.Id = P.Cliente
		GROUP BY C.Dni, C.Apellido, C.Nombre
		ORDER BY TotalPuntos DESC
		
	RETURN

END
GO	
		
CREATE FUNCTION NORMALIZADOS.TOP5_Destinos_Con_Aeronaves_Mas_Vacias(@Desde datetime, @Hasta datetime)
RETURNS @Top5 TABLE (Ciudad nvarchar(255), [Porcentaje promedio de butacas libres] int)
AS
BEGIN
	INSERT INTO @Top5 
		SELECT TOP 5 C.Nombre, FLOOR(AVG((T.Butacas-T.Ocupadas)/T.Butacas)*100) AS Porcentaje_Libre
		FROM(
			SELECT M.Cantidad_Butacas AS Butacas, COUNT(*) AS Ocupadas, V.Ruta_Aerea AS Ruta_Aerea
			FROM NORMALIZADOS.Viaje V 
			JOIN NORMALIZADOS.Aeronave M ON V.Aeronave = M.Id AND V.Fecha_Salida BETWEEN @Desde AND @Hasta
			JOIN NORMALIZADOS.Pasaje P ON P.Cancelacion IS NULL AND P.Viaje = V.Id
			GROUP BY M.Id, V.Id, V.Ruta_Aerea, M.Cantidad_Butacas
		)T
		JOIN NORMALIZADOS.Ruta_Aerea R ON T.Ruta_Aerea = R.Id 
		JOIN NORMALIZADOS.Ciudad C ON R.Ciudad_Destino = C.Id
		GROUP BY C.Nombre
		ORDER BY Porcentaje_Libre DESC
	RETURN
END
GO

------------------------------------------------------------------
--                 FUNCIONES PARA COMPRAS                       --
------------------------------------------------------------------

CREATE FUNCTION NORMALIZADOS.Butacas_Sin_Usar(@idViaje int)
RETURNS numeric(18,0)
AS 
BEGIN
	DECLARE @ButacasSinPasaje numeric(18,0)
	DECLARE @ButacasSinUsar numeric(18,0)
		SELECT @ButacasSinPasaje = ISNULL(N.Cantidad_Butacas,0) - ISNULL(COUNT(P.Id),0)
				FROM NORMALIZADOS.Viaje V
				LEFT JOIN NORMALIZADOS.Pasaje P ON P.Viaje = V.Id
				LEFT JOIN NORMALIZADOS.Aeronave N ON N.Id = V.Aeronave
				WHERE V.Id = @idViaje
				GROUP BY N.Cantidad_Butacas
	
		SELECT @ButacasSinUSar = @ButacasSinPasaje - ISNULL(COUNT(BR.Butaca),0)
				FROM NORMALIZADOS.Butaca_Reservada BR WHERE BR.Viaje = @idViaje
	
	RETURN @ButacasSinUsar
END
GO


CREATE FUNCTION NORMALIZADOS.Kgs_Sin_Usar(@idViaje int)
RETURNS numeric(18,0)
AS 
BEGIN
	DECLARE @KgsSinEncomienda numeric (18,0)
	DECLARE @KgsSinUsar numeric (18,0)
		SELECT @KgsSinEncomienda = ISNULL(N.KG_Disponibles, 0) - ISNULL(SUM(E.Kg),0)
			FROM NORMALIZADOS.Viaje V
			LEFT JOIN NORMALIZADOS.Encomienda E ON E.Viaje = V.Id AND E.Cancelacion IS NULL
			LEFT JOIN NORMALIZADOS.Aeronave N ON N.Id = V.Aeronave
			WHERE V.Id = @idViaje
			GROUP BY N.KG_Disponibles
			
		SELECT @KgsSinUsar =  @KgsSinEncomienda - ISNULL(SUM(KU.Kg),0)
			FROM NORMALIZADOS.Kgs_Usados KU WHERE KU.Viaje = @idViaje
			
	RETURN @KgsSinUsar
END
GO

--------------------------------------------------------------------------------
-- FUNCION QUE BUSCA AERONAVES DISPONIBLES
--------------------------------------------------------------------------------

CREATE FUNCTION NORMALIZADOS.Aeronaves_Disponibles(@Fecha datetime)
RETURNS @Aeronaves_Disponibles TABLE(
	[Id][int], 
	[Matricula] [nvarchar](255),
	[Numero] [int],	
	[Fecha_Alta] [datetime], 
	[Modelo] [nvarchar](255), 
	[Fabricante] [int],
	[Fecha_Baja_Definitiva] [datetime],
	[Cantidad_Butacas] [numeric](18,0),
	[KG_Disponibles] [numeric](18,0),
	[Tipo_Servicio] [int]
	)	
AS 
BEGIN
DECLARE @Arrivo datetime
SET @Arrivo = DATEADD(HOUR, 24, @Fecha)

	INSERT INTO @Aeronaves_Disponibles
		SELECT DISTINCT A.Id, A.Matricula, A.Numero, A.Fecha_Alta, A.Modelo, A.Fabricante, A.Fecha_Baja_Definitiva, A.Cantidad_Butacas, A.KG_Disponibles, A.Tipo_Servicio FROM NORMALIZADOS.Aeronave A
		LEFT JOIN NORMALIZADOS.Baja_Temporal_Aeronave B ON  B.Aeronave = A.Id AND NOT (@Arrivo < B.Fecha_Fuera_Servicio OR @Fecha > B.Fecha_Vuelta_Al_Servicio)
		WHERE B.Id IS NULL AND A.Fecha_Baja_Definitiva IS NULL
		
	RETURN
END
GO

--------------------------------------------------------------------------------
--			FUNCION QUE BUSCA AERONAVES DISPONIBLES PARA UN VIAJE
--------------------------------------------------------------------------------

CREATE FUNCTION NORMALIZADOS.Aeronaves_Para_Viaje(@Origen int, @Destino int, @Fecha datetime)
RETURNS @Aeronaves TABLE(
	[Id][int], 
	[Matricula] [nvarchar](255),
	[Numero] [int],	
	[Fecha_Alta] [datetime], 
	[Modelo] [nvarchar](255), 
	[Fabricante] [int],
	[Fecha_Baja_Definitiva] [datetime],
	[Cantidad_Butacas] [numeric](18,0),
	[KG_Disponibles] [numeric](18,0),
	[Tipo_Servicio] [int]
	)
AS 
BEGIN
	
	INSERT INTO @Aeronaves
	SELECT A.Id, A.Matricula, A.Numero, A.Fecha_Alta, A.Modelo, A.Fabricante, A.Fecha_Baja_Definitiva, A.Cantidad_Butacas, A.KG_Disponibles, A.Tipo_Servicio FROM NORMALIZADOS.Aeronaves_Disponibles(@Fecha) A
              JOIN NORMALIZADOS.Ruta_Aerea R ON R.Tipo_Servicio = A.Tipo_Servicio 
              AND R.Ciudad_Origen = @Origen AND R.Ciudad_Destino = @Destino
              WHERE NOT EXISTS(
                  
                   SELECT V.Id FROM NORMALIZADOS.Viaje V
                   JOIN NORMALIZADOS.Ruta_Aerea R2 ON V.Ruta_Aerea = R2.Id AND V.Aeronave=A.Id
                   AND R2.Ciudad_Origen = @Origen AND R2.Ciudad_Destino = @Destino
                   WHERE
                     ( ABS (DATEDIFF(hour, V.Fecha_Salida, @Fecha))<24) --Hay menos de 24 horas entre los dos viajes
                     OR (V.Fecha_Salida < @Fecha AND R2.Ciudad_Destino!=@Origen AND DATEDIFF(hour, V.Fecha_Salida, @Fecha)<48 ) --O el viaje anterior tiene una ciudad de destino distinta al origen y hay menos de 24hs para que se traslade la aeronave (luego de las 24hs del viaje anterior)
                     OR (V.Fecha_Salida > @Fecha AND R2.Ciudad_Origen!=@Destino AND DATEDIFF(hour, @Fecha, V.Fecha_Salida)<48 ) --O el viaje siguiente tiene un origen diferente al destino y hay menos de 24 y hay menos de 24hs para que se traslade la aeronave (luego de las 24hs del viaje nuevo)
			

			)

	RETURN
END

GO
--------------------------------------------------------------------------------
--				SP habilita a todos los usuarios
--------------------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[SP_Reset_Estado_Users]
AS
	UPDATE [NORMALIZADOS].Usuario 
	SET	Habilitado =1,Intentos =0

GO

--------------------------------------------------------------------------------
--				SP Rol
--------------------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[SP_Baja_Rol]
(@Rol int)
AS
	UPDATE [NORMALIZADOS].[Rol] 
	SET	Activo =0
	WHERE Id = @Rol

GO

--------------------------------------------------------------------------------
--				SP Aeronaves
--------------------------------------------------------------------------------

CREATE PROCEDURE [NORMALIZADOS].[SP_Alta_Aeronave](@Matricula nvarchar(255), @Modelo nvarchar(255), @Kg_Disponibles numeric(18,0), 
@Fabricante int, @Tipo_Servicio int, @Fecha_Alta datetime, @Id int OUTPUT)
AS BEGIN
	INSERT INTO [NORMALIZADOS].[Aeronave](Matricula, Modelo, KG_Disponibles, Fabricante, Tipo_Servicio, Fecha_Alta)
	VALUES (UPPER(@Matricula), UPPER(@Modelo), @Kg_Disponibles, @Fabricante, @Tipo_Servicio, @Fecha_Alta)
	set @Id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Alta_Butaca](@Aeronave int, @Numero numeric(18,0), @Piso numeric(18,0), 
@Tipo_Butaca int, @Habilitada bit)
AS BEGIN
	INSERT INTO [NORMALIZADOS].[Butaca](Numero, Piso, Tipo_Butaca, Aeronave, Habilitada)
	VALUES (@Numero, @Piso, @Tipo_Butaca, @Aeronave, @Habilitada)
	declare @Id int
	set @Id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Modificar_Aeronave]
@Numero int,
@Matricula nvarchar(7),
@Fabricante int,
@Modelo nvarchar(255),
@Tipo_Servicio int,
@KG_Disponibles numeric(18,0),
@Fecha_Alta datetime
AS
BEGIN
	UPDATE [NORMALIZADOS].[Aeronave]
	SET Matricula = @Matricula,
		Fabricante = @Fabricante,
		Modelo = @Modelo,
		Tipo_Servicio = @Tipo_Servicio,
		KG_Disponibles = @KG_Disponibles,
		Fecha_Alta = @Fecha_Alta
	WHERE Numero = @Numero	
END
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Butacas_Aeronave]
@Numero_Aeronave int
AS
BEGIN
	SELECT B.*, TB.Descripcion
	FROM [NORMALIZADOS].[Butaca] B
	JOIN [NORMALIZADOS].[Tipo_Butaca] TB
	ON TB.Id = B.Tipo_Butaca
	WHERE Aeronave = @Numero_Aeronave
END
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Modificar_Butaca]
@Id int,
@Tipo int,
@Habilitada bit,
@Piso int,
@Numero int
AS
BEGIN
	UPDATE [NORMALIZADOS].[Butaca]
	SET Tipo_Butaca = @Tipo, Habilitada = @Habilitada, Piso = @Piso, Numero = @Numero
	WHERE Id = @Id	
END
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Baja_Butaca]
@Id int
AS
BEGIN
	UPDATE [NORMALIZADOS].[Butaca]
	SET Habilitada = 0
	WHERE Id = @Id	
END
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Aeronave_Con_Viajes]
	@Aeronave int,
	@Tiene_Viajes int OUTPUT
	AS
		
		IF (EXISTS	(select 1 
		from [NORMALIZADOS].Viaje V
		WHERE V.Aeronave = @Aeronave))
		BEGIN
			SET @Tiene_Viajes = 1;
		END
		ELSE
		BEGIN
			SET @Tiene_Viajes = 0;
		END
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Busqueda_Aeronave]
	@Modelo nvarchar(255),
	@Matricula nvarchar(255),
	@Kg_Disponibles numeric(18,0),
	@Fabricante nvarchar(255),
	@Tipo_Servicio nvarchar(255),
	@Fecha_Alta datetime,
	@Fecha_Alta_Fin datetime,
	@Fecha_Baja_Def datetime,
	@Fecha_Baja_Def_Fin datetime,
	@Fecha_Baja_Temporal datetime,
	@Fecha_Baja_Temporal_Fin datetime,
	@Fecha_Vuelta_Servicio datetime,
	@Fecha_Vuelta_Servicio_Fin datetime

	AS
	SELECT A.*, S.Descripcion, F.Nombre, M.Modelo_Desc
	FROM [NORMALIZADOS].Aeronave A
	LEFT JOIN [NORMALIZADOS].[Baja_Temporal_Aeronave] BTA
	ON A.Numero = BTA.Aeronave
	LEFT JOIN [NORMALIZADOS].Servicio S
	ON A.Tipo_Servicio = S.Id
	LEFT JOIN [NORMALIZADOS].Fabricante F
	ON A.Fabricante = F.Id
	LEFT JOIN [NORMALIZADOS].[Modelo] M
	ON M.Id = A.Modelo
	WHERE (M.Modelo_Desc like @Modelo OR @Modelo is null)
		AND (A.Matricula like @Matricula OR @Matricula like '')
		AND (A.Kg_Disponibles = @Kg_Disponibles OR @Kg_Disponibles = 0)
		AND (F.Nombre like @Fabricante OR @Fabricante is null)
		AND (S.Descripcion like @Tipo_Servicio OR @Tipo_Servicio is null)
		AND (A.Fecha_Alta > @Fecha_Alta OR @Fecha_Alta is null) 
		AND (A.Fecha_Alta < @Fecha_Alta_Fin OR @Fecha_Alta_Fin is null) 
		AND (A.Fecha_Baja_Definitiva > @Fecha_Baja_Def OR @Fecha_Baja_Def is null) 
		AND (A.Fecha_Baja_Definitiva < @Fecha_Baja_Def_Fin OR @Fecha_Baja_Def_Fin is null)
		AND (BTA.Fecha_Fuera_Servicio > @Fecha_Baja_Temporal OR @Fecha_Baja_Temporal is null) 
		AND (BTA.Fecha_Fuera_Servicio < @Fecha_Baja_Temporal_Fin OR @Fecha_Baja_Temporal_Fin is null) 
		AND (BTA.Fecha_Vuelta_Al_Servicio > @Fecha_Vuelta_Servicio OR @Fecha_Vuelta_Servicio is null)
		AND (BTA.Fecha_Vuelta_Al_Servicio < @Fecha_Vuelta_Servicio_Fin OR @Fecha_Vuelta_Servicio_Fin is null) 
GO

CREATE PROCEDURE [NORMALIZADOS].[SP_Busqueda_Baja_Aeronave]
	@Modelo nvarchar(255),
	@Matricula nvarchar(255),
	@Kg_Disponibles numeric(18,0),
	@Fabricante nvarchar(255),
	@Tipo_Servicio nvarchar(255),
	@Fecha_Alta datetime,
	@Fecha_Alta_Fin datetime

	AS
	SELECT A.*, S.Descripcion, F.Nombre, M.Modelo_Desc
	FROM [NORMALIZADOS].Aeronave A
	LEFT JOIN [NORMALIZADOS].Servicio S
	ON A.Tipo_Servicio = S.Id
	LEFT JOIN [NORMALIZADOS].Fabricante F
	ON A.Fabricante = F.Id
	LEFT JOIN [NORMALIZADOS].[Modelo] M
	ON M.Id = A.Modelo
	WHERE (M.Modelo_Desc like @Modelo OR @Modelo is null)
		AND (A.Matricula like @Matricula OR @Matricula like '')
		AND (A.Kg_Disponibles = @Kg_Disponibles OR @Kg_Disponibles = 0)
		AND (F.Nombre like @Fabricante OR @Fabricante is null)
		AND (S.Descripcion like @Tipo_Servicio OR @Tipo_Servicio is null)
		AND (A.Fecha_Alta > @Fecha_Alta OR @Fecha_Alta is null) 
		AND (A.Fecha_Alta < @Fecha_Alta_Fin OR @Fecha_Alta_Fin is null) 
		AND (A.Fecha_Baja_Definitiva is null)
		AND ( NOT EXISTS (SELECT 1
						  FROM [NORMALIZADOS].[Baja_Temporal_Aeronave] BTA
						  WHERE A.Numero = BTA.Aeronave
						  AND GETDATE() BETWEEN BTA.Fecha_Fuera_Servicio AND BTA.Fecha_Vuelta_Al_Servicio
						  )
			)
 
GO


--------------------------------------------------------------------------------
--				SP da de alta una ciudad
--------------------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[SP_Alta_Ciudad](@descripcion nvarchar(255))
AS
BEGIN
	INSERT INTO [NORMALIZADOS].Ciudad(Nombre)
		VALUES(@descripcion)

	SELECT @@IDENTITY
END
GO
--------------------------------------------------------------------------------
--				SP verifica si existe ciudad con descripcion
--------------------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[ExistCiudad_SEL_ByDescr](@descripcion nvarchar(255))
AS
BEGIN
	SELECT Id 
	FROM [NORMALIZADOS].Ciudad
	WHERE Nombre=@descripcion
END
GO
--------------------------------------------------------------------------------
--				SP obtiene las ciudades con una descripcion
--------------------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[GetCiudad_SEL_ByDescr](@descripcion nvarchar(255))
AS
BEGIN
	SELECT Id,Nombre
	FROM [NORMALIZADOS].Ciudad
	WHERE Nombre=@descripcion
END
GO
--------------------------------------------------------------------------------
--				SP modifica la ciudad
--------------------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[ActualizarCiudad_UPD_ById](@Id int,@nombre nvarchar(255))
AS
BEGIN
	UPDATE [NORMALIZADOS].Ciudad
	SET Nombre=@nombre
	WHERE Id=@Id

	SELECT @@IDENTITY
END
GO
--------------------------------------------------------------------------------
--				SP trae todas las ciudades
--------------------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[GetAllCiudad_SEL]
AS
BEGIN
	SELECT Id,Nombre
	FROM [NORMALIZADOS].Ciudad
END

--------------------------------------------------------------------------------
--			FUNCION devuelve cantidad de butacas ocupadas
--------------------------------------------------------------------------------

CREATE FUNCTION NORMALIZADOS.GetCantidadButacasOcupadas(@fecha_salida datetime,
												@ciudad_origen nvarchar(255), @ciudad_destino nvarchar(255), 
												@tipo_servicio nvarchar(255))
RETURNS int
AS 
	BEGIN
		
		DECLARE @butacas_ocupadas int

		SELECT @butacas_ocupadas = COUNT(*) FROM NORMALIZADOS.Pasaje P
		JOIN NORMALIZADOS.Compra C ON P.Compra = C.Id
		JOIN NORMALIZADOS.Viaje V ON C.Viaje = V.Id
		JOIN NORMALIZADOS.Ruta_Aerea R ON V.Ruta_Aerea = R.Id
		JOIN NORMALIZADOS.Ciudad C1 ON R.Ciudad_Origen = C1.ID
		JOIN NORMALIZADOS.Ciudad C2 ON R.Ciudad_Destino = C2.ID
		JOIN NORMALIZADOS.Servicio S ON R.Tipo_Servicio = S.ID
		WHERE V.Fecha_Salida = CONVERT(datetime,@fecha_salida,21) AND C1.Nombre LIKE '%'+@ciudad_origen AND C2.Nombre LIKE '%'+@ciudad_destino AND S.Descripcion = @tipo_servicio 

		RETURN @butacas_ocupadas
	END
GO

--select NORMALIZADOS.GetCantidadButacasOcupadas('2016-02-01 06:00:00.000','Nueva York', 'Londres', 'Turista')

------------------------------------------------------------------
--              FUNCION devuelve la cantidad total de butacas
--						para una aeronave
------------------------------------------------------------------

CREATE FUNCTION NORMALIZADOS.GetTotalButacas_SEL_ByMatricula(@matricula nvarchar(255))
RETURNS int
AS 
	BEGIN

		DECLARE @cantidad_butacas int

			SELECT @cantidad_butacas = COUNT(*) 
			FROM NORMALIZADOS.Butaca B
			JOIN NORMALIZADOS.Aeronave A ON A.Numero = B.Aeronave
			WHERE A.Matricula = @matricula

		RETURN @cantidad_butacas
	END
GO

------------------------------------------------------------------
--         FUNCION devuelve la cantidad de butacas disponibles
--				de una aeronave
------------------------------------------------------------------
CREATE FUNCTION NORMALIZADOS.GetCantidadButacasDisponibles(@fecha_salida datetime,
												@ciudad_origen nvarchar(255), @ciudad_destino nvarchar(255), 
												@tipo_servicio nvarchar(255))
RETURNS int
AS 
	BEGIN
		
		DECLARE @butacas_disponibles int

		SELECT @butacas_disponibles = (NORMALIZADOS.GetTotalButacas_SEL_ByMatricula(A.Matricula)-COUNT(*)) FROM NORMALIZADOS.Pasaje P
		JOIN NORMALIZADOS.Compra C ON P.Compra = C.Id
		JOIN NORMALIZADOS.Viaje V ON C.Viaje = V.Id
		JOIN NORMALIZADOS.Ruta_Aerea R ON V.Ruta_Aerea = R.Id
		JOIN NORMALIZADOS.Ciudad C1 ON R.Ciudad_Origen = C1.ID
		JOIN NORMALIZADOS.Ciudad C2 ON R.Ciudad_Destino = C2.ID
		JOIN NORMALIZADOS.Servicio S ON R.Tipo_Servicio = S.ID
		JOIN NORMALIZADOS.Aeronave A ON A.Numero = V.Aeronave
		WHERE V.Fecha_Salida = CONVERT(datetime,@fecha_salida,21) AND C1.Nombre LIKE '%'+@ciudad_origen AND C2.Nombre LIKE '%'+@ciudad_destino AND S.Descripcion = @tipo_servicio 
		GROUP BY A.Matricula

		RETURN @butacas_disponibles
	END
GO

--select NORMALIZADOS.GetCantidadButacasDisponibles('2016-02-01 06:00:00.000','Nueva York', 'Londres', 'Turista')

------------------------------------------------------------------
--         SP cantidad de butacas totales, ocupadas y disponibles por viaje
------------------------------------------------------------------

CREATE PROCEDURE [NORMALIZADOS].[GetAllButacas]
AS
BEGIN
	SELECT V.Fecha_Llegada, V.Fecha_Llegada_Estimada, V.Fecha_Llegada, C1.Nombre AS Ciudad_Origen, C2.Nombre AS Ciudad_Destino, S.Descripcion AS Tipo_Servicio, 
	NORMALIZADOS.GetTotalButacas_SEL_ByMatricula(A.Matricula) AS Total_Butacas, 
	NORMALIZADOS.GetCantidadButacasDisponibles(V.Fecha_Salida,C1.Nombre, C2.Nombre, S.Descripcion) AS Butacas_Disponibles,
	NORMALIZADOS.GetCantidadButacasOcupadas(V.Fecha_Salida,C1.Nombre, C2.Nombre, S.Descripcion) AS Butacas_Ocupadas
	FROM NORMALIZADOS.Pasaje P
	JOIN NORMALIZADOS.Compra C ON P.Compra = C.Id
	JOIN NORMALIZADOS.Viaje V ON C.Viaje = V.Id
	JOIN NORMALIZADOS.Ruta_Aerea R ON V.Ruta_Aerea = R.Id
	JOIN NORMALIZADOS.Ciudad C1 ON R.Ciudad_Origen = C1.ID
	JOIN NORMALIZADOS.Ciudad C2 ON R.Ciudad_Destino = C2.ID
	JOIN NORMALIZADOS.Servicio S ON R.Tipo_Servicio = S.ID
	JOIN NORMALIZADOS.Aeronave A ON A.Numero = V.Aeronave
END

------------------------------------------------------------------
--         SP verifica si existe una ruta con ciudad de origen, destino y servicio
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[ExistTuplaRuta](
@ciudadOrigen numeric(18,0),
@ciudadDestino numeric(18,0),
@tipoServicio numeric(18,0))
AS
BEGIN
	SELECT 1
	FROM [NORMALIZADOS].[Ruta_Aerea]
	WHERE Tipo_Servicio=@tipoServicio
			AND Ciudad_Origen=@ciudadOrigen
			AND Ciudad_Destino=@ciudadDestino
END
GO
------------------------------------------------------------------
--         SP verifica si existe una ruta con un codigo
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[ExistCodigoRuta](@codigoRuta numeric(18,0))
AS
BEGIN
	SELECT 1
	FROM [NORMALIZADOS].[Ruta_Aerea]
	WHERE Ruta_Codigo=@codigoRuta
END
GO
------------------------------------------------------------------
--         SP verifica si para un codigo de ruta ya existente
--				arma correctamente el tramo con las otras rutas con mismo codigo
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[CheckRutaConMismoCodigo](
@codigoRuta numeric(18,0),
@ciudadOrigen numeric(18,0),
@ciudadDestino numeric(18,0)
)
AS
BEGIN
	SELECT 1
	FROM [NORMALIZADOS].[Ruta_Aerea]
	WHERE @codigoRuta=Ruta_Codigo
		AND	(@ciudadOrigen=Ciudad_Destino
		OR @ciudadDestino=@ciudadOrigen)
END
GO
------------------------------------------------------------------
--         SP guarda una ruta
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[SaveRuta](
@codigoRuta numeric(18,0),
@ciudadOrigen numeric(18,0),
@ciudadDestino numeric(18,0),
@precioBasePasaje numeric(18,2),
@precioBaseKg numeric(18,2),
@tipoServicio numeric(18,0)
)
AS
BEGIN
	INSERT INTO [NORMALIZADOS].[Ruta_Aerea](Ruta_Codigo,
											Ciudad_Origen,
											Ciudad_Destino,
											Precio_BasePasaje,
											Precio_BaseKG,
											Tipo_Servicio)
		VALUES(@codigoRuta,
				@ciudadOrigen,
				@ciudadDestino,
				@precioBasePasaje,
				@precioBaseKg,
				@tipoServicio)

	SELECT @@ROWCOUNT
END
------------------------------------------------------------------
--         SP actualiza ruta/s con el mismo codigo
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[ActualizarRuta](
@codigoRuta numeric(18,0),
@ciudadOrigen numeric(18,0),
@ciudadDestino numeric(18,0),
@precioBasePasaje numeric(18,2),
@precioBaseKg numeric(18,2),
@tipoServicio numeric(18,0)
)
AS
BEGIN
	UPDATE [NORMALIZADOS].[Ruta_Aerea]
	SET Ruta_Codigo=@codigoRuta,
		Ciudad_Origen=@ciudadOrigen,
		Ciudad_Destino=@ciudadDestino,
		Precio_BaseKG=@precioBaseKg,
		Precio_BasePasaje=@precioBasePasaje,
		Tipo_Servicio=@tipoServicio
	WHERE Ruta_Codigo=@codigoRuta

	SELECT @@ROWCOUNT
END
GO
------------------------------------------------------------------
--         SP devuelve rutas de acuerdo a los filtros
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[GetRutaByFilters](
@codigo numeric(18,0),
@ciudadOrigen numeric(18,0),
@ciudadDestino numeric(18,0),
@precioBasePasaje numeric(18,2),
@precioBaseKg numeric(18,2),
@tipoServicio numeric(18,0)
)
AS
BEGIN
	SELECT RA.Id,
			RA.Ciudad_Origen as CiudadOrigenId,
			C1.Nombre as CiudadOrigenNombre,
			RA.Ciudad_Destino as CiudadDestinoId,
			C2.Nombre as CiudadDestinoNombre,
			RA.Ruta_Codigo as Codigo,
			RA.Precio_BaseKG,
			RA.Precio_BasePasaje,
			RA.Tipo_Servicio as ServicioId,
			S.Descripcion as ServicioDescr,
			RA.Habilitada
	FROM Ruta_Aerea RA
	JOIN Ciudad C1
		ON RA.Ciudad_Origen=C1.Id
	JOIN Ciudad C2
		ON RA.Ciudad_Destino=C2.Id
	JOIN Servicio S
		ON RA.Tipo_Servicio=S.Id
	WHERE (Ruta_Codigo=@codigo OR @codigo =0)
		AND (Ciudad_Origen=@ciudadOrigen OR @ciudadOrigen is null)
		AND (Ciudad_Destino=@ciudadDestino OR @ciudadDestino is null)
		AND (Tipo_Servicio=@tipoServicio OR @tipoServicio is null)
		AND (Precio_BaseKG=@precioBaseKg OR @precioBaseKg=0)
		AND (Precio_BasePasaje=@precioBasePasaje OR @precioBasePasaje=0)
END
GO
------------------------------------------------------------------
--         SP devuelve rutas de acuerdo a los filtros
------------------------------------------------------------------
CREATE PROCEDURE [NORMALIZADOS].[EliminarRuta](@IdRuta numeric(18,0))
AS
BEGIN
	UPDATE [NORMALIZADOS].[Ruta_Aerea]
	SET Habilitada=0
	WHERE Id=@IdRuta
END
