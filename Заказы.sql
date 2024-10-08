USE [master]
GO
/****** Object:  Database [Заказы]    Script Date: 23.04.2024 9:19:49 ******/
CREATE DATABASE [Заказы]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Заказы', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\Заказы.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Заказы_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\Заказы_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Заказы] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Заказы].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Заказы] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Заказы] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Заказы] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Заказы] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Заказы] SET ARITHABORT OFF 
GO
ALTER DATABASE [Заказы] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Заказы] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Заказы] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Заказы] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Заказы] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Заказы] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Заказы] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Заказы] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Заказы] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Заказы] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Заказы] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Заказы] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Заказы] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Заказы] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Заказы] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Заказы] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Заказы] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Заказы] SET RECOVERY FULL 
GO
ALTER DATABASE [Заказы] SET  MULTI_USER 
GO
ALTER DATABASE [Заказы] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Заказы] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Заказы] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Заказы] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Заказы] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Заказы] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Заказы', N'ON'
GO
ALTER DATABASE [Заказы] SET QUERY_STORE = OFF
GO
USE [Заказы]
GO
/****** Object:  Table [dbo].[Заказ]    Script Date: 23.04.2024 9:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Заказ](
	[id_заказа] [int] NOT NULL,
	[Сумма_заказа] [money] NULL,
	[Состояние_заказа] [varchar](50) NULL,
	[id_клиента] [int] NULL,
	[id_товара] [int] NULL,
	[id_Транспорта] [int] NULL,
 CONSTRAINT [PK_Заказ] PRIMARY KEY CLUSTERED 
(
	[id_заказа] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Категория]    Script Date: 23.04.2024 9:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Категория](
	[id_Категории] [int] NOT NULL,
	[Наименование_категории] [varchar](50) NULL,
 CONSTRAINT [PK_Категория] PRIMARY KEY CLUSTERED 
(
	[id_Категории] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Клиент]    Script Date: 23.04.2024 9:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Клиент](
	[id_Клиента] [int] NOT NULL,
	[ФИО] [varchar](50) NULL,
	[Номер_телефона] [int] NULL,
	[Адрес] [varchar](50) NULL,
	[Логин] [varchar](50) NULL,
	[Пароль] [varchar](50) NULL,
 CONSTRAINT [PK_Клиент] PRIMARY KEY CLUSTERED 
(
	[id_Клиента] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Скидки]    Script Date: 23.04.2024 9:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Скидки](
	[id_скидки] [int] NOT NULL,
	[Процент_скидки] [int] NULL,
	[Длительность] [datetime] NULL,
	[id_Товара] [int] NULL,
 CONSTRAINT [PK_Скидки] PRIMARY KEY CLUSTERED 
(
	[id_скидки] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Товары]    Script Date: 23.04.2024 9:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Товары](
	[id_Товара] [int] NOT NULL,
	[Цена] [money] NULL,
	[Количество] [int] NULL,
	[Описание] [varchar](max) NULL,
	[Наименование] [varchar](50) NULL,
	[id_Категории] [int] NULL,
 CONSTRAINT [PK_Товары] PRIMARY KEY CLUSTERED 
(
	[id_Товара] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Транспорт]    Script Date: 23.04.2024 9:19:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Транспорт](
	[id_Транспорта] [int] NOT NULL,
	[Тип_транспорта] [varchar](50) NULL,
 CONSTRAINT [PK_Транспорт] PRIMARY KEY CLUSTERED 
(
	[id_Транспорта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Клиент] FOREIGN KEY([id_клиента])
REFERENCES [dbo].[Клиент] ([id_Клиента])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Клиент]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Товары] FOREIGN KEY([id_товара])
REFERENCES [dbo].[Товары] ([id_Товара])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Товары]
GO
ALTER TABLE [dbo].[Заказ]  WITH CHECK ADD  CONSTRAINT [FK_Заказ_Транспорт] FOREIGN KEY([id_Транспорта])
REFERENCES [dbo].[Транспорт] ([id_Транспорта])
GO
ALTER TABLE [dbo].[Заказ] CHECK CONSTRAINT [FK_Заказ_Транспорт]
GO
ALTER TABLE [dbo].[Скидки]  WITH CHECK ADD  CONSTRAINT [FK_Скидки_Товары] FOREIGN KEY([id_Товара])
REFERENCES [dbo].[Товары] ([id_Товара])
GO
ALTER TABLE [dbo].[Скидки] CHECK CONSTRAINT [FK_Скидки_Товары]
GO
ALTER TABLE [dbo].[Товары]  WITH CHECK ADD  CONSTRAINT [FK_Товары_Категория] FOREIGN KEY([id_Категории])
REFERENCES [dbo].[Категория] ([id_Категории])
GO
ALTER TABLE [dbo].[Товары] CHECK CONSTRAINT [FK_Товары_Категория]
GO
USE [master]
GO
ALTER DATABASE [Заказы] SET  READ_WRITE 
GO
