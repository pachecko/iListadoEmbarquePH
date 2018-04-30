/*--------------------------------------------------------------------------
	REFERENCIA	2011001-2011081800(1)
	FECHA		29-AGO-2011
	AUTOR		AA - RY
	PROYECTO	iListadoEmbarquePH
	MOTIVO		Genera catálogos para Palacio de Hierro.

	
			DROP TABLE EmbarquePH
			DROP TABLE ProveedorPH
			DROP TABLE SucursalPH
--------------------------------------------------------------------------*/

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProveedorPH](
	[IdProveedorPH] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [nvarchar](5) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[DescripcionCorta] [nvarchar](10) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_ProveedorPH] PRIMARY KEY CLUSTERED 
(
	[IdProveedorPH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[EmbarquePH](
	[IdEmbarquePH] [int] IDENTITY(1,1) NOT NULL,
	[IdCaja] [int] NOT NULL,
	[Pedido] [nvarchar](10) NOT NULL,
	[ClaveProveedorPH] [int] NOT NULL,
	[IdSucursalPH] [int] NOT NULL,
	[CodigoBarras] [nvarchar](13) NOT NULL,
	[FechaOperacion] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_EmbarquePH] PRIMARY KEY CLUSTERED 
(
	[IdEmbarquePH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EmbarquePH] ADD  CONSTRAINT [DF_EmbarquePH_IdCaja]  DEFAULT ((0)) FOR [IdCaja]
GO

ALTER TABLE [dbo].[EmbarquePH] ADD  CONSTRAINT [DF_EmbarquePH_FechaOperacion]  DEFAULT (getdate()) FOR [FechaOperacion]
GO

CREATE TABLE [dbo].[SucursalPH](
	[IdSucursalPH] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](10) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[DescripcionCorta] [varchar](20) NOT NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_SucursalPH] PRIMARY KEY CLUSTERED 
(
	[IdSucursalPH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-------------DATOS DE TABLA--------------------------
INSERT INTO ProveedorPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('15068','Librerías Gandhi S.A de C.V.','Lib Gandhi','A')
GO

INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('200', 'DURANGO', 'DURANGO', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('201', 'CENTRO', 'CENTRO', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('202', 'PERISUR', 'PERISUR', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('203', 'COYOACÁN', 'COYOACÁN', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('204', 'SANTA FE', 'SANTA FE', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('205', 'POLANCO', 'POLANCO', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('207', 'SATÉLITE', 'SATÉLITE', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('208', 'GUADALAJARA', 'GUADALAJARA', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('209', 'PUEBLA', 'PUEBLA', 'A')
INSERT INTO SucursalPH (Clave, Descripcion, DescripcionCorta, Estado) VALUES ('211', 'MONTERREY', 'MONTERREY', 'A')

SET ANSI_PADDING OFF
GO
