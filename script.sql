USE [master]
GO
/****** Object:  Database [accounting_db]    Script Date: 19/03/2019 11:04:24 ******/
CREATE DATABASE [accounting_db]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'accounting_db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\accounting_db.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'accounting_db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\accounting_db_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [accounting_db] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [accounting_db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [accounting_db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [accounting_db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [accounting_db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [accounting_db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [accounting_db] SET ARITHABORT OFF 
GO
ALTER DATABASE [accounting_db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [accounting_db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [accounting_db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [accounting_db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [accounting_db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [accounting_db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [accounting_db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [accounting_db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [accounting_db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [accounting_db] SET  ENABLE_BROKER 
GO
ALTER DATABASE [accounting_db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [accounting_db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [accounting_db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [accounting_db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [accounting_db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [accounting_db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [accounting_db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [accounting_db] SET RECOVERY FULL 
GO
ALTER DATABASE [accounting_db] SET  MULTI_USER 
GO
ALTER DATABASE [accounting_db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [accounting_db] SET DB_CHAINING OFF 
GO
ALTER DATABASE [accounting_db] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [accounting_db] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [accounting_db] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'accounting_db', N'ON'
GO
ALTER DATABASE [accounting_db] SET QUERY_STORE = OFF
GO
USE [accounting_db]
GO
/****** Object:  Table [dbo].[account_catalog]    Script Date: 19/03/2019 11:04:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_catalog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[account_type_id] [int] NOT NULL,
	[code] [varchar](15) NOT NULL,
	[name] [varchar](25) NOT NULL,
	[transactional] [bit] NOT NULL,
	[level] [tinyint] NOT NULL,
	[major] [int] NULL,
	[balance] [decimal](10, 2) NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_cuenta_contable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[account_type]    Script Date: 19/03/2019 11:04:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[account_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](20) NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_account_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accounting_clerk]    Script Date: 19/03/2019 11:04:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounting_clerk](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](5) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_accounting_clerk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accounting_entry]    Script Date: 19/03/2019 11:04:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounting_entry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[accounting_clerk_id] [int] NOT NULL,
	[currency_id] [int] NOT NULL,
	[description] [varchar](100) NOT NULL,
	[state] [int] NOT NULL,
	[create_on] [datetime] NOT NULL,
 CONSTRAINT [PK_accounting_entry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[accounting_entry_detail]    Script Date: 19/03/2019 11:04:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accounting_entry_detail](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[accounting_entry_id] [int] NOT NULL,
	[account_catalog_id] [int] NOT NULL,
	[transaction_type] [int] NOT NULL,
	[amount] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_accounting_entry_detail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[currency]    Script Date: 19/03/2019 11:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[currency](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [varchar](5) NOT NULL,
	[name] [varchar](25) NOT NULL,
	[state] [bit] NOT NULL,
 CONSTRAINT [PK_currency] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[currency_exchange]    Script Date: 19/03/2019 11:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[currency_exchange](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[currency_id] [int] NOT NULL,
	[amount] [float] NOT NULL,
	[create_on] [date] NULL,
 CONSTRAINT [PK_currency_exchange] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user_accounting]    Script Date: 19/03/2019 11:04:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user_accounting](
	[username] [varchar](50) NOT NULL,
	[fullname] [varchar](150) NOT NULL,
	[user_password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_user_accounting] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[account_catalog] ON 

INSERT [dbo].[account_catalog] ([id], [account_type_id], [code], [name], [transactional], [level], [major], [balance], [state]) VALUES (1, 1, N'1', N'Activos', 0, 1, 0, CAST(0.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[account_catalog] ([id], [account_type_id], [code], [name], [transactional], [level], [major], [balance], [state]) VALUES (2, 1, N'2', N'Efectivo en Caja', 0, 2, 1, CAST(0.00 AS Decimal(10, 2)), 1)
INSERT [dbo].[account_catalog] ([id], [account_type_id], [code], [name], [transactional], [level], [major], [balance], [state]) VALUES (3, 1, N'3', N'Caja Chica', 1, 3, 2, CAST(0.00 AS Decimal(10, 2)), 1)
SET IDENTITY_INSERT [dbo].[account_catalog] OFF
SET IDENTITY_INSERT [dbo].[account_type] ON 

INSERT [dbo].[account_type] ([id], [description], [state]) VALUES (1, N'Activos', 1)
INSERT [dbo].[account_type] ([id], [description], [state]) VALUES (2, N'Pasivos', 1)
INSERT [dbo].[account_type] ([id], [description], [state]) VALUES (3, N'Capital', 1)
INSERT [dbo].[account_type] ([id], [description], [state]) VALUES (4, N'Ingresos', 1)
INSERT [dbo].[account_type] ([id], [description], [state]) VALUES (5, N'Costos', 1)
INSERT [dbo].[account_type] ([id], [description], [state]) VALUES (6, N'Gastos', 1)
SET IDENTITY_INSERT [dbo].[account_type] OFF
SET IDENTITY_INSERT [dbo].[accounting_clerk] ON 

INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (1, N'1', N'Contabilidad', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (2, N'2', N'Nomina', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (3, N'3', N'Facturacion', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (4, N'4', N'Inventario', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (5, N'5', N'Cuentas x Cobrar', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (6, N'6', N'Cuentas x Pagar', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (7, N'7', N'Compras', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (8, N'8', N'Activos Fijos', 1)
INSERT [dbo].[accounting_clerk] ([id], [code], [name], [state]) VALUES (9, N'9', N'Cheques', 1)
SET IDENTITY_INSERT [dbo].[accounting_clerk] OFF
SET IDENTITY_INSERT [dbo].[accounting_entry] ON 

INSERT [dbo].[accounting_entry] ([id], [accounting_clerk_id], [currency_id], [description], [state], [create_on]) VALUES (1, 2, 1, N'Nomina Empleados Octubre 2019', 1, CAST(N'2019-03-14T00:00:00.000' AS DateTime))
INSERT [dbo].[accounting_entry] ([id], [accounting_clerk_id], [currency_id], [description], [state], [create_on]) VALUES (2, 2, 1, N'Nomina Empleados Agosto 2018 Departamento de Informatica', 1, CAST(N'2019-03-19T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[accounting_entry] OFF
SET IDENTITY_INSERT [dbo].[currency] ON 

INSERT [dbo].[currency] ([id], [code], [name], [state]) VALUES (1, N'DOP', N'Peso Dominicano', 1)
SET IDENTITY_INSERT [dbo].[currency] OFF
SET IDENTITY_INSERT [dbo].[currency_exchange] ON 

INSERT [dbo].[currency_exchange] ([id], [currency_id], [amount], [create_on]) VALUES (1, 1, 1, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[currency_exchange] ([id], [currency_id], [amount], [create_on]) VALUES (2, 1, 2, CAST(N'2019-03-14' AS Date))
SET IDENTITY_INSERT [dbo].[currency_exchange] OFF
INSERT [dbo].[user_accounting] ([username], [fullname], [user_password]) VALUES (N'joseortiz', N'Jose Ortiz', N'123456')
ALTER TABLE [dbo].[account_catalog] ADD  DEFAULT ((0)) FOR [transactional]
GO
ALTER TABLE [dbo].[account_catalog] ADD  DEFAULT ((0)) FOR [balance]
GO
ALTER TABLE [dbo].[account_catalog] ADD  DEFAULT ((0)) FOR [state]
GO
ALTER TABLE [dbo].[account_type] ADD  DEFAULT ((0)) FOR [state]
GO
ALTER TABLE [dbo].[accounting_clerk] ADD  DEFAULT ((0)) FOR [state]
GO
ALTER TABLE [dbo].[accounting_entry] ADD  CONSTRAINT [DF__accountin__creat__47DBAE45]  DEFAULT (getdate()) FOR [create_on]
GO
ALTER TABLE [dbo].[accounting_entry_detail] ADD  DEFAULT ((0)) FOR [amount]
GO
ALTER TABLE [dbo].[currency] ADD  DEFAULT ((0)) FOR [state]
GO
ALTER TABLE [dbo].[account_catalog]  WITH CHECK ADD  CONSTRAINT [FK_cuenta_contable_tipo_cuenta] FOREIGN KEY([account_type_id])
REFERENCES [dbo].[account_type] ([id])
GO
ALTER TABLE [dbo].[account_catalog] CHECK CONSTRAINT [FK_cuenta_contable_tipo_cuenta]
GO
ALTER TABLE [dbo].[accounting_entry]  WITH CHECK ADD  CONSTRAINT [FK_accounting_entry_accounting_clerk] FOREIGN KEY([accounting_clerk_id])
REFERENCES [dbo].[accounting_clerk] ([id])
GO
ALTER TABLE [dbo].[accounting_entry] CHECK CONSTRAINT [FK_accounting_entry_accounting_clerk]
GO
ALTER TABLE [dbo].[accounting_entry]  WITH CHECK ADD  CONSTRAINT [FK_accounting_entry_currency] FOREIGN KEY([currency_id])
REFERENCES [dbo].[currency] ([id])
GO
ALTER TABLE [dbo].[accounting_entry] CHECK CONSTRAINT [FK_accounting_entry_currency]
GO
ALTER TABLE [dbo].[accounting_entry_detail]  WITH CHECK ADD  CONSTRAINT [FK_accounting_entry_detail_account_catalog] FOREIGN KEY([account_catalog_id])
REFERENCES [dbo].[account_catalog] ([id])
GO
ALTER TABLE [dbo].[accounting_entry_detail] CHECK CONSTRAINT [FK_accounting_entry_detail_account_catalog]
GO
ALTER TABLE [dbo].[accounting_entry_detail]  WITH CHECK ADD  CONSTRAINT [FK_accounting_entry_detail_accounting_entry] FOREIGN KEY([accounting_entry_id])
REFERENCES [dbo].[accounting_entry] ([id])
GO
ALTER TABLE [dbo].[accounting_entry_detail] CHECK CONSTRAINT [FK_accounting_entry_detail_accounting_entry]
GO
ALTER TABLE [dbo].[currency_exchange]  WITH CHECK ADD  CONSTRAINT [FK_currency_exchange_currency] FOREIGN KEY([currency_id])
REFERENCES [dbo].[currency] ([id])
GO
ALTER TABLE [dbo].[currency_exchange] CHECK CONSTRAINT [FK_currency_exchange_currency]
GO
USE [master]
GO
ALTER DATABASE [accounting_db] SET  READ_WRITE 
GO
