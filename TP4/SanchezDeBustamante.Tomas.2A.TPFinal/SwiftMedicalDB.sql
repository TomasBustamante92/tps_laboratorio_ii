USE [master]
GO
/****** Object:  Database [SwiftMedicalDB]    Script Date: 19/6/2022 11:45:10 ******/
CREATE DATABASE [SwiftMedicalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SwiftMedicalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SwiftMedicalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SwiftMedicalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\SwiftMedicalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SwiftMedicalDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SwiftMedicalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SwiftMedicalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SwiftMedicalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SwiftMedicalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SwiftMedicalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SwiftMedicalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET RECOVERY FULL 
GO
ALTER DATABASE [SwiftMedicalDB] SET  MULTI_USER 
GO
ALTER DATABASE [SwiftMedicalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SwiftMedicalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SwiftMedicalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SwiftMedicalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SwiftMedicalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SwiftMedicalDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SwiftMedicalDB', N'ON'
GO
ALTER DATABASE [SwiftMedicalDB] SET QUERY_STORE = OFF
GO
USE [SwiftMedicalDB]
GO
/****** Object:  Table [dbo].[Duenios]    Script Date: 19/6/2022 11:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duenios](
	[id] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[telefono] [int] NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Duenios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mascotas]    Script Date: 19/6/2022 11:45:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mascotas](
	[id] [int] NOT NULL,
	[tipo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[raza] [varchar](50) NOT NULL,
	[historial] [varchar](max) NOT NULL,
	[idDuenio] [int] NOT NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (1, N'Stephen King', 42513659, N'Misery 4522', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (3, N'Will Smith', 458753254, N'Estados Unidos 7775', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (4, N'Madonna', 4501254, N'Londres 653', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (17, N'Goku Kakarotto', 45875621, N'Namekusei 123', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (19, N'Pepe Argeto', 41203590, N'Av. Santa Fe 5642', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (21, N'Ash Ketchup', 48885201, N'Pueblo Paleta 4452', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (22, N'Steven Spielberg', 41252120, N'Estados Unidos 1253', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (23, N'Harry Potter', 42012365, N'Hogwards 9 3/4', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (24, N'Super Mario', 42012548, N'Mushroom Kingdom 4650', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (25, N'Neo el Elegido', 42135458, N'Matrix 4567', 1)
GO
INSERT [dbo].[Duenios] ([id], [nombre], [telefono], [direccion], [activo]) VALUES (26, N'Prueba borrar', 2, N'2', 0)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (1, N'Perro', N'Soy leyenda', 5, N'Ovejero aleman', N'Fecha: 19/6/2022 

Tiene un par de rasguños 

------------------------------------ 

historial', 3, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (2, N'Perro', N'Cujo', 5, N'Bulldog', N'Fecha: 19/6/2022 

tiene rabia

------------------------------------ 

', 1, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (26, N'Ñandú', N'Hedwig', 2, N'Buho', N'Fecha: 19/6/2022 

Desaparece por un par de dias

------------------------------------ 

Fecha: 16/6/2022 

se

------------------------------------ 

', 23, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (29, N'Perro', N'Indiana Jones', 4, N'Ovejero australiano', N'Fecha: 19/6/2022 

Hiperactivo, desentierra muchas cosas

------------------------------------ 

', 22, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (30, N'Ñandú', N'Jaws', 10, N'Tiburón', N'Fecha: 19/6/2022 

Come gente

------------------------------------ 

', 22, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (31, N'Perro', N'Yoshi', 2, N'Akita', N'Fecha: 19/6/2022 

Se lastimó la pata de tanto saltar

------------------------------------ 

', 24, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (32, N'Ñandú', N'Pikachu', 323, N'Amarillus maximus', N'Fecha: 19/6/2022 

Tira descarga

------------------------------------ 

', 21, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (33, N'Perro', N'Krillin', 2, N'Bulldog', N'Fecha: 19/6/2022 

Se está quedando pelado

------------------------------------ 

', 17, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (35, N'Gato', N'Cristi Aguilera', 2, N'Siames', N'Fecha: 19/6/2022 

Hay que castrar

------------------------------------ 

', 4, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (38, N'Perro', N'Fatiga', 10, N'Ovejero Aleman', N'Fecha: 19/6/2022 

Tiene fiakita

------------------------------------ 

', 19, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (39, N'Gato', N'Deja Vu', 2, N'negro', N'Fecha: 19/6/2022 

Aparece 2 veces en el mismo pasillo

------------------------------------ 

', 25, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (40, N'Perro', N'Morfeo', 21, N'Labrador negro', N'Fecha: 19/6/2022 

consumió pastilla roja

------------------------------------ 

', 25, 1)
GO
INSERT [dbo].[Mascotas] ([id], [tipo], [nombre], [edad], [raza], [historial], [idDuenio], [activo]) VALUES (41, N'Gato', N'Mini Prueba', 2, N'2', N'Fecha: 19/6/2022 

se rompio esa prueba

------------------------------------ 

', 26, 0)
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Duenios] FOREIGN KEY([idDuenio])
REFERENCES [dbo].[Duenios] ([id])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Duenios]
GO
USE [master]
GO
ALTER DATABASE [SwiftMedicalDB] SET  READ_WRITE 
GO
