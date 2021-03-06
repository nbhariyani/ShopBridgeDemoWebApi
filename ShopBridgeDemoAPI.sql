USE [ShopBridgeDemoAPI]
GO
ALTER TABLE [inv].[ProductImages] DROP CONSTRAINT [FK_ProductImages_Products_ProductId]
GO
/****** Object:  Index [IX_ProductImages_ProductId]    Script Date: 6/12/2021 12:53:23 PM ******/
DROP INDEX [IX_ProductImages_ProductId] ON [inv].[ProductImages]
GO
/****** Object:  Table [inv].[Products]    Script Date: 6/12/2021 12:53:23 PM ******/
DROP TABLE [inv].[Products]
GO
/****** Object:  Table [inv].[ProductImages]    Script Date: 6/12/2021 12:53:23 PM ******/
DROP TABLE [inv].[ProductImages]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/12/2021 12:53:23 PM ******/
DROP TABLE [dbo].[__EFMigrationsHistory]
GO
/****** Object:  Schema [inv]    Script Date: 6/12/2021 12:53:23 PM ******/
DROP SCHEMA [inv]
GO
USE [master]
GO
/****** Object:  Database [ShopBridgeDemoAPI]    Script Date: 6/12/2021 12:53:23 PM ******/
DROP DATABASE [ShopBridgeDemoAPI]
GO
/****** Object:  Database [ShopBridgeDemoAPI]    Script Date: 6/12/2021 12:53:23 PM ******/
CREATE DATABASE [ShopBridgeDemoAPI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ShopBridgeDemoAPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ShopBridgeDemoAPI.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ShopBridgeDemoAPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\ShopBridgeDemoAPI_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ShopBridgeDemoAPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET RECOVERY FULL 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET  MULTI_USER 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ShopBridgeDemoAPI', N'ON'
GO
USE [ShopBridgeDemoAPI]
GO
/****** Object:  Schema [inv]    Script Date: 6/12/2021 12:53:23 PM ******/
CREATE SCHEMA [inv]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/12/2021 12:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [inv].[ProductImages]    Script Date: 6/12/2021 12:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [inv].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
	[LastModified] [datetime2](7) NULL,
	[ProductId] [int] NOT NULL,
	[ImageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [inv].[Products]    Script Date: 6/12/2021 12:53:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [inv].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
	[LastModified] [datetime2](7) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NULL,
	[Price] [decimal](18, 6) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210612071843_AddInitial', N'3.1.7')
SET IDENTITY_INSERT [inv].[Products] ON 

INSERT [inv].[Products] ([Id], [CreatedBy], [Created], [LastModifiedBy], [LastModified], [Name], [Description], [Price]) VALUES (1, 1, CAST(N'2021-05-21T19:07:39.0000000' AS DateTime2), 0, NULL, N'Item 1', N'Item 1 Desc', CAST(123.000000 AS Decimal(18, 6)))
INSERT [inv].[Products] ([Id], [CreatedBy], [Created], [LastModifiedBy], [LastModified], [Name], [Description], [Price]) VALUES (2, 1, CAST(N'2021-05-21T21:11:46.0000000' AS DateTime2), 0, NULL, N'Item 2', N'Item 2 Desc', CAST(666.000000 AS Decimal(18, 6)))
INSERT [inv].[Products] ([Id], [CreatedBy], [Created], [LastModifiedBy], [LastModified], [Name], [Description], [Price]) VALUES (3, 1, CAST(N'2021-05-21T21:11:47.0000000' AS DateTime2), 0, NULL, N'Item 3', N'Item 3 Desc', CAST(777.000000 AS Decimal(18, 6)))
INSERT [inv].[Products] ([Id], [CreatedBy], [Created], [LastModifiedBy], [LastModified], [Name], [Description], [Price]) VALUES (4, 1, CAST(N'2021-05-21T21:11:48.0000000' AS DateTime2), 0, NULL, N'Item 4', N'Item 4 Desc', CAST(888.000000 AS Decimal(18, 6)))
INSERT [inv].[Products] ([Id], [CreatedBy], [Created], [LastModifiedBy], [LastModified], [Name], [Description], [Price]) VALUES (5, 1, CAST(N'2021-05-21T21:11:49.0000000' AS DateTime2), 0, NULL, N'Item 5', N'Item 5 Desc', CAST(999.000000 AS Decimal(18, 6)))
INSERT [inv].[Products] ([Id], [CreatedBy], [Created], [LastModifiedBy], [LastModified], [Name], [Description], [Price]) VALUES (6, 1, CAST(N'2021-05-21T21:11:50.0000000' AS DateTime2), 0, NULL, N'Item 6', N'Item 6 Desc', CAST(1010.000000 AS Decimal(18, 6)))
INSERT [inv].[Products] ([Id], [CreatedBy], [Created], [LastModifiedBy], [LastModified], [Name], [Description], [Price]) VALUES (7, 1, CAST(N'2021-05-21T21:11:51.0000000' AS DateTime2), 0, NULL, N'Item 7', N'Item 7 Desc', CAST(1111.000000 AS Decimal(18, 6)))
SET IDENTITY_INSERT [inv].[Products] OFF
/****** Object:  Index [IX_ProductImages_ProductId]    Script Date: 6/12/2021 12:53:23 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductId] ON [inv].[ProductImages]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [inv].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [inv].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [inv].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products_ProductId]
GO
USE [master]
GO
ALTER DATABASE [ShopBridgeDemoAPI] SET  READ_WRITE 
GO
