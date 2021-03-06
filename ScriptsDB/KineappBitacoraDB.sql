USE [master]
GO
/****** Object:  Database [KineAppBitacora]    Script Date: 26/11/2018 01:25:36 ******/
CREATE DATABASE [KineAppBitacora]

GO
USE [KineAppBitacora]
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 26/11/2018 01:25:36 ******/
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
/****** Object:  StoredProcedure [dbo].[Bitacora_alta]    Script Date: 26/11/2018 01:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[Bitacora_alta]
@usuario varchar(50),@fecha datetime, @tabla varchar(50),
@dato varchar(50), @accion varchar(50), @dvh varchar(50) as
begin
insert into Bitacora values (@usuario,@fecha, @tabla, @accion, @dato, @dvh);
end


GO
/****** Object:  StoredProcedure [dbo].[Bitacora_leer]    Script Date: 26/11/2018 01:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[Bitacora_leer]
 as
begin
select * from Bitacora order by id;
end


GO
USE [master]
GO
ALTER DATABASE [KineAppBitacora] SET  READ_WRITE 
GO
