USE [KineAppBitacora]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 11/9/2018 00:00:30 ******/
DROP TABLE [dbo].[Bitacora]
GO
/****** Object:  StoredProcedure [dbo].[Bitacora_leer]    Script Date: 11/9/2018 00:00:30 ******/
DROP PROCEDURE [dbo].[Bitacora_leer]
GO
/****** Object:  StoredProcedure [dbo].[Bitacora_alta]    Script Date: 11/9/2018 00:00:30 ******/
DROP PROCEDURE [dbo].[Bitacora_alta]
GO
/****** Object:  StoredProcedure [dbo].[Bitacora_alta]    Script Date: 11/9/2018 00:00:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Bitacora_alta]
@usuario varchar(50),@fecha Date, @tabla varchar(50),
@dato varchar(50), @accion varchar(50), @dvh varchar(50) as
begin
insert into Bitacora values (@usuario,@fecha, @tabla, @accion, @dato, @dvh);
end

GO
/****** Object:  StoredProcedure [dbo].[Bitacora_leer]    Script Date: 11/9/2018 00:00:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Bitacora_leer]
 as
begin
select * from Bitacora
end

GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 11/9/2018 00:00:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[fecha] [datetime] NULL,
	[tabla] [varchar](50) NOT NULL,
	[accion] [varchar](50) NOT NULL,
	[dato] [varchar](50) NOT NULL,
	[DVH] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
