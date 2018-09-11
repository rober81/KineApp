USE [KineApp]
GO
ALTER TABLE [dbo].[UsuarioPerfil] DROP CONSTRAINT [FK_UsuarioPerfil_Usuario]
GO
ALTER TABLE [dbo].[UsuarioPerfil] DROP CONSTRAINT [FK_UsuarioPerfil_Perfil]
GO
ALTER TABLE [dbo].[TratamientoEntrenamiento] DROP CONSTRAINT [FK_TratamientoEntrenamiento_Tratamiento]
GO
ALTER TABLE [dbo].[TratamientoEntrenamiento] DROP CONSTRAINT [FK_TratamientoEntrenamiento_Entrenamiento]
GO
ALTER TABLE [dbo].[PatologiaTratamiento] DROP CONSTRAINT [FK_PatologiaTratamiento_Tratamiento]
GO
ALTER TABLE [dbo].[PatologiaTratamiento] DROP CONSTRAINT [FK_PatologiaTratamiento_Patologia]
GO
ALTER TABLE [dbo].[IdiomaDetalle] DROP CONSTRAINT [FK_IdiomaDetalle_Idioma]
GO
ALTER TABLE [dbo].[EntrenamientoEjercicio] DROP CONSTRAINT [FK_EntrenamientoEjercicio_Entrenamiento]
GO
ALTER TABLE [dbo].[EntrenamientoEjercicio] DROP CONSTRAINT [FK_EntrenamientoEjercicio_Ejercicio]
GO
ALTER TABLE [dbo].[Consulta] DROP CONSTRAINT [FK_Consulta_Paciente]
GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[UsuarioPerfil]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Usuario]
GO
/****** Object:  Table [dbo].[TratamientoEntrenamiento]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[TratamientoEntrenamiento]
GO
/****** Object:  Table [dbo].[Tratamiento]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Tratamiento]
GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Perfil]
GO
/****** Object:  Table [dbo].[PatologiaTratamiento]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[PatologiaTratamiento]
GO
/****** Object:  Table [dbo].[Patologia]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Patologia]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Paciente]
GO
/****** Object:  Table [dbo].[IdiomaDetalle]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[IdiomaDetalle]
GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Idioma]
GO
/****** Object:  Table [dbo].[EntrenamientoEjercicio]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[EntrenamientoEjercicio]
GO
/****** Object:  Table [dbo].[Entrenamiento]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Entrenamiento]
GO
/****** Object:  Table [dbo].[Ejercicio]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Ejercicio]
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[DVV]
GO
/****** Object:  Table [dbo].[CopiaDeSeguridad]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[CopiaDeSeguridad]
GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 10/9/2018 23:59:26 ******/
DROP TABLE [dbo].[Consulta]
GO
/****** Object:  StoredProcedure [dbo].[Usuario_modificarPass]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[Usuario_modificarPass]
GO
/****** Object:  StoredProcedure [dbo].[Usuario_modificar]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[Usuario_modificar]
GO
/****** Object:  StoredProcedure [dbo].[Usuario_login]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[Usuario_login]
GO
/****** Object:  StoredProcedure [dbo].[Usuario_leer]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[Usuario_leer]
GO
/****** Object:  StoredProcedure [dbo].[Usuario_buscar]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[Usuario_buscar]
GO
/****** Object:  StoredProcedure [dbo].[Usuario_alta]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[Usuario_alta]
GO
/****** Object:  StoredProcedure [dbo].[IdiomaDetalle_leer]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[IdiomaDetalle_leer]
GO
/****** Object:  StoredProcedure [dbo].[Idioma_leer]    Script Date: 10/9/2018 23:59:26 ******/
DROP PROCEDURE [dbo].[Idioma_leer]
GO
/****** Object:  StoredProcedure [dbo].[Idioma_leer]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Idioma_leer]
 as
begin
select * from idioma
end



GO
/****** Object:  StoredProcedure [dbo].[IdiomaDetalle_leer]    Script Date: 10/9/2018 23:59:26 ******/
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
end

