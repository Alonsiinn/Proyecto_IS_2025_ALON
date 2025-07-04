USE [master]
GO
/****** Object:  Database [P_Ing_Sof_Alonso25]    Script Date: 22/6/2025 23:43:36 ******/
CREATE DATABASE [P_Ing_Sof_Alonso25]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'P_Ing_Sof_Alonso25', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\P_Ing_Sof_Alonso25.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'P_Ing_Sof_Alonso25_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\P_Ing_Sof_Alonso25_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [P_Ing_Sof_Alonso25].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET ARITHABORT OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET  DISABLE_BROKER 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET  MULTI_USER 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET DB_CHAINING OFF 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET QUERY_STORE = ON
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [P_Ing_Sof_Alonso25]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Categoria_Nombre] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[IdPedido] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[IdFactura] [int] IDENTITY(1,1) NOT NULL,
	[IdPedido] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[MontoTotal] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_Factura] PRIMARY KEY CLUSTERED 
(
	[IdFactura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Factura_Pedido] UNIQUE NONCLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LataPintura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LataPintura](
	[IdProducto] [int] NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[CapacidadL] [decimal](5, 2) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
	[TipoBase] [nvarchar](20) NULL,
 CONSTRAINT [PK_LataPintura] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notificacion]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacion](
	[IdNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[Mensaje] [nvarchar](255) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[Leida] [bit] NOT NULL,
 CONSTRAINT [PK_Notificacion] PRIMARY KEY CLUSTERED 
(
	[IdNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[IdPedido] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Total] [decimal](10, 2) NOT NULL,
	[Estado] [tinyint] NOT NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[IdPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[EsCompuesto] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso_Componente]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso_Componente](
	[IdPadre] [int] NOT NULL,
	[IdHijo] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPadre] ASC,
	[IdHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[IdSucursal] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC,
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](150) NOT NULL,
	[Ciudad] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Sucursal_Nombre_Ciudad] UNIQUE NONCLUSTERED 
(
	[Nombre] ASC,
	[Ciudad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](150) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Telefono] [varchar](100) NOT NULL,
	[Direccion_Fiscal] [varchar](100) NOT NULL,
	[DNI] [varchar](100) NOT NULL,
	[Tipo_Usuario] [varchar](100) NOT NULL,
	[Abierta] [bit] NOT NULL,
	[Bloqueada] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Permiso]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Permiso](
	[ID_Usuario] [int] NOT NULL,
	[IdPermiso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Sucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Sucursal](
	[ID_Usuario] [int] NOT NULL,
	[IdSucursal] [int] NOT NULL,
 CONSTRAINT [PK_Usuario_Sucursal] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC,
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Factura] ADD  CONSTRAINT [DF_Factura_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Notificacion] ADD  CONSTRAINT [DF_Notif_Fecha]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Notificacion] ADD  DEFAULT ((0)) FOR [Leida]
GO
ALTER TABLE [dbo].[Pedido] ADD  CONSTRAINT [DF_Pedido_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Pedido] ADD  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[Permiso] ADD  DEFAULT ((0)) FOR [EsCompuesto]
GO
ALTER TABLE [dbo].[Stock] ADD  DEFAULT ((0)) FOR [Cantidad]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([IdPedido])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Producto]
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD  CONSTRAINT [FK_Factura_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([IdPedido])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Factura] CHECK CONSTRAINT [FK_Factura_Pedido]
GO
ALTER TABLE [dbo].[LataPintura]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notificacion]  WITH CHECK ADD  CONSTRAINT [FK_Notificacion_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notificacion] CHECK CONSTRAINT [FK_Notificacion_Usuario]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario]
GO
ALTER TABLE [dbo].[Permiso_Componente]  WITH CHECK ADD FOREIGN KEY([IdHijo])
REFERENCES [dbo].[Permiso] ([IdPermiso])
GO
ALTER TABLE [dbo].[Permiso_Componente]  WITH CHECK ADD FOREIGN KEY([IdPadre])
REFERENCES [dbo].[Permiso] ([IdPermiso])
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Producto]
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([IdSucursal])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Sucursal]
GO
ALTER TABLE [dbo].[Usuario_Permiso]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Usuario_Permiso]  WITH CHECK ADD FOREIGN KEY([IdPermiso])
REFERENCES [dbo].[Permiso] ([IdPermiso])
GO
ALTER TABLE [dbo].[Usuario_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Sucursal_Sucursal] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursal] ([IdSucursal])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario_Sucursal] CHECK CONSTRAINT [FK_Usuario_Sucursal_Sucursal]
GO
ALTER TABLE [dbo].[Usuario_Sucursal]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Sucursal_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Usuario_Sucursal] CHECK CONSTRAINT [FK_Usuario_Sucursal_Usuario]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD CHECK  (([Cantidad]>(0)))
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD CHECK  (([PrecioUnitario]>=(0)))
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD CHECK  (([MontoTotal]>=(0)))
GO
ALTER TABLE [dbo].[LataPintura]  WITH CHECK ADD CHECK  (([CapacidadL]>(0)))
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD CHECK  (([Total]>=(0)))
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD CHECK  (([Precio]>=(0)))
GO
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD CHECK  (([Cantidad]>=(0)))
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPermiso]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarPermiso]
    @Nombre VARCHAR(100),
    @EsCompuesto BIT,
    @IdPermiso INT OUTPUT
