USE [master]
GO
/****** Object:  Database [InventoryDb]    Script Date: 22-Feb-21 9:01:45 PM ******/
CREATE DATABASE [InventoryDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InventoryDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\InventoryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InventoryDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\InventoryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [InventoryDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InventoryDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InventoryDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InventoryDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InventoryDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InventoryDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InventoryDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [InventoryDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InventoryDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InventoryDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InventoryDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InventoryDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InventoryDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InventoryDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InventoryDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InventoryDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InventoryDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InventoryDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InventoryDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InventoryDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InventoryDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InventoryDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InventoryDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InventoryDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InventoryDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InventoryDb] SET  MULTI_USER 
GO
ALTER DATABASE [InventoryDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InventoryDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InventoryDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InventoryDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InventoryDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InventoryDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InventoryDb] SET QUERY_STORE = OFF
GO
USE [InventoryDb]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 22-Feb-21 9:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 22-Feb-21 9:01:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Electronic')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Grocery')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'Cloth')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (8, N'Food')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (11, N'Book')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (13, N'bb')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [CategoryId]) VALUES (1, N'Mouse', 500, 1)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [CategoryId]) VALUES (2, N'Shirt', 1000, 3)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [CategoryId]) VALUES (3, N'Rice (1kg)', 50, 2)
INSERT [dbo].[Products] ([ProductId], [ProductName], [Price], [CategoryId]) VALUES (4, N'Monitor (samsung)', 8000, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
USE [master]
GO
ALTER DATABASE [InventoryDb] SET  READ_WRITE 
GO
