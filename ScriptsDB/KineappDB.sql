USE [master]
GO
/****** Object:  Database [KineApp]    Script Date: 26/11/2018 23:32:50 ******/
CREATE DATABASE [KineApp]
GO

USE [KineApp]
GO
/****** Object:  StoredProcedure [dbo].[Consulta_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Consulta_alta]
@paciente int,
@fecha date,
@resumen varchar(500),
@dvh varchar(50),
@id int output as
begin
insert into Consulta values (@paciente, @fecha,@resumen,@dvh);
SET @id=SCOPE_IDENTITY();
end;




GO
/****** Object:  StoredProcedure [dbo].[Consulta_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Consulta_buscar]
@id int
as
begin
SELECT *
  FROM Consulta
  where id = @id;
  end;




GO
/****** Object:  StoredProcedure [dbo].[Consulta_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Consulta_leer]
as
begin
SELECT *
  FROM Consulta;
  end;




GO
/****** Object:  StoredProcedure [dbo].[Consulta_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Consulta_modificar]
@paciente int,
@fecha date,
@resumen varchar(500),
@dvh varchar(50),
@id int as
begin
update Consulta set
paciente = @paciente, fecha = @fecha, resumen = @resumen, DVH = @dvh
where id = @id;
end;





GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalle_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaDetalle_alta]
@id_consulta int, 
@id_ejercicio int, 
@id_entrenamiento int,
@id_tratamiento int,
@id_patologia int,
@resultado varchar(500),
@observaciones varchar(500), 
@dvh varchar(50)
 as
begin
insert into ConsultaDetalle values (@id_consulta, @id_ejercicio,@id_entrenamiento, @id_tratamiento, @id_patologia, @resultado, @observaciones, @dvh);
end;





GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalle_borrar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[ConsultaDetalle_borrar]
@id_consulta int
as
begin
delete from ConsultaDetalle 
where id_consulta = @id_consulta
end;





GO
/****** Object:  StoredProcedure [dbo].[ConsultaDetalle_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ConsultaDetalle_leer]
@id_consulta int as
begin
select * from ConsultaDetalle where id_consulta = @id_consulta;
end;




GO
/****** Object:  StoredProcedure [dbo].[CopiaDeSeguridad_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[CopiaDeSeguridad_alta]
@nombre varchar(200), @fecha DateTime
As
Begin
insert into CopiaDeSeguridad values (@nombre, @fecha);
end;





GO
/****** Object:  StoredProcedure [dbo].[CopiaDeSeguridad_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[CopiaDeSeguridad_leer]
As
Begin
select * from CopiaDeSeguridad
end;




GO
/****** Object:  StoredProcedure [dbo].[Digitoverificador_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Digitoverificador_alta]
@tabla varchar(50), @dvv varchar(50), @dvh varchar(50) as
begin
insert into Digitoverificador values (@tabla, @dvv, @dvh);
end;




GO
/****** Object:  StoredProcedure [dbo].[Digitoverificador_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Digitoverificador_leer]
 as
begin
select * from Digitoverificador
end;




GO
/****** Object:  StoredProcedure [dbo].[Digitoverificador_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Digitoverificador_modificar]
@tabla varchar(50), @dvv varchar(50), @dvh varchar(50) as
begin
update Digitoverificador set dvv = @dvv, DVH = @dvh where tabla = @tabla ;
end;




GO
/****** Object:  StoredProcedure [dbo].[Ejercicio_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Ejercicio_alta]
@nombre varchar(100),
@descripcion varchar(1000),
@cantidad varchar(1000),
@repeticiones varchar(1000),
@palabras varchar(500) as
begin
insert into Ejercicio values (@nombre,@descripcion, @cantidad, @repeticiones, @palabras);
end;




GO
/****** Object:  StoredProcedure [dbo].[Ejercicio_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Ejercicio_buscar]
@id int as
begin
select * from Ejercicio where id = @id;
end;





GO
/****** Object:  StoredProcedure [dbo].[Ejercicio_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Ejercicio_leer]
as
begin
select * from Ejercicio;
end;





GO
/****** Object:  StoredProcedure [dbo].[Ejercicio_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Ejercicio_modificar]
@id int, @nombre varchar(100),
@descripcion varchar(1000),
@cantidad varchar(1000),
@repeticiones varchar(1000),
@palabras varchar(500) as
begin
update Ejercicio set 
nombre = @nombre, descripcion = @descripcion, cantidad = @cantidad, repeticiones = @repeticiones, palabras = @palabras
where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Entrenamiento_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Entrenamiento_alta]
@nombre varchar(100),
@descripcion varchar(1000),
@palabras varchar(500),
@id int output as
begin
insert into Entrenamiento values (@nombre,@descripcion, @palabras);
SET @id=SCOPE_IDENTITY();
end;





GO
/****** Object:  StoredProcedure [dbo].[Entrenamiento_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Entrenamiento_buscar]
@id int as
begin
select * from Entrenamiento where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Entrenamiento_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Entrenamiento_leer]
as
begin
select * from Entrenamiento;
end;





GO
/****** Object:  StoredProcedure [dbo].[Entrenamiento_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Entrenamiento_modificar]
@id int,
@nombre varchar(100),
@descripcion varchar(1000),
@palabras varchar(500) as
begin
update Entrenamiento set
nombre = @nombre, descripcion = @descripcion, palabras = @palabras
where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[EntrenamientoEjercicio_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EntrenamientoEjercicio_alta]
@id_entrenamiento int, @id_ejercicio int, @observaciones varchar(500) as
begin
insert into EntrenamientoEjercicio values (@id_entrenamiento, @id_ejercicio, @observaciones);
end;




GO
/****** Object:  StoredProcedure [dbo].[EntrenamientoEjercicio_baja]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EntrenamientoEjercicio_baja]
@id_entrenamiento int as
begin
delete from EntrenamientoEjercicio where id_entrenamiento = @id_entrenamiento;
end;




GO
/****** Object:  StoredProcedure [dbo].[EntrenamientoEjercicio_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EntrenamientoEjercicio_leer]
@id_entrenamiento int as
begin
select * from EntrenamientoEjercicio en join Ejercicio ej on en.id_ejercicio = ej.id
where id_entrenamiento = @id_entrenamiento;
end;




GO
/****** Object:  StoredProcedure [dbo].[Idioma_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Idioma_alta]
@idioma varchar(50)
 as
BEGIN


IF (SELECT count(*) FROM idioma WHERE nombre = @idioma) > 0
	BEGIN
	UPDATE idioma SET nombre = @idioma WHERE nombre = @idioma;
	END
ELSE
	BEGIN
	INSERT INTO idioma VALUES (@idioma);
	END
END;





GO
/****** Object:  StoredProcedure [dbo].[Idioma_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Idioma_leer]
 as
begin
select * from idioma
end;




GO
/****** Object:  StoredProcedure [dbo].[IdiomaDetalle_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IdiomaDetalle_alta]
@idioma varchar(50), @clave varchar(50), @texto varchar(200)
 as
BEGIN

DECLARE @id int;
SET @id = (SELECT TOP 1 id FROM idioma WHERE nombre = @idioma);

IF (SELECT count(clave) FROM idiomaDetalle WHERE idioma = @id and clave = @clave) > 0
	BEGIN
	UPDATE idiomaDetalle SET texto = @texto WHERE idioma = @id and clave = @clave;
	print 'update';
	END
ELSE
	BEGIN
	INSERT INTO idiomaDetalle VALUES (@id, @clave, @texto);
	print 'insert';
	END
END;





GO
/****** Object:  StoredProcedure [dbo].[IdiomaDetalle_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[IdiomaDetalle_leer]
@idioma varchar(50)
 as
begin
declare @id int
set @id = (select TOP 1 id from idioma where nombre = @idioma);
select * from idiomaDetalle where idioma = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Paciente_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Paciente_alta]
@dni int, @nombre varchar(50), @apellido varchar(50),@fecha datetime, @dvh varchar(50) as
begin
insert into Paciente values (@dni, @nombre,@apellido, @fecha, @dvh);
end;




GO
/****** Object:  StoredProcedure [dbo].[Paciente_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Paciente_buscar]
@dni int as
begin
select * from Paciente where dni= @dni;
end;




GO
/****** Object:  StoredProcedure [dbo].[Paciente_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Paciente_leer]
as
begin
select dni, nombre, apellido, fechaNacimiento, DVH from Paciente;
end;




GO
/****** Object:  StoredProcedure [dbo].[Paciente_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Paciente_modificar]
@dni int, @nombre varchar(50), @apellido varchar(50),@fecha datetime, @dvh varchar(50) as
begin
update Paciente set 
nombre = @nombre, apellido = @apellido, fechaNacimiento = @fecha, DVH = @dvh 
where dni= @dni
end;




GO
/****** Object:  StoredProcedure [dbo].[Patologia_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Patologia_alta]
@nombre varchar(100),
@descripcion varchar(1000),
@palabras varchar(500),
@id int output as
begin
insert into Patologia values ( @nombre,@descripcion, @palabras);
SET @id=SCOPE_IDENTITY();
end;




GO
/****** Object:  StoredProcedure [dbo].[Patologia_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Patologia_buscar]
@id int
as
begin
select * from Patologia where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Patologia_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Patologia_leer]
as
begin
select * from Patologia;
end;




GO
/****** Object:  StoredProcedure [dbo].[Patologia_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Patologia_modificar]
@id int,
@nombre varchar(100),
@descripcion varchar(1000),
@palabras varchar(500)
as
begin
update Patologia set
nombre = @nombre, descripcion = @descripcion, palabras = @palabras
where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Perfil_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Perfil_alta]
@nombre varchar(50), @padre int as
begin
insert into Perfil values (@nombre,@padre);
end;




GO
/****** Object:  StoredProcedure [dbo].[Perfil_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Perfil_buscar]
@id int as
begin
select * from Perfil
where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Perfil_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Perfil_leer]
as
begin
select id, nombre, padre from Perfil;
end;




GO
/****** Object:  StoredProcedure [dbo].[Perfil_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Perfil_modificar]
@id int, @nombre varchar(50), @padre int as
begin
update Perfil set
nombre = @nombre, padre = @padre
where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Tratamiento_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Tratamiento_alta]
@nombre varchar(100),
@descripcion varchar(1000),
@palabras varchar(500),
@id int output as
begin
insert into Tratamiento values (@nombre,@descripcion, @palabras);
SET @id=SCOPE_IDENTITY();
end;




GO
/****** Object:  StoredProcedure [dbo].[Tratamiento_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Tratamiento_buscar]
@id int as
begin
select * from Tratamiento where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Tratamiento_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Tratamiento_leer]
as
begin
select * from Tratamiento;
end;




GO
/****** Object:  StoredProcedure [dbo].[Tratamiento_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Tratamiento_modificar]
@id int, @nombre varchar(100),
@descripcion varchar(1000),
@palabras varchar(500) as
begin
update Tratamiento set 
nombre = @nombre, descripcion = @descripcion, palabras = @palabras
where id = @id;
end;




GO
/****** Object:  StoredProcedure [dbo].[Usuario_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario_alta]
@usuario varchar(50),@pass varchar(50),@nombre varchar(50),
@apellido varchar(50),@correo varchar(50),@dni int, @dvh varchar(50) as
begin
insert into Usuario values (@usuario,@pass, @correo, @nombre,@apellido,@dni,@dvh);
end;




GO
/****** Object:  StoredProcedure [dbo].[Usuario_buscar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario_buscar]
@usuario varchar(50) as
begin
select * from usuario where usuario.usuario = @usuario;
end;




GO
/****** Object:  StoredProcedure [dbo].[Usuario_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario_leer]
 as
begin
select * from usuario
end;




GO
/****** Object:  StoredProcedure [dbo].[Usuario_login]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario_login]
@usuario varchar(50), @pass varchar(50) as
begin
select * from usuario where usuario.usuario = @usuario and usuario.password = @pass;
end;





GO
/****** Object:  StoredProcedure [dbo].[Usuario_modificar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario_modificar]
@usuario varchar(50),@pass varchar(50),@nombre varchar(50),
@apellido varchar(50),@correo varchar(50),@dni int, @dvh varchar(50) as
begin
update Usuario set 
password = @pass, correo = @correo, nombre = @nombre, apellido = @apellido, dni= @dni, dvh = @dvh 
where usuario = @usuario
end;





GO
/****** Object:  StoredProcedure [dbo].[Usuario_modificarPass]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario_modificarPass]
@usuario varchar(50),@pass varchar(50) as
begin
update Usuario set 
password = @pass 
where usuario = @usuario
end;





GO
/****** Object:  StoredProcedure [dbo].[UsuarioPerfil_alta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsuarioPerfil_alta]
@usuario varchar(50), @perfil int as
begin
insert into UsuarioPerfil values (@usuario,@perfil);
end;





GO
/****** Object:  StoredProcedure [dbo].[UsuarioPerfil_borrar]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsuarioPerfil_borrar]
@usuario varchar(50)as
begin
delete from UsuarioPerfil 
where usuario = @usuario
end;





GO
/****** Object:  StoredProcedure [dbo].[UsuarioPerfil_leer]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UsuarioPerfil_leer]
@usuario varchar(50) as
begin
select * from UsuarioPerfil inner join Perfil on UsuarioPerfil.perfil = Perfil.id where usuario = @usuario;
end;





GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[paciente] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[resumen] [varchar](500) NOT NULL,
	[DVH] [varchar](50) NULL,
 CONSTRAINT [PK_Consulta_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConsultaDetalle]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultaDetalle](
	[id_consulta] [int] NOT NULL,
	[id_ejercicio] [int] NOT NULL,
	[id_entrenamiento] [int] NOT NULL,
	[id_tratamiento] [int] NOT NULL,
	[id_patologia] [int] NOT NULL,
	[resultado] [varchar](500) NULL,
	[observaciones] [varchar](500) NULL,
	[DVH] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CopiaDeSeguridad]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CopiaDeSeguridad](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](200) NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_CopiaDeSeguridad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Digitoverificador]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Digitoverificador](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[tabla] [varchar](50) NOT NULL,
	[DVV] [varchar](50) NOT NULL,
	[DVH] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ejercicio]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ejercicio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](1000) NULL,
	[cantidad] [varchar](1000) NULL,
	[repeticiones] [varchar](1000) NULL,
	[palabras] [varchar](500) NULL,
 CONSTRAINT [PK_Ejercicio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entrenamiento]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrenamiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](1000) NULL,
	[palabras] [varchar](500) NULL,
 CONSTRAINT [PK_Entrenamiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EntrenamientoEjercicio]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntrenamientoEjercicio](
	[id_entrenamiento] [int] NOT NULL,
	[id_ejercicio] [int] NOT NULL,
	[observaciones] [varchar](500) NULL,
 CONSTRAINT [PK_EntrenamientoEjercicio] PRIMARY KEY CLUSTERED 
(
	[id_entrenamiento] ASC,
	[id_ejercicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Idioma](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[IdiomaDetalle]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdiomaDetalle](
	[idioma] [int] NOT NULL,
	[clave] [varchar](50) NOT NULL,
	[texto] [varchar](200) NOT NULL,
 CONSTRAINT [PK_IdiomaDetalle] PRIMARY KEY CLUSTERED 
(
	[idioma] ASC,
	[clave] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[dni] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[fechaNacimiento] [datetime] NULL,
	[DVH] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patologia]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patologia](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](5000) NULL,
	[palabras] [varchar](500) NULL,
 CONSTRAINT [PK_Patologia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfil](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[padre] [int] NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tratamiento]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[descripcion] [varchar](1000) NULL,
	[palabras] [varchar](500) NULL,
 CONSTRAINT [PK_Tratamiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[dni] [int] NULL,
	[DVH] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 20/12/2018 11:49:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioPerfil](
	[usuario] [varchar](50) NOT NULL,
	[perfil] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPerfil] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC,
	[perfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Digitoverificador] ON 

INSERT [dbo].[Digitoverificador] ([id], [tabla], [DVV], [DVH]) VALUES (1, N'Usuario', N'8', N'2')
INSERT [dbo].[Digitoverificador] ([id], [tabla], [DVV], [DVH]) VALUES (2, N'Paciente', N'0', N'0')
INSERT [dbo].[Digitoverificador] ([id], [tabla], [DVV], [DVH]) VALUES (3, N'Consulta', N'0', N'0')
SET IDENTITY_INSERT [dbo].[Digitoverificador] OFF
SET IDENTITY_INSERT [dbo].[Ejercicio] ON 

INSERT [dbo].[Ejercicio] ([id], [nombre], [descripcion], [cantidad], [repeticiones], [palabras]) VALUES (1, N'Rodillas flexionadas', N'Túmbate  en el suelo y estira una pierna mientras mantienes la otra doblada con el pie apoyado.', N'Levanta la pierna que tienes estirada y mantén esa posición unos 10 segundos.', N'1 Vez al día.', N'Rodilla, Pierna')
INSERT [dbo].[Ejercicio] ([id], [nombre], [descripcion], [cantidad], [repeticiones], [palabras]) VALUES (2, N'Extensión de pierna', N'Puedes sentarte o tumbarte directamente sobre el suelo.
Sube la pierna, recta, unos 20 cm sobre el suelo.', N'Mantén esta posición durante 10 segundos y bájala mientras flexionas la rodilla.', N'Realiza este ejercicio 10 veces con cada pierna.', N'Rodilla, Pierna')
INSERT [dbo].[Ejercicio] ([id], [nombre], [descripcion], [cantidad], [repeticiones], [palabras]) VALUES (3, N'Sentarse en el aire', N'Manteniendo la siguiente rutina, conseguirás que tus rodillas vuelvan a ser flexibles y recuperen fuerza.
Apoya tu espalda contra la pared y separa tus pies de la pared y entre sí.
Ya en esta posición, comienza a descender muy lentamente hasta encontrarte “sentado” en el aire.', N'Mantén esta posición durante unos 10 o 15 segundos. Reincorpórate lentamente y hazlo de nuevo.', N'Lo recomendable es realizar el ejercicio 5 veces al día, haciendo 10 repeticiones cada vez.', N'Rodilla, Pierna')
INSERT [dbo].[Ejercicio] ([id], [nombre], [descripcion], [cantidad], [repeticiones], [palabras]) VALUES (4, N'Caminar', N'Caminar es uno de los ejercicios más saludables que existen. Se trata de una actividad que no compromete los límites cardíacos ni arriesga las articulaciones de los pies, la rodilla o la cadera.', N'No es trotar y mucho menos correr, pero tampoco es un paseo relajado. Caminar con un paso firme y constante durante 30 o 40 minutos', N'3 Veces a la Semana.', N'Cadera, Espalda, Pierna')
INSERT [dbo].[Ejercicio] ([id], [nombre], [descripcion], [cantidad], [repeticiones], [palabras]) VALUES (5, N'Superman', N'Comenzar en 4 pies, luego al mismo tiempo elevar brazo y pierna contrarios. Debemos mirar el suelo, ya que la cabeza debe seguir la línea de la columna. No hay que subir demasiado las extremidades. La columna no debe “arquearse”. Y el brazo debe alcanzar la altura de la oreja (a muchos les cuesta esto).', N'El abdomen debe estar contraído al mantener la posición, la idea es mantener por 5 a 10 segundos y luego alternar.', N'Puedes comenzar haciendo 15 repeticiones por lado.', N'Espalda, Cadera, Pierna')
SET IDENTITY_INSERT [dbo].[Ejercicio] OFF
SET IDENTITY_INSERT [dbo].[Entrenamiento] ON 

INSERT [dbo].[Entrenamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (1, N'Rodilla', N'Recuperacion de rodilla', N'Rodilla, Pierna')
SET IDENTITY_INSERT [dbo].[Entrenamiento] OFF
INSERT [dbo].[EntrenamientoEjercicio] ([id_entrenamiento], [id_ejercicio], [observaciones]) VALUES (1, 3, N'')
INSERT [dbo].[EntrenamientoEjercicio] ([id_entrenamiento], [id_ejercicio], [observaciones]) VALUES (1, 4, N'')
INSERT [dbo].[EntrenamientoEjercicio] ([id_entrenamiento], [id_ejercicio], [observaciones]) VALUES (1, 5, N'')
SET IDENTITY_INSERT [dbo].[Idioma] ON 

INSERT [dbo].[Idioma] ([id], [nombre]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([id], [nombre]) VALUES (2, N'English')
SET IDENTITY_INSERT [dbo].[Idioma] OFF
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnAceptar', N'Aceptar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnAgregar', N'Agregar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnBackup', N'Realizar Copia de Seguridad')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnBuscar', N'Buscar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnBuscarEjercicio', N'Buscar Ejercicio')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnBuscarEntrenamiento', N'Buscar Entrenamiento')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnBuscarPaciente', N'Buscar Paciente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnBuscarPatologia', N'Buscar Patologia')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnBuscarTratamiento', N'Buscar Tratamiento')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnCalcular', N'Calcular')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnCancelar', N'Cancelar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnCrearGrupo', N'Crear Grupo')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnFiltrar', N'Filtrar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnGuardar', N'Guardar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnImprimir', N'Imprimir')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnLimpiar', N'Limpiar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnModificar', N'Modificar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnNuevaConsulta', N'Nueva Consulta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnNuevo', N'Nuevo')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnRemover', N'Remover')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnRestore', N'Restaurar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnSeleccionarCarpeta', N'Seleccionar Carpeta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'btnVerificar', N'Verificar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'errorCompletarPass', N'Complete la Contraseña')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'errorCompletarUser', N'Complete el Usuario')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'errorDatoMal', N'Error de Datos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'errorFaltaDato', N'Error Falta Cargar Datos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'errorGuardar', N'Error al Guardar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'errorLogin', N'Usuario o contraseña incorrecta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmAltaPaciente', N'Alta de Paciente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmAyuda', N'Ayuda')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmBuscarEjer', N'Buscar Ejercicios')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmConsulta', N'Consulta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmConsultaPatologias', N'Consulta de Patologias y lesiones')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmConsultarEntrenamiento', N'Consultar Entrenamiento')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmConsultarPaciente', N'Consultar Paciente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmConsultaTratamientos', N'Consulta de Tratamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmCopiaSeguridad', N'Copia de Seguridad y Restauración')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmDigito', N'Gestión de Digito Verificador')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmModificarPaciente', N'Paciente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmPatologias', N'Patologias y lesiones')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'frmTratamientos', N'Tratamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblApellido', N'Apellido')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblBuscar', N'Buscar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblCantidad', N'Cantidad')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblCarpeta', N'Carpeta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblClave', N'Clave')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblCopias', N'Copias de Seguridad')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblCorreo', N'Correo')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblDescripcion', N'Descripción')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblDesde', N'Desde')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblDetalle', N'Detalle')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblDni', N'Dni')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblDVH', N'Digito Verificador Horizontal')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblDVV', N'Digito Verificador Vertical')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblEdad', N'Fecha de Nacimiento')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblEntrenamientos', N'Entrenamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblEspaniol', N'Español')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblFecha', N'Fecha')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblGrupo', N'Grupo')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblHasta', N'Hasta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblIngles', N'Ingles')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblLog', N'Bitacora')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblMenu', N'Menu')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblNombre', N'Nombre')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblObservaciones', N'Observaciones')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPaciente', N'Paciente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPadre', N'Padre')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPalabrasClave', N'Palabras Clave')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPalabrasClaveInfo', N'Palabras separadas por coma, utilizadas para filtrar en la Consulta Medica')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPassword', N'Contraseña')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPassword2', N'Repetir Contraseña')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPerfiles', N'Perfil')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPersona', N'Persona')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblPersonales', N'Datos Personales')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblRepeticiones', N'Repeticiones')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblResultado', N'Resultado')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblResumen', N'Resumen')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblRol', N'Rol')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblRolUsuario', N'Roles del Usuario')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblTexto', N'Texto')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblTraduccion', N'Traducción')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblUsuario', N'Usuario')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'lblUsuarios', N'Usuarios')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'loginDescripcion', N'SISTEMA DE GESTIÓN PARA CONSULTORIO DE KINESIOLOGÍA DEPORTIVA')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmBackup', N'Gestión de Copia de Seguridad')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmBitacora', N'Consultar Bitácora')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdminIdioma', N'Gestión de Idioma')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdministracion', N'Administración')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmPerfiles', N'Gestión de Perfiles')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmRoles', N'Gestión de Roles')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmUsuarios', N'Gestión de Usuarios')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuCerrarSesion', N'Cerrar Sesión')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuEntrenamientos', N'Gestión de Entrenamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuEntrenamientosEjercicios', N'Gestión de Ejercicios')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuEntrenamientosEntrenamientos', N'Gestión de Entrenamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuGestionPacientes', N'Gestión de Pacientes')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuIdioma', N'Idioma')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuMenu', N'Menú')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteAlta', N'Alta de Paciente')
GO
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteConsulta', N'Gestión de Consulta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteHistorial', N'Historial')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteModificacion', N'Consultar Paciente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'MenuPatologias', N'Gestión de Patologias y lesiones')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuSalir', N'Salir')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'MenuTratamientos', N'Gestión de Tratamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgBackNo', N'Error al hacer Copia de Seguridad')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgBackOk', N'Copia de Seguridad Generada con Exito')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgCalculandoDVV', N'Calculando DVV Tabla: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgCerrarSesion', N'¿Desea cerrar la Sesión?')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgComprobando', N'Comprobando Tabla: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgEnviarPass', N'Contraseña enviada por Correo (No Implementado)')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgError', N'Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorAlta', N'Error al dar de Alta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorAltaPaciente', N'Error al dar de alta Paciente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorArchivoNoExiste', N'Archivo No Encontrado')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgERrorMail', N'Error en el Correo')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorPassNoIguales', N'Las Contraseñas no son iguales')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorRegistro', N'Error en el registro: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorUnItem', N'Seleccione al menos un Item')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorVerificarDV', N'Error al Verificar los digitos verificadores, por favor contacte un administrador.')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgErrorVerificarDV2', N'Error al Verificar los digitos verificadores.')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgFaltaCompletar', N'Falta Completar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgFaltaCompletarTitulo', N'Error de Validación')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgLargoPass', N'Las Contraseñas deben ser mínimo 6 caracteres')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgLargoUsr', N'El Usuario debe ser mínimo 6 caracteres')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgNofiltro', N'No hay Filtro seleccionado')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgOperacionOk', N'Operación Realizada con Éxito')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgPacienteNoEncontrado', N'Paciente no encontrado')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgRegistro', N'Registro: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgRegistrosCalculados', N'Registros Calculados: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgRegistrosComprobados', N'Registros comprobados: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgRestoreNo', N'Error al Recuperar la Base de Datos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgRestoreOk', N'Base de Datos Restaurada exitosamente')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgResultado', N'Resultado: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'msgVerificandoDVV', N'Verificando DVV')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'recuperarpass', N'Recuperar Contraseña')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnAceptar', N'Ok')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnAgregar', N'Add')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnBackup', N'Make Backup')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnBuscar', N'Search')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnBuscarEjercicio', N'Search Exercise')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnBuscarEntrenamiento', N'Search Training')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnBuscarPaciente', N'Search Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnBuscarPatologia', N'Search Pathology')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnBuscarTratamiento', N'Search Treatments')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnCalcular', N'Calc')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnCancelar', N'Cancel')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnCrearGrupo', N'Create Group')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnFiltrar', N'Filter')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnGuardar', N'Save')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnImprimir', N'Print')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnLimpiar', N'Clean')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnModificar', N'Modify')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnNuevaConsulta', N'New Consult')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnNuevo', N'New')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnRemover', N'Remove')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnRestore', N'Restore')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnSeleccionarCarpeta', N'Select Folder')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'btnVerificar', N'Check')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'errorCompletarPass', N'Complete the Password')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'errorCompletarUser', N'Complete the User')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'errorDatoMal', N'Data Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'errorFaltaDato', N'Error Missing Data')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'errorGuardar', N'Save Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'errorLogin', N'Wrong User or Pass')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmAltaPaciente', N'Create Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmAyuda', N'Help')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmBuscarEjer', N'Find Training')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmConsulta', N'Consult')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmConsultaPatologias', N'Select Pathologies and injuries')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmConsultarEntrenamiento', N'Select Training')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmConsultarPaciente', N'Select Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmConsultaTratamientos', N'Select Treatments')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmCopiaSeguridad', N'Backup and Restore')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmDigito', N'Check Digit Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmModificarPaciente', N'Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmPatologias', N'Pathologies and injuries')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'frmTratamientos', N'Treatments')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblApellido', N'Surname')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblBuscar', N'Search')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblCantidad', N'Quantity')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblCarpeta', N'Folder')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblClave', N'Key')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblCopias', N'Backups')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblCorreo', N'Mail')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblDescripcion', N'Description')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblDesde', N'From')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblDetalle', N'Detail')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblDni', N'Dni')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblDVH', N'Check Digit Horizontal')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblDVV', N'Check Digit Vertical')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblEdad', N'Birthdate')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblEntrenamientos', N'Training')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblEspaniol', N'Spanish')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblFecha', N'Date')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblGrupo', N'Group')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblHasta', N'To')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblIngles', N'English')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblLog', N'Log')
GO
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblMenu', N'Menu')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblNombre', N'Name')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblObservaciones', N'Observations')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPaciente', N'Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPadre', N'Father')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPalabrasClave', N'Keywords')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPalabrasClaveInfo', N'Comma Separated words, Used to filter in the Medical Consultation')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPassword', N'Password')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPassword2', N'Repeat Password')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPerfiles', N'Profile')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPersona', N'Person')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblPersonales', N'Personal Data')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblRepeticiones', N'Repetitions')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblResultado', N'Result')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblResumen', N'Summary')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblRol', N'Rol')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblRolUsuario', N'User Rol')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblTexto', N'Text')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblTraduccion', N'Translate')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblUsuario', N'User')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'lblUsuarios', N'Users')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'loginDescripcion', N'MANAGEMENT SYSTEM FOR SPORTS KINESIOLOGY OFFICE')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuAdmBackup', N'Backup Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuAdmBitacora', N'View Log')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuAdminIdioma', N'Languaje Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuAdministracion', N'Magnament')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuAdmPerfiles', N'Profile Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuAdmRoles', N'Rol Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuAdmUsuarios', N'User Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuCerrarSesion', N'Close Sesion')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuEntrenamientos', N'Training Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuEntrenamientosEjercicios', N'Exercises Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuEntrenamientosEntrenamientos', N'Training Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuGestionPacientes', N'Patient Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuIdioma', N'Languaje')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuMenu', N'Menu')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuPacienteAlta', N'Create Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuPacienteConsulta', N'Consultation Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuPacienteHistorial', N'History')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuPacienteModificacion', N'Consult Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'MenuPatologias', N'Pathologies Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'menuSalir', N'Exit')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'MenuTratamientos', N'Treatments Management')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgBackNo', N'Backup Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgBackOk', N'Backup Ok')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgCalculandoDVV', N'Calc DVV Table: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgCerrarSesion', N'Do you want to close the Session?')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgComprobando', N'Testing Table: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgEnviarPass', N'Password send by Email (Not Implemented)')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgError', N'Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorAlta', N'Insert Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorAltaPaciente', N'Error insert Patient')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorArchivoNoExiste', N'File Not Found')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgERrorMail', N'Mail Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorPassNoIguales', N'Password Not equal')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorRegistro', N'Error on register: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorUnItem', N'Select almost one Item')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorVerificarDV', N'Error verifying the verification digits, please contact an administrator.')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgErrorVerificarDV2', N'Error verifying the verification digits.')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgFaltaCompletar', N'Required Field')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgFaltaCompletarTitulo', N'Validation Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgLargoPass', N'Passwords must be at least 6 characters long.')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgLargoUsr', N'Users must be at least 6 characters long.')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgNofiltro', N'No Filter selected')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgOperacionOk', N'Successful Operation')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgPacienteNoEncontrado', N'Patient not found')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgRegistro', N'Register: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgRegistrosCalculados', N'Calculated Registers: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgRegistrosComprobados', N'Tested Registers: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgRestoreNo', N'Restore Error')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgRestoreOk', N'Restore Ok')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgResultado', N'Result: ')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'msgVerificandoDVV', N'Checking DVV')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (2, N'recuperarpass', N'Password Recovery')
SET IDENTITY_INSERT [dbo].[Patologia] ON 

INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (1, N'Tendinitis', N'Afección en la que se inflama el tejido que conecta el músculo con el hueso.', N'Brazo, Mano, Pierna, Tobillo, Pie')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (2, N'Hernias discales', N'Afección caracterizada por un problema en el disco cartilaginoso ubicado entre los huesos de la columna vertebral.', N'Cadera, Espalda')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (3, N'Ciática o síndrome del piramidal', N'Trastorno en el que el músculo piriforme ubicado en las nalgas irrita el nervio ciático.', N'Espalda, Cintura')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (4, N'Dolor de espalda y cuello', N'La mayoría de las veces el dolor en la espalda es de origen muscular y surge debido al cansancio, levantamiento de pesas o mala postura, y puede ser solucionada con medidas simples como compresas calientes y estiramientos.', N'Espalda, Cuello')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (5, N'Esguinces', N'Estiramiento o rasgadura de los ligamentos, el tejido fibroso que conecta los huesos y las articulaciones.', N'Rodilla, Tobillo, Pie')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (6, N'Síndrome del tunel carpiano', N'Entumecimiento y hormigueo en la mano y el brazo ocasionados por el pinzamiento de un nervio en la muñeca.', N'Mano, Brazo')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (7, N'Desgarros y Contracturas', N'La contractura es una contracción mantenida en el tiempo sin ruptura del tejido muscular. En cambio, el desgarro es la ruptura de pequeñas o grandes fibras musculares', N'Brazo, Hombro, Pierna, Rodilla')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (8, N'Fascitis plantar', N'Inflamación del tejido conectivo grueso que une el talón con los dedos del pie.', N'Pie')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (9, N'Luxaciones', N'Lesión en la que una articulación se desplaza de su posición normal.', N'Hombro, Pierna, Rodilla, Tobillo, Cadera')
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (10, N'Artrosis', N'Tipo de artritis que se produce cuando el tejido flexible en los extremos de los huesos se desgasta.', NULL)
INSERT [dbo].[Patologia] ([id], [nombre], [descripcion], [palabras]) VALUES (11, N'Escoliosis', N'Curvatura lateral de la columna vertebral.', N'Columna, Espalda')
SET IDENTITY_INSERT [dbo].[Patologia] OFF
SET IDENTITY_INSERT [dbo].[Perfil] ON 

INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (1, N'Usuario', 0)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (2, N'Administrador
', 0)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (3, N'Dba', 0)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (4, N'Consulta', 0)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (5, N'MenuPacienteAlta', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (6, N'MenuPacienteModificar', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (7, N'MenuConsulta', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (8, N'MenuEntrenamientos', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (9, N'MenuEjercicios', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (10, N'MenuEntrenamientos', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (11, N'MenuPatologias', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (12, N'MenuTratamientos', 1)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (13, N'MenuUsuarios', 2)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (14, N'MenuRoles', 2)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (15, N'MenuPerfiles', 2)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (17, N'MenuIdioma', 2)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (18, N'MenuBitacora', 3)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (19, N'MenuCopiaSeguridad', 3)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (20, N'MenuDigitoVerificador', 3)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (21, N'MenuPacienteAlta', 4)
INSERT [dbo].[Perfil] ([id], [nombre], [padre]) VALUES (22, N'MenuPacienteModificar', 4)
SET IDENTITY_INSERT [dbo].[Perfil] OFF
SET IDENTITY_INSERT [dbo].[Tratamiento] ON 

INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (1, N'MEP', N'La micro electrólisis percutánea es una técnica que consiste en la aplicación de una corriente con componente galvánico en forma percutánea por medio de una aguja hasta el tejido en cuestión. Esto produce una respuesta inflamatoria controlada activando la auto-reparación de los tejidos.', N'Cuello, Espalda, Brazo, Pierna')
INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (2, N'Vendajes Funcionales', N'Vendajes Funcionales, Neuromusculares (Taping Neuromuscular) y Estabilizadores.', N'Cuello, Espalda, Hombro, Rodilla, Pierna')
INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (3, N'Masoterapia', N'La masoterapia se puede definir como el uso de distintas técnicas de masaje con fines terapéuticos.', N'Mano, Brazo, Espalda, Cuello, Pierna, Pie, Abdomen')
INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (4, N'Quiropraxia', N'La Quiropraxia es una disciplina que visualiza al cuerpo en su globalidad (rastreando disfunciones) y mediante técnicas manuales busca optimizar el funcionamiento del sistema mio-neuro-osteo-articular. Se aplican técnicas de ajustes articulares (tanto vertebrales como de las demás articulaciones del cuerpo) y de tejidos blandos (músculos, tendones, fascias, etc).', N'Espalda, Columna')
INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (5, N'Tecaterapia (Radiofrecuencia)', N'La tecaterapia es un tratamiento que logra aumentar la temperatura de los tejidos por medio del paso de una corriente eléctrica. Este aumento de la temperatura conlleva un aumento del metabolismo celular, lo que promueve la recuperación de los tejidos dañados.
Esta terapéutica tiene un amplio campo de acción en la traumatología y sobre todo en los problemas que afectan las partes blandas, es decir músculos, tendones y ligamentos.
Gran eficacia y disminución en los tiempos de recuperación de lesiones.', N'Cuello, Espalda, Brazo, Pierna')
INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (6, N'Acupuntura', N'La acupuntura es una forma de medicina alternativa? en la que se insertan agujas en el cuerpo.?', N'Espalda, Cuerpo, Cuello, Brazo, Pierna, Pie')
INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (7, N'Electroestimulación', N'Se trata del uso de aparatos que, mediante impulsos eléctricos, provocan contracciones musculares y, como consecuencia, un efecto similar al que se obtendría ejercitando los músculos.', N'Brazo, Pierna, Abdomen')
INSERT [dbo].[Tratamiento] ([id], [nombre], [descripcion], [palabras]) VALUES (8, N'Ultrasonido', N'La aplicación de ultrasonido terapéutico en tejidos lesionados acelera la tasa de curación y mejora la calidad de la reparación de lesiones de ligamentos, tendones.', N'Brazo, Pierna, Codo, Rodilla, Tobillo, Pie')
SET IDENTITY_INSERT [dbo].[Tratamiento] OFF
INSERT [dbo].[Usuario] ([usuario], [password], [correo], [nombre], [apellido], [dni], [DVH]) VALUES (N'Administrador', N'jU+bL0A+I/WZq/JIy9d6/lREd0A=', N'administrador@kineapp.com', N'Admin', N'Admin', 12345678, N'7')
INSERT [dbo].[UsuarioPerfil] ([usuario], [perfil]) VALUES (N'Administrador', 2)
INSERT [dbo].[UsuarioPerfil] ([usuario], [perfil]) VALUES (N'Administrador', 3)
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY([paciente])
REFERENCES [dbo].[Paciente] ([dni])
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Paciente]
GO
ALTER TABLE [dbo].[ConsultaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ConsultaPatEntre_Consulta] FOREIGN KEY([id_consulta])
REFERENCES [dbo].[Consulta] ([id])
GO
ALTER TABLE [dbo].[ConsultaDetalle] CHECK CONSTRAINT [FK_ConsultaPatEntre_Consulta]
GO
ALTER TABLE [dbo].[EntrenamientoEjercicio]  WITH CHECK ADD  CONSTRAINT [FK_EntrenamientoEjercicio_Ejercicio] FOREIGN KEY([id_ejercicio])
REFERENCES [dbo].[Ejercicio] ([id])
GO
ALTER TABLE [dbo].[EntrenamientoEjercicio] CHECK CONSTRAINT [FK_EntrenamientoEjercicio_Ejercicio]
GO
ALTER TABLE [dbo].[EntrenamientoEjercicio]  WITH CHECK ADD  CONSTRAINT [FK_EntrenamientoEjercicio_Entrenamiento] FOREIGN KEY([id_entrenamiento])
REFERENCES [dbo].[Entrenamiento] ([id])
GO
ALTER TABLE [dbo].[EntrenamientoEjercicio] CHECK CONSTRAINT [FK_EntrenamientoEjercicio_Entrenamiento]
GO
ALTER TABLE [dbo].[IdiomaDetalle]  WITH CHECK ADD  CONSTRAINT [FK_IdiomaDetalle_Idioma] FOREIGN KEY([idioma])
REFERENCES [dbo].[Idioma] ([id])
GO
ALTER TABLE [dbo].[IdiomaDetalle] CHECK CONSTRAINT [FK_IdiomaDetalle_Idioma]
GO
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPerfil_Perfil] FOREIGN KEY([perfil])
REFERENCES [dbo].[Perfil] ([id])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_UsuarioPerfil_Perfil]
GO
ALTER TABLE [dbo].[UsuarioPerfil]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioPerfil_Usuario] FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([usuario])
GO
ALTER TABLE [dbo].[UsuarioPerfil] CHECK CONSTRAINT [FK_UsuarioPerfil_Usuario]
GO