AS
BEGIN
    INSERT INTO Permiso (Nombre, EsCompuesto)
    VALUES (@Nombre, @EsCompuesto);

    SET @IdPermiso = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarUsuario]
    @Username VARCHAR(50),
    @Password VARCHAR(150),
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Email VARCHAR(100),
    @FechaNacimiento DATE,
    @Telefono VARCHAR(100),
    @DireccionFiscal VARCHAR(100),
    @DNI VARCHAR(100),
    @TipoUsuario VARCHAR(100),
    @IdUsuario INT OUTPUT
AS
BEGIN
    INSERT INTO Usuario (Username, Password, Nombre, Apellido, Email, FechaNacimiento, Telefono, Direccion_Fiscal, DNI, Tipo_Usuario, Abierta, Bloqueada)
    VALUES (@Username, @Password, @Nombre, @Apellido, @Email, @FechaNacimiento, @Telefono, @DireccionFiscal, @DNI, @TipoUsuario, 0, 0);

    SET @IdUsuario = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerCatalogoSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerCatalogoSucursal]
    @IdSucursal INT
AS
BEGIN
    SELECT 
        P.IdProducto,
        P.Nombre,
        P.Descripcion,
        P.Precio,
        L.CapacidadL,
        L.Color,
        L.TipoBase,
        L.Marca AS TipoLataPintura
    FROM Stock S
    INNER JOIN Producto P ON S.IdProducto = P.IdProducto
    LEFT JOIN LataPintura L ON P.IdProducto = L.IdProducto
    WHERE S.IdSucursal = @IdSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarCategoria]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarCategoria] 
    @IdCategoria INT,
    @NuevoNombre NVARCHAR(100),
    @NuevaDescripcion NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Categoria
    SET Nombre = @NuevoNombre,
        Descripcion = @NuevaDescripcion
    WHERE IdCategoria = @IdCategoria;
    -- Opcional: RETURN @@ROWCOUNT para indicar si se actualizó alguna fila
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarDetallePedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarDetallePedido] 
    @IdPedido INT,
    @IdProducto INT,
    @NuevaCantidad INT = NULL,
    @NuevoPrecioUnitario DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE DetallePedido
    SET 
       Cantidad = ISNULL(@NuevaCantidad, Cantidad),
       PrecioUnitario = ISNULL(@NuevoPrecioUnitario, PrecioUnitario)
    WHERE IdPedido = @IdPedido AND IdProducto = @IdProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarFactura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarFactura] 
    @IdFactura INT,
    @NuevoMontoTotal DECIMAL(10,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Factura
    SET MontoTotal = ISNULL(@NuevoMontoTotal, MontoTotal),
        -- En caso de necesitar actualizar IdPedido o Fecha, podrían incluirse parámetros
        Fecha = Fecha  -- (no se cambia la fecha aquí; agregar parámetro si se desea)
    WHERE IdFactura = @IdFactura;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarLataPintura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarLataPintura] 
    @IdProducto INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255) = NULL,
    @Precio DECIMAL(10,2),
    @IdCategoria INT,
    @Color NVARCHAR(50),
    @CapacidadL DECIMAL(5,2),
    @Marca NVARCHAR(50),
    @TipoBase NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;
        -- Actualizar datos base del Producto
        UPDATE Producto
        SET Nombre = @Nombre,
            Descripcion = @Descripcion,
            Precio = @Precio,
            IdCategoria = @IdCategoria
        WHERE IdProducto = @IdProducto;
        -- Actualizar datos específicos de LataPintura
        UPDATE LataPintura
        SET Color = @Color,
            CapacidadL = @CapacidadL,
            Marca = @Marca,
            TipoBase = @TipoBase
        WHERE IdProducto = @IdProducto;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarNotificacion]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarNotificacion] 
    @IdNotificacion INT,
    @MarcadaLeida BIT = NULL,
    @NuevoMensaje NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Notificacion
    SET 
       Leida = ISNULL(@MarcadaLeida, Leida),
       Mensaje = ISNULL(@NuevoMensaje, Mensaje)
    WHERE IdNotificacion = @IdNotificacion;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarPedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarPedido] 
    @IdPedido INT,
    @NuevoTotal DECIMAL(10,2) = NULL,
    @NuevoEstado TINYINT = NULL,
    @NuevoIdUsuario INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Pedido
    SET 
        Total = ISNULL(@NuevoTotal, Total),       -- si se pasa NULL, mantiene valor anterior
        Estado = ISNULL(@NuevoEstado, Estado),
        ID_Usuario = ISNULL(@NuevoIdUsuario, ID_Usuario)
    WHERE IdPedido = @IdPedido;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarProducto]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarProducto] 
    @IdProducto INT,
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255) = NULL,
    @Precio DECIMAL(10,2),
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Producto
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Precio = @Precio,
        IdCategoria = @IdCategoria
    WHERE IdProducto = @IdProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarStock]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarStock] 
    @IdSucursal INT,
    @IdProducto INT,
    @NuevaCantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Stock
    SET Cantidad = @NuevaCantidad
    WHERE IdSucursal = @IdSucursal AND IdProducto = @IdProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ActualizarSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ActualizarSucursal] 
    @IdSucursal INT,
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(150),
    @Ciudad NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Sucursal
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        Ciudad = @Ciudad
    WHERE IdSucursal = @IdSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_AsignarUsuarioSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_AsignarUsuarioSucursal]
    @ID_Usuario INT,
    @IdSucursal INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Usuario_Sucursal (ID_Usuario, IdSucursal)
    VALUES (@ID_Usuario, @IdSucursal);
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarCategoria]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarCategoria] 
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Categoria
    WHERE IdCategoria = @IdCategoria;
    -- Si existen productos asociados, esta operación fallará por la FK (No Action).
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarDetallePedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarDetallePedido] 
    @IdPedido INT,
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM DetallePedido
    WHERE IdPedido = @IdPedido AND IdProducto = @IdProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarFactura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarFactura] 
    @IdFactura INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Factura
    WHERE IdFactura = @IdFactura;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarLataPintura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarLataPintura] 
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRAN;
        -- Borrar el registro de detalle primero (opcional debido a ON DELETE CASCADE)
        DELETE FROM LataPintura WHERE IdProducto = @IdProducto;
        -- Borrar el producto base
        DELETE FROM Producto WHERE IdProducto = @IdProducto;
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN;
        THROW;
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarNotificacion]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarNotificacion] 
    @IdNotificacion INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Notificacion
    WHERE IdNotificacion = @IdNotificacion;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarPedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarPedido] 
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Pedido
    WHERE IdPedido = @IdPedido;
    -- Detalles e Factura relacionados se eliminan automáticamente (cascada).
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarProducto]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarProducto] 
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Producto
    WHERE IdProducto = @IdProducto;
    -- Por ON DELETE CASCADE, LataPintura (si existe) y Stock se eliminan automáticamente.
    -- Si el producto tiene DetallePedidos asociados, la eliminación será bloqueada (No Action).
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarStock]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarStock] 
    @IdSucursal INT,
    @IdProducto INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Stock
    WHERE IdSucursal = @IdSucursal AND IdProducto = @IdProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarSucursal] 
    @IdSucursal INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Sucursal
    WHERE IdSucursal = @IdSucursal;
    -- Stocks relacionados se borran en cascada.
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_EliminarUsuarioSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_EliminarUsuarioSucursal]
    @ID_Usuario INT,
    @IdSucursal INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Usuario_Sucursal
    WHERE ID_Usuario = @ID_Usuario AND IdSucursal = @IdSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarCategoria]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarCategoria] 
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Categoria(Nombre, Descripcion)
    VALUES (@Nombre, @Descripcion);
    SELECT SCOPE_IDENTITY() AS NuevoId;  -- devolver el IdCategoria recién insertado
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarDetallePedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarDetallePedido] 
    @IdPedido INT,
    @IdProducto INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO DetallePedido (IdPedido, IdProducto, Cantidad, PrecioUnitario)
    VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario);
    SELECT @Cantidad AS CantidadInsertada;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarFactura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarFactura] 
    @IdPedido INT,
    @MontoTotal DECIMAL(10,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Factura (IdPedido, Fecha, MontoTotal)
    VALUES (@IdPedido, GETDATE(), @MontoTotal);
    SELECT SCOPE_IDENTITY() AS NuevoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarLataPintura]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarLataPintura] 
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255) = NULL,
    @Precio DECIMAL(10,2),
    @IdCategoria INT,
    @Color NVARCHAR(50),
    @CapacidadL DECIMAL(5,2),
    @Marca NVARCHAR(50),
    @TipoBase NVARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @NewProductId INT;
    -- Iniciar Transacción
    BEGIN TRY
        BEGIN TRAN;
        -- Insertar en Producto
        INSERT INTO Producto (Nombre, Descripcion, Precio, IdCategoria)
        VALUES (@Nombre, @Descripcion, @Precio, @IdCategoria);
        SET @NewProductId = SCOPE_IDENTITY();
        -- Insertar en LataPintura con el Id generado
        INSERT INTO LataPintura (IdProducto, Color, CapacidadL, Marca, TipoBase)
        VALUES (@NewProductId, @Color, @CapacidadL, @Marca, @TipoBase);
        COMMIT TRAN;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK TRAN;
        THROW;  -- Propagar el error para que el llamador lo maneje
    END CATCH;
    -- Devolver el Id nuevo si todo fue bien
    SELECT @NewProductId AS NuevoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarNotificacion]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarNotificacion] 
    @ID_Usuario INT,
    @Mensaje NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Notificacion (ID_Usuario, Mensaje, FechaCreacion, Leida)
    VALUES (@ID_Usuario, @Mensaje, GETDATE(), 0);
    SELECT SCOPE_IDENTITY() AS NuevoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarPedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarPedido] 
    @ID_Usuario INT,
    @Total DECIMAL(10,2),
    @Estado TINYINT = 0
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Pedido (ID_Usuario, Fecha, Total, Estado)
    VALUES (@ID_Usuario, GETDATE(), @Total, @Estado);
    SELECT SCOPE_IDENTITY() AS NuevoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarProducto]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarProducto] 
    @Nombre NVARCHAR(100),
    @Descripcion NVARCHAR(255) = NULL,
    @Precio DECIMAL(10,2),
    @IdCategoria INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Producto (Nombre, Descripcion, Precio, IdCategoria)
    VALUES (@Nombre, @Descripcion, @Precio, @IdCategoria);
    SELECT SCOPE_IDENTITY() AS NuevoId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarStock]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarStock] 
    @IdSucursal INT,
    @IdProducto INT,
    @Cantidad INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Stock (IdSucursal, IdProducto, Cantidad)
    VALUES (@IdSucursal, @IdProducto, @Cantidad);
    SELECT @Cantidad AS CantidadInsertada;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertarSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_InsertarSucursal] 
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(150),
    @Ciudad NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Sucursal (Nombre, Direccion, Ciudad)
    VALUES (@Nombre, @Direccion, @Ciudad);
    SELECT SCOPE_IDENTITY() AS NuevaId;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarDetallesPorPedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarDetallesPorPedido] 
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT DP.IdPedido, DP.IdProducto, P.Nombre as Producto, 
           DP.Cantidad, DP.PrecioUnitario, 
           (DP.Cantidad * DP.PrecioUnitario) as Subtotal
    FROM DetallePedido DP
    JOIN Producto P ON DP.IdProducto = P.IdProducto
    WHERE DP.IdPedido = @IdPedido;
    -- Lista los productos en el pedido dado, incluyendo nombre, cantidad, precio y subtotal por línea.
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarFacturasPorUsuario]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarFacturasPorUsuario] 
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT F.IdFactura, F.Fecha, F.MontoTotal,
           P.IdPedido, P.Fecha as FechaPedido, P.Total as TotalPedido
    FROM Factura F
    JOIN Pedido P ON F.IdPedido = P.IdPedido
    WHERE P.ID_Usuario = @ID_Usuario;
    -- Lista todas las facturas cuyos pedidos pertenecen al usuario dado.
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarNotificacionesPorUsuario]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarNotificacionesPorUsuario] 
    @ID_Usuario INT,
    @SoloNoLeidas BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT N.IdNotificacion, N.Mensaje, N.FechaCreacion, N.Leida
    FROM Notificacion N
    WHERE N.ID_Usuario = @ID_Usuario
      AND (@SoloNoLeidas = 0 OR N.Leida = 0)
    ORDER BY N.FechaCreacion DESC;
    -- Devuelve las notificaciones de un usuario. Si @SoloNoLeidas=1, filtra solo las no leídas.
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarPedidosPorCliente]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarPedidosPorCliente] 
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT P.IdPedido, P.Fecha, P.Total, P.Estado,
           U.Nombre as Cliente
    FROM Pedido P
    JOIN Usuario U ON P.ID_Usuario = U.ID_Usuario
    WHERE P.ID_Usuario = @ID_Usuario;
    -- Devuelve todos los pedidos del usuario, con su fecha, total, estado y nombre de usuario.
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarProductosPorSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarProductosPorSucursal] 
    @IdSucursal INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT S.Nombre as Sucursal, Pr.IdProducto, Pr.Nombre as Producto, Pr.Precio,
           C.Nombre as Categoria, St.Cantidad as StockDisponible
    FROM Stock St
    JOIN Producto Pr ON St.IdProducto = Pr.IdProducto
    JOIN Sucursal S ON St.IdSucursal = S.IdSucursal
    LEFT JOIN Categoria C ON Pr.IdCategoria = C.IdCategoria
    WHERE St.IdSucursal = @IdSucursal;
    -- Lista los productos disponibles en la sucursal dada, con su categoría, precio y cantidad en stock.
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarSucursalesPorUsuario]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarSucursalesPorUsuario]
    @IdUsuario INT
