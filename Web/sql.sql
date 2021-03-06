USE [master]
GO
/****** Object:  Database [LuckyDraw]    Script Date: 01/18/2016 14:07:13 ******/
CREATE DATABASE [LuckyDraw] ON  PRIMARY 
( NAME = N'LuckyDraw', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\LuckyDraw.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LuckyDraw_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\LuckyDraw_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LuckyDraw] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LuckyDraw].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LuckyDraw] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [LuckyDraw] SET ANSI_NULLS OFF
GO
ALTER DATABASE [LuckyDraw] SET ANSI_PADDING OFF
GO
ALTER DATABASE [LuckyDraw] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [LuckyDraw] SET ARITHABORT OFF
GO
ALTER DATABASE [LuckyDraw] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [LuckyDraw] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [LuckyDraw] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [LuckyDraw] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [LuckyDraw] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [LuckyDraw] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [LuckyDraw] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [LuckyDraw] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [LuckyDraw] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [LuckyDraw] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [LuckyDraw] SET  DISABLE_BROKER
GO
ALTER DATABASE [LuckyDraw] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [LuckyDraw] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [LuckyDraw] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [LuckyDraw] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [LuckyDraw] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [LuckyDraw] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [LuckyDraw] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [LuckyDraw] SET  READ_WRITE
GO
ALTER DATABASE [LuckyDraw] SET RECOVERY SIMPLE
GO
ALTER DATABASE [LuckyDraw] SET  MULTI_USER
GO
ALTER DATABASE [LuckyDraw] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [LuckyDraw] SET DB_CHAINING OFF
GO
USE [LuckyDraw]
GO
/****** Object:  Table [dbo].[SmallSet]    Script Date: 01/18/2016 14:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SmallSet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[num] [int] NOT NULL,
	[color] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SmallSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SmallSet] ON
INSERT [dbo].[SmallSet] ([id], [name], [num], [color]) VALUES (31, N'一等奖', 9, N'#d9ead3')
INSERT [dbo].[SmallSet] ([id], [name], [num], [color]) VALUES (32, N'二等奖', 22, N'#c27ba0')
INSERT [dbo].[SmallSet] ([id], [name], [num], [color]) VALUES (33, N'三等奖', 20, N'#b6d7a8')
INSERT [dbo].[SmallSet] ([id], [name], [num], [color]) VALUES (34, N'[sorry]谢谢你', 11, N'#6fa8dc')
SET IDENTITY_INSERT [dbo].[SmallSet] OFF
/****** Object:  Table [dbo].[PhotoSet]    Script Date: 01/18/2016 14:07:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhotoSet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[url] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PhotoSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PhotoSet] ON
INSERT [dbo].[PhotoSet] ([id], [name], [url]) VALUES (74, N'test', N'/Data/409964.png')
INSERT [dbo].[PhotoSet] ([id], [name], [url]) VALUES (75, N'test', N'/Data/409964.png')
INSERT [dbo].[PhotoSet] ([id], [name], [url]) VALUES (94, N'test', N'/Data/409964.png')
INSERT [dbo].[PhotoSet] ([id], [name], [url]) VALUES (95, N'test', N'/Data/409964.png')
INSERT [dbo].[PhotoSet] ([id], [name], [url]) VALUES (96, N'test', N'/Data/409964.png')
INSERT [dbo].[PhotoSet] ([id], [name], [url]) VALUES (97, N'test', N'/Data/409964.png')
SET IDENTITY_INSERT [dbo].[PhotoSet] OFF
