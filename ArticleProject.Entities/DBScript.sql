USE [master]
GO
/****** Object:  Database [ArticleDB]    Script Date: 7/6/2019 3:05:35 AM ******/
CREATE DATABASE [ArticleDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ArticleDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ArticleDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ArticleDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ArticleDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ArticleDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArticleDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArticleDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArticleDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArticleDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArticleDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArticleDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArticleDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArticleDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArticleDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArticleDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArticleDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArticleDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArticleDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArticleDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArticleDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArticleDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArticleDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArticleDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArticleDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArticleDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArticleDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArticleDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArticleDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArticleDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArticleDB] SET  MULTI_USER 
GO
ALTER DATABASE [ArticleDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArticleDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ArticleDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ArticleDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ArticleDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ArticleDB]
GO
/****** Object:  Table [dbo].[Article]    Script Date: 7/6/2019 3:05:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticleCategory]    Script Date: 7/6/2019 3:05:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](300) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_ArticleCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ArticleComments]    Script Date: 7/6/2019 3:05:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArticleComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_ArticleComments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Log]    Script Date: 7/6/2019 3:05:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](128) NULL,
	[TimeStamp] [datetimeoffset](7) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [xml] NULL,
	[LogEvent] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Article] ON 

INSERT [dbo].[Article] ([Id], [Title], [Text], [CategoryId], [CreatedDate], [ModifiedDate]) VALUES (3, N'Makale 3', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.', 1, CAST(N'2019-07-05 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Article] ([Id], [Title], [Text], [CategoryId], [CreatedDate], [ModifiedDate]) VALUES (4, N'test', N'test', 1, CAST(N'2019-07-05 23:49:07.100' AS DateTime), NULL)
INSERT [dbo].[Article] ([Id], [Title], [Text], [CategoryId], [CreatedDate], [ModifiedDate]) VALUES (5, N'test1', N'test1', 2, CAST(N'2019-07-06 00:06:50.953' AS DateTime), CAST(N'2019-07-06 00:06:50.957' AS DateTime))
SET IDENTITY_INSERT [dbo].[Article] OFF
SET IDENTITY_INSERT [dbo].[ArticleCategory] ON 

INSERT [dbo].[ArticleCategory] ([Id], [Title], [CreatedDate], [ModifiedDate]) VALUES (1, N'Makale Kategorisi 1', CAST(N'2019-07-05 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ArticleCategory] ([Id], [Title], [CreatedDate], [ModifiedDate]) VALUES (2, N'Makale Kategorisi 2', CAST(N'2019-07-05 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ArticleCategory] ([Id], [Title], [CreatedDate], [ModifiedDate]) VALUES (3, N'Makale Kategorisi 3', CAST(N'2019-07-05 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ArticleCategory] ([Id], [Title], [CreatedDate], [ModifiedDate]) VALUES (4, N'Makale Kategorisi 4', CAST(N'2019-07-05 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[ArticleCategory] ([Id], [Title], [CreatedDate], [ModifiedDate]) VALUES (5, N'Makale Kategorisi 5', CAST(N'2019-07-05 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[ArticleCategory] OFF
SET IDENTITY_INSERT [dbo].[ArticleComments] ON 

INSERT [dbo].[ArticleComments] ([Id], [Email], [Text], [ArticleId], [CreatedDate], [ModifiedDate]) VALUES (1, N'test@test.com', N'test', 3, CAST(N'2019-07-06 01:26:28.427' AS DateTime), CAST(N'2019-07-06 01:26:28.427' AS DateTime))
SET IDENTITY_INSERT [dbo].[ArticleComments] OFF
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([Id], [Message], [MessageTemplate], [Level], [TimeStamp], [Exception], [Properties], [LogEvent]) VALUES (1, N'Hello, world!', N'Hello, world!', N'Information', CAST(N'2019-07-06T02:37:57.5358476+03:00' AS DateTimeOffset), NULL, N'<properties />', NULL)
INSERT [dbo].[Log] ([Id], [Message], [MessageTemplate], [Level], [TimeStamp], [Exception], [Properties], [LogEvent]) VALUES (2, N'LoginController - Login Logged', N'LoginController - Login Logged', N'Information', CAST(N'2019-07-06T02:57:26.6867687+03:00' AS DateTimeOffset), NULL, N'<properties />', NULL)
INSERT [dbo].[Log] ([Id], [Message], [MessageTemplate], [Level], [TimeStamp], [Exception], [Properties], [LogEvent]) VALUES (3, N'ArticleController - Get Logged', N'ArticleController - Get Logged', N'Information', CAST(N'2019-07-06T02:57:45.0314004+03:00' AS DateTimeOffset), NULL, N'<properties />', NULL)
INSERT [dbo].[Log] ([Id], [Message], [MessageTemplate], [Level], [TimeStamp], [Exception], [Properties], [LogEvent]) VALUES (4, N'LoginController - Login Logged', N'LoginController - Login Logged', N'Information', CAST(N'2019-07-06T03:04:07.1211618+03:00' AS DateTimeOffset), NULL, N'<properties />', NULL)
INSERT [dbo].[Log] ([Id], [Message], [MessageTemplate], [Level], [TimeStamp], [Exception], [Properties], [LogEvent]) VALUES (5, N'LoginController - Login Logged', N'LoginController - Login Logged', N'Information', CAST(N'2019-07-06T03:04:12.8438484+03:00' AS DateTimeOffset), NULL, N'<properties />', NULL)
INSERT [dbo].[Log] ([Id], [Message], [MessageTemplate], [Level], [TimeStamp], [Exception], [Properties], [LogEvent]) VALUES (6, N'ArticleController - Get Logged', N'ArticleController - Get Logged', N'Information', CAST(N'2019-07-06T03:04:32.0044446+03:00' AS DateTimeOffset), NULL, N'<properties />', NULL)
SET IDENTITY_INSERT [dbo].[Log] OFF
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_ArticleCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ArticleCategory] ([Id])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_ArticleCategory]
GO
ALTER TABLE [dbo].[ArticleComments]  WITH CHECK ADD  CONSTRAINT [FK_ArticleComments_Article] FOREIGN KEY([ArticleId])
REFERENCES [dbo].[Article] ([Id])
GO
ALTER TABLE [dbo].[ArticleComments] CHECK CONSTRAINT [FK_ArticleComments_Article]
GO
USE [master]
GO
ALTER DATABASE [ArticleDB] SET  READ_WRITE 
GO
