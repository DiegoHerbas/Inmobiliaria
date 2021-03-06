USE [taller]
GO
/****** Object:  Table [dbo].[carretera]    Script Date: 02/11/2017 9:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carretera](
	[idcarretera] [int] IDENTITY(1,1) NOT NULL,
	[nombre_carretera] [nvarchar](50) NOT NULL,
	[id_departamento] [int] NOT NULL,
	[id_tipo_carretera] [int] NOT NULL,
	[asignado] [bit] NOT NULL,
	[marca_baja] [bit] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[fecha_proceso] [datetime] NOT NULL,
	[usuario] [int] NOT NULL,
 CONSTRAINT [PK_carretera] PRIMARY KEY CLUSTERED 
(
	[idcarretera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[concepto]    Script Date: 02/11/2017 9:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[concepto](
	[idconcepto] [int] IDENTITY(1,1) NOT NULL,
	[prefijo] [int] NOT NULL,
	[correlativo] [int] NOT NULL,
	[descripcion] [nvarchar](200) NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[fecha_ult_proceso] [datetime] NOT NULL,
	[marca_baja] [bit] NOT NULL,
	[usuario] [int] NOT NULL,
 CONSTRAINT [PK_concepto] PRIMARY KEY CLUSTERED 
(
	[idconcepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalle_inventario]    Script Date: 02/11/2017 9:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_inventario](
	[iddetalleinventario] [int] IDENTITY(1,1) NOT NULL,
	[idinventario] [int] NOT NULL,
	[idfisura] [int] NOT NULL,
	[idnivelseveridad] [int] NOT NULL,
	[gps_latitud] [nvarchar](50) NULL,
	[gps_longitud] [nvarchar](50) NULL,
	[largo] [nvarchar](50) NULL,
	[ancho] [nvarchar](50) NULL,
	[medida_superficie] [nvarchar](50) NULL,
	[longitud] [nvarchar](50) NULL,
	[medida_longitud] [nvarchar](50) NULL,
	[profundidad] [decimal](18, 2) NULL,
	[descripcion] [nvarchar](200) NULL,
	[photo_name] [nvarchar](50) NULL,
	[tramo] [int] NULL,
	[carretera] [int] NULL,
	[cuadrilla] [int] NOT NULL,
	[marca_baja] [bit] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[fecha_proceso] [datetime] NOT NULL,
 CONSTRAINT [PK_detalle_inventario] PRIMARY KEY CLUSTERED 
(
	[iddetalleinventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[inventario]    Script Date: 02/11/2017 9:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[inventario](
	[idinventario] [int] IDENTITY(1,1) NOT NULL,
	[idcuadrilla] [int] NOT NULL,
	[idtramo] [int] NOT NULL,
	[idcarretera] [int] NOT NULL,
	[marca_baja] [bit] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[fecha_proceso] [datetime] NOT NULL,
 CONSTRAINT [PK_inventario] PRIMARY KEY CLUSTERED 
(
	[idinventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sgformulario]    Script Date: 02/11/2017 9:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sgformulario](
	[IdFormulario] [nvarchar](50) NOT NULL,
	[IdPadre] [nvarchar](50) NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Posicion] [int] NULL,
	[url] [nvarchar](50) NULL,
	[Icono] [nvarchar](50) NULL,
	[Paginas] [nvarchar](200) NULL,
	[Abm] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sgrupo_usuario_formulario]    Script Date: 02/11/2017 9:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sgrupo_usuario_formulario](
	[IdGrupoUsuario] [int] NOT NULL,
	[IdFormulario] [nvarchar](50) NOT NULL,
	[Adicionar] [bit] NULL,
	[Editar] [bit] NULL,
	[Eliminar] [bit] NULL,
	[Ver] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tramo]    Script Date: 02/11/2017 9:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tramo](
	[idtramo] [int] IDENTITY(1,1) NOT NULL,
	[nombre_tramo] [nvarchar](50) NOT NULL,
	[supervisor] [nvarchar](50) NOT NULL,
	[marca_baja] [bit] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[fecha_proceso] [datetime] NOT NULL,
	[usuario] [int] NOT NULL,
 CONSTRAINT [PK_tramo] PRIMARY KEY CLUSTERED 
(
	[idtramo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[usuario]    Script Date: 02/11/2017 9:49:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[idGrupoUsuario] [int] NOT NULL,
	[nombreCompleto] [nvarchar](200) NOT NULL,
	[nombreUsuario] [nvarchar](200) NOT NULL,
	[clave] [nvarchar](20) NOT NULL,
	[genero] [int] NOT NULL,
	[fecha_valides] [datetime] NOT NULL,
	[fecha_registro] [datetime] NOT NULL,
	[fecha_ult_proceso] [datetime] NOT NULL,
	[nombre_imagen] [nvarchar](255) NULL,
	[size] [int] NULL,
	[imagen] [varbinary](max) NULL,
	[marca_baja] [bit] NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