AS
BEGIN
    SELECT S.IdSucursal, S.Nombre, S.Ciudad
    FROM Usuario_Sucursal US
    JOIN Sucursal S ON US.IdSucursal = S.IdSucursal
    WHERE US.ID_Usuario = @IdUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ListarUsuariosPorSucursal]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ListarUsuariosPorSucursal]
    @IdSucursal INT
AS
BEGIN
    SELECT U.ID_Usuario, U.Nombre, U.Apellido, U.Username
    FROM Usuario_Sucursal US
    JOIN Usuario U ON US.ID_Usuario = U.ID_Usuario
    WHERE US.IdSucursal = @IdSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[usp_ObtenerFacturaPorPedido]    Script Date: 22/6/2025 23:43:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_ObtenerFacturaPorPedido] 
    @IdPedido INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT F.IdFactura, F.Fecha, F.MontoTotal,
           P.IdPedido, P.Fecha as FechaPedido, P.Total as TotalPedido,
           U.Nombre as Cliente
    FROM Factura F
    JOIN Pedido P ON F.IdPedido = P.IdPedido
    JOIN Usuario U ON P.ID_Usuario = U.ID_Usuario
    WHERE F.IdPedido = @IdPedido;
    -- Devuelve la factura del pedido especificado (si existe), incluyendo datos del pedido y cliente.
END;
GO
USE [master]
GO
ALTER DATABASE [P_Ing_Sof_Alonso25] SET  READ_WRITE 
GO