GO
/****** Object:  StoredProcedure [dbo].[Usuario_alta]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario_alta]
@usuario varchar(50),@pass varchar(50),@nombre varchar(50),
@apellido varchar(50),@correo varchar(50),@edad int, @dni int, @dvh varchar(50) as
begin
insert into Usuario values (@usuario,@pass, @correo, @nombre,@apellido,@edad, @dni,@dvh);
end

GO
/****** Object:  StoredProcedure [dbo].[Usuario_buscar]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Usuario_buscar]
@usuario varchar(50) as
begin
select * from usuario where usuario.usuario = @usuario;

end
GO
/****** Object:  StoredProcedure [dbo].[Usuario_leer]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[Usuario_leer]
 as
begin
select * from usuario
end
GO
/****** Object:  StoredProcedure [dbo].[Usuario_login]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Usuario_login]
@usuario varchar(50), @pass varchar(50) as
begin
select * from usuario where usuario.usuario = @usuario and usuario.password = @pass;

end




GO
/****** Object:  StoredProcedure [dbo].[Usuario_modificar]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Usuario_modificar]
@usuario varchar(50),@pass varchar(50),@nombre varchar(50),
@apellido varchar(50),@correo varchar(50),@edad int, @dni int, @dvh varchar(50) as
begin
update Usuario set 
password = @pass, correo = @correo, nombre = @nombre, apellido = @apellido, edad = @edad, dni= @dni, dvh = @dvh 
where usuario = @usuario
end


GO
/****** Object:  StoredProcedure [dbo].[Usuario_modificarPass]    Script Date: 10/9/2018 23:59:26 ******/
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
end


