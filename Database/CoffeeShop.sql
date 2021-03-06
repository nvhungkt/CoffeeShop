USE [master]
GO
/****** Object:  Database [CoffeeManagement]    Script Date: 10/19/2017 19:35:21 ******/
CREATE DATABASE [CoffeeManagement] ON  PRIMARY 
( NAME = N'CoffeeManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CoffeeManagement.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CoffeeManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CoffeeManagement.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CoffeeManagement] SET COMPATIBILITY_LEVEL = 100
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
ALTER DATABASE [CoffeeManagement] SET AUTO_CREATE_STATISTICS ON
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
ALTER DATABASE [CoffeeManagement] SET  READ_WRITE
GO
ALTER DATABASE [CoffeeManagement] SET RECOVERY FULL
GO
ALTER DATABASE [CoffeeManagement] SET  MULTI_USER
GO
ALTER DATABASE [CoffeeManagement] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [CoffeeManagement] SET DB_CHAINING OFF
GO
USE [CoffeeManagement]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 10/19/2017 19:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[birthday] [date] NULL,
	[address] [nvarchar](150) NULL,
	[joinDate] [date] NULL,
	[gender] [nvarchar](50) NULL,
	[phone] [nvarchar](15) NULL,
	[email] [nvarchar](50) NULL,
	[role] [int] NULL,
	[isActive] [bit] NULL,
	[lastModified] [datetime] NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Staff__3214EC070CBAE877] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Staff_Username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
