USE [EntityFrameworkPruebaConcepto]
GO
/****** Object:  Table [dbo].[Notificaciones]    Script Date: 17/01/2024 20:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificaciones](
	[Id] [uniqueidentifier] NOT NULL,
	[Contenido] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificacionesHistorico]    Script Date: 17/01/2024 20:47:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificacionesHistorico](
	[Id] [uniqueidentifier] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[ContenidoHistorico] [nvarchar](max) NOT NULL,
	[NotificacionId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[NotificacionesHistorico]  WITH CHECK ADD FOREIGN KEY([NotificacionId])
REFERENCES [dbo].[Notificaciones] ([Id])
ON DELETE CASCADE
GO