GO
/****** Object:  Table [dbo].[Consulta]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consulta](
	[id] [int] NOT NULL,
	[paciente] [int] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[paciente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CopiaDeSeguridad]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CopiaDeSeguridad](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[fecha] [date] NULL,
	[DVH] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CopiaDeSeguridad] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DVV]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DVV](
	[id] [int] NOT NULL,
	[tabla] [varchar](50) NOT NULL,
	[DVV] [varchar](50) NOT NULL,
	[DVH] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DVV] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ejercicio]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ejercicio](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[cantidad] [varchar](50) NULL,
	[repeticiones] [varchar](50) NULL,
 CONSTRAINT [PK_Ejercicio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entrenamiento]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entrenamiento](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_Entrenamiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntrenamientoEjercicio]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntrenamientoEjercicio](
	[id_entrenamiento] [int] NOT NULL,
	[id_ejercicio] [int] NOT NULL,
 CONSTRAINT [PK_EntrenamientoEjercicio] PRIMARY KEY CLUSTERED 
(
	[id_entrenamiento] ASC,
	[id_ejercicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Idioma]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Idioma](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Idioma] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IdiomaDetalle]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paciente](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[edad] [int] NULL,
	[dni] [int] NULL,
	[DVH] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patologia]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patologia](
	[id] [int] NOT NULL,
	[consulta] [int] NOT NULL,
	[sector] [varchar](50) NOT NULL,
	[detalle] [varchar](50) NULL,
 CONSTRAINT [PK_Patologia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatologiaTratamiento]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatologiaTratamiento](
	[id_patologia] [int] NOT NULL,
	[id_tratamiento] [int] NOT NULL,
 CONSTRAINT [PK_PatologiaTratamiento] PRIMARY KEY CLUSTERED 
(
	[id_patologia] ASC,
	[id_tratamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Perfil]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfil](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NULL,
	[padre] [int] NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tratamiento]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tratamiento](
	[id] [int] NOT NULL,
	[observaciones] [varchar](50) NULL,
 CONSTRAINT [PK_Tratamiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TratamientoEntrenamiento]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TratamientoEntrenamiento](
	[id_tratamiento] [int] NOT NULL,
	[id_entrenamiento] [int] NOT NULL,
 CONSTRAINT [PK_TratamientoEntrenamiento] PRIMARY KEY CLUSTERED 
(
	[id_tratamiento] ASC,
	[id_entrenamiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[edad] [int] NULL,
	[dni] [int] NULL,
	[DVH] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPerfil]    Script Date: 10/9/2018 23:59:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioPerfil](
	[usuario] [varchar](50) NOT NULL,
	[perfil] [int] NOT NULL,
 CONSTRAINT [PK_UsuarioPerfil] PRIMARY KEY CLUSTERED 
(
	[perfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Idioma] ([id], [nombre]) VALUES (1, N'Español')
INSERT [dbo].[Idioma] ([id], [nombre]) VALUES (2, N'Ingles')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'aceptar', N'Aceptar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'cancelar', N'Cancelar')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'correo', N'Correo')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'descripcionApp', N'SISTEMA DE GESTIÓN PARA CONSULTORIO DE KINESIOLOGÍA DEPORTIVA')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menu', N'Menú')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmBackup', N'Gestión de Copia de Seguridad')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmBitacora', N'Consultar Bitácora')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdministracion', N'Administración')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmPerfiles', N'Gestión de Perfiles')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmRoles', N'Gestión de Roles')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuAdmUsuarios', N'Gestión de Usuarios')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuCerrarSesion', N'Cerrar Sesión')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuEntrenamientos', N'Gestión de Entrenamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuEntrenamientosEjercicios', N'Ejercicios')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuEntrenamientosEntrenamientos', N'Entrenamientos')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuGestionPacientes', N'Gestión de Pacientes')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuIdioma', N'Idioma')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuIdiomaIngles', N'Ingles')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuIdiomaSpanish', N'Español')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteAlta', N'Alta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteConsulta', N'Consulta')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteHistorial', N'Historial')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuPacienteModificacion', N'Modificación')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'menuSalir', N'Salir')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'password', N'Contraseña')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'recuperarpass', N'Recuperar Contraseña')
INSERT [dbo].[IdiomaDetalle] ([idioma], [clave], [texto]) VALUES (1, N'usuario', N'Usuario')
INSERT [dbo].[Usuario] ([usuario], [password], [correo], [nombre], [apellido], [edad], [dni], [DVH]) VALUES (N'rober', N'Xz+kFuvnhT+uo78vZpqRmEkbvj0=', N'robertopiombi@gmail.com', N'Roberto', N'Piombi', 37, 12345678, N'1')
ALTER TABLE [dbo].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_Paciente] FOREIGN KEY([paciente])
REFERENCES [dbo].[Paciente] ([id])
GO
ALTER TABLE [dbo].[Consulta] CHECK CONSTRAINT [FK_Consulta_Paciente]
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
ALTER TABLE [dbo].[PatologiaTratamiento]  WITH CHECK ADD  CONSTRAINT [FK_PatologiaTratamiento_Patologia] FOREIGN KEY([id_patologia])
REFERENCES [dbo].[Patologia] ([id])
GO
ALTER TABLE [dbo].[PatologiaTratamiento] CHECK CONSTRAINT [FK_PatologiaTratamiento_Patologia]
GO
ALTER TABLE [dbo].[PatologiaTratamiento]  WITH CHECK ADD  CONSTRAINT [FK_PatologiaTratamiento_Tratamiento] FOREIGN KEY([id_tratamiento])
REFERENCES [dbo].[Tratamiento] ([id])
GO
ALTER TABLE [dbo].[PatologiaTratamiento] CHECK CONSTRAINT [FK_PatologiaTratamiento_Tratamiento]
GO
ALTER TABLE [dbo].[TratamientoEntrenamiento]  WITH CHECK ADD  CONSTRAINT [FK_TratamientoEntrenamiento_Entrenamiento] FOREIGN KEY([id_entrenamiento])
REFERENCES [dbo].[Entrenamiento] ([id])
GO
ALTER TABLE [dbo].[TratamientoEntrenamiento] CHECK CONSTRAINT [FK_TratamientoEntrenamiento_Entrenamiento]
GO
ALTER TABLE [dbo].[TratamientoEntrenamiento]  WITH CHECK ADD  CONSTRAINT [FK_TratamientoEntrenamiento_Tratamiento] FOREIGN KEY([id_tratamiento])
REFERENCES [dbo].[Tratamiento] ([id])
GO
ALTER TABLE [dbo].[TratamientoEntrenamiento] CHECK CONSTRAINT [FK_TratamientoEntrenamiento_Tratamiento]
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