SET IDENTITY_INSERT [dbo].[Staff] ON
INSERT [dbo].[Staff] ([id], [name], [birthday], [address], [joinDate], [gender], [phone], [email], [role], [isActive], [lastModified], [username], [password]) VALUES (1, N'Nguyễn Việt Hùng', CAST(0x6A3D0B00 AS Date), NULL, CAST(0x6A3D0B00 AS Date), N'Male', NULL, NULL, 1, 1, NULL, N'hungnv', N'123')
INSERT [dbo].[Staff] ([id], [name], [birthday], [address], [joinDate], [gender], [phone], [email], [role], [isActive], [lastModified], [username], [password]) VALUES (2, N'Võ Gia Vũ', CAST(0x6A3D0B00 AS Date), NULL, CAST(0x6A3D0B00 AS Date), N'Male', NULL, NULL, 2, 1, NULL, N'vuvg', N'123')
INSERT [dbo].[Staff] ([id], [name], [birthday], [address], [joinDate], [gender], [phone], [email], [role], [isActive], [lastModified], [username], [password]) VALUES (3, N'Trần Trọng Hiếu', CAST(0x6A3D0B00 AS Date), NULL, CAST(0x6A3D0B00 AS Date), N'Male', NULL, NULL, 2, 1, NULL, N'hieutt', N'123')
INSERT [dbo].[Staff] ([id], [name], [birthday], [address], [joinDate], [gender], [phone], [email], [role], [isActive], [lastModified], [username], [password]) VALUES (4, N'Minh Leoo', CAST(0x6A3D0B00 AS Date), NULL, CAST(0x6A3D0B00 AS Date), N'Male', NULL, NULL, 2, 1, NULL, N'minhleoo', N'123')
INSERT [dbo].[Staff] ([id], [name], [birthday], [address], [joinDate], [gender], [phone], [email], [role], [isActive], [lastModified], [username], [password]) VALUES (5, N'Bạch Minh Nam', CAST(0x6A3D0B00 AS Date), NULL, CAST(0x6A3D0B00 AS Date), N'Male', NULL, NULL, 2, 1, NULL, N'nambm', N'123')
SET IDENTITY_INSERT [dbo].[Staff] OFF
/****** Object:  Table [dbo].[Category]    Script Date: 10/19/2017 19:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](250) NULL,
	[isActive] [bit] NULL,
	[lastModified] [datetime] NULL,
 CONSTRAINT [PK__Category__3214EC077F60ED59] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([id], [name], [description], [isActive], [lastModified]) VALUES (1, N'Espresso & Coffee', N'Từng ly cà phê được làm ra bởi niềm đam mê với hương vị, sự chăm chút cho hạnh phúc của khách hàng, niềm hào hứng được phục vụ và sự tỉ mỉ để đạt tới chất lượng cà phê tuyệ vời nhất.', 1, NULL)
INSERT [dbo].[Category] ([id], [name], [description], [isActive], [lastModified]) VALUES (2, N'Special Tea', N'Bất cứ thời điểm nào cũng là thời gian để uống một ly trà. Bạn chọn ly trà nào cho hôm nay?', 1, NULL)
INSERT [dbo].[Category] ([id], [name], [description], [isActive], [lastModified]) VALUES (3, N'Chocolate', N'Không có khoảng thời gian nào quý giá như khi ở bên cạnh bạn bè, trừ khi bạn có một ly chocolate. và niềm hạnh phúc của chúng tôi là phục vụ bạn những khoảng thời gian quý giá như thế.', 1, NULL)
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Order]    Script Date: 10/19/2017 19:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerName] [nvarchar](150) NULL,
	[staffID] [int] NULL,
	[takenDate] [date] NULL,
	[takenTime] [time](7) NULL,
	[tableNumber] [int] NULL,
	[totalPrice] [float] NULL,
	[status] [nvarchar](50) NULL,
 CONSTRAINT [PK__Order__3214EC07577479B0] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/19/2017 19:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NULL,
	[description] [nvarchar](250) NULL,
	[price] [float] NULL,
	[categoryID] [int] NULL,
	[isActive] [bit] NULL,
	[lastModified] [datetime] NULL,
 CONSTRAINT [PK__Product__3214EC0708EA5793] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Product] ON
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (1, N'CAPPUCCINO', N'Espresso, sữa tươi, bọt sữa', 45000, 1, 1, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (2, N'CARAMEL MACCHIATO', N'Espresso, sữa tươi, caramel', 55000, 1, 1, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (3, N'MOCHA', N'Espresso, sôcôla, sữa tươi, bọt sữa', 49000, 1, 1, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (4, N'VIETNAMESE COFFEE', N'Cà phê đá / Cà phê sữa đá', 29000, 1, 1, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (5, N'VIETNAMESE WHITE COFFEE', N'Bạc Sỉu', 29000, 1, 1, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (6, N'HOT CHOCOLATE TOFFEE ALMOND', N'Sôcôla, hạnh nhân, kem tươi, kẹo marshmallow', 59000, 3, 1, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (7, N'BLACK TEA MACCHIATO', N'Trà đen, váng sữa', 38000, 2, 1, NULL)
INSERT [dbo].[Product] ([id], [name], [description], [price], [categoryID], [isActive], [lastModified]) VALUES (8, N'MATCHA ICE BLENDED', N'Trà xanh, sữa tươi, kem tươi, đá xay', 59000, 2, 1, NULL)
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/19/2017 19:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[orderID] [int] NOT NULL,
	[no] [int] IDENTITY(1,1) NOT NULL,
	[productID] [int] NULL,
	[quantity] [int] NULL,
	[price] [float] NULL,
 CONSTRAINT [PK__OrderDet__D0B166A70519C6AF] PRIMARY KEY CLUSTERED 
(
	[orderID] ASC,
	[no] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Order_Staff]    Script Date: 10/19/2017 19:35:22 ******/
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Staff] FOREIGN KEY([staffID])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Staff]
GO
/****** Object:  ForeignKey [FK_Product_Category]    Script Date: 10/19/2017 19:35:22 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
/****** Object:  ForeignKey [FK_OrderDetails_Order]    Script Date: 10/19/2017 19:35:22 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Order] FOREIGN KEY([orderID])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetails_Order]
GO
/****** Object:  ForeignKey [FK_OrderDetails_Product]    Script Date: 10/19/2017 19:35:22 ******/
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Product] FOREIGN KEY([productID])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetails_Product]
GO
