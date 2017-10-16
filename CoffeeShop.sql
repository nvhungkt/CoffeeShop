USE [master]
GO
/****** Object:  Database [CoffeeManagement]    Script Date: 16-Oct-17 04:37:56 PM ******/
CREATE DATABASE [CoffeeManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoffeeManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CoffeeManagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CoffeeManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CoffeeManagement.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CoffeeManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoffeeManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CoffeeManagement] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [CoffeeManagement] SET ANSI_NULLS ON 
GO
ALTER DATABASE [CoffeeManagement] SET ANSI_PADDING ON 
GO
ALTER DATABASE [CoffeeManagement] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [CoffeeManagement] SET ARITHABORT ON 
GO
ALTER DATABASE [CoffeeManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CoffeeManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CoffeeManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CoffeeManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CoffeeManagement] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [CoffeeManagement] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [CoffeeManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CoffeeManagement] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [CoffeeManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CoffeeManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CoffeeManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CoffeeManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CoffeeManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CoffeeManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CoffeeManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CoffeeManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CoffeeManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CoffeeManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [CoffeeManagement] SET  MULTI_USER 
GO
ALTER DATABASE [CoffeeManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CoffeeManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CoffeeManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CoffeeManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CoffeeManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CoffeeManagement]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 16-Oct-17 04:37:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 16-Oct-17 04:37:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[StaffID] [int] NULL,
	[TakenDate] [date] NULL,
	[TakenTime] [time](7) NULL,
	[TableNumber] [int] NULL,
 CONSTRAINT [PK__Order__3214EC07577479B0] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 16-Oct-17 04:37:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [int] NOT NULL,
	[no] [int] NOT NULL,
	[ProductID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[no] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 16-Oct-17 04:37:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Price] [float] NULL,
	[CategoryID] [int] NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 16-Oct-17 04:37:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Birthday] [date] NULL,
	[Address] [nvarchar](50) NULL,
	[JoinDate] [date] NULL,
	[Gender] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Role] [int] NULL,
	[isActive] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Staff]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Order]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
USE [master]
GO
ALTER DATABASE [CoffeeManagement] SET  READ_WRITE 
GO
