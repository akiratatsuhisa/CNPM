USE [master]
GO
/****** Object:  Database [SalesManagement]    Script Date: 12/18/2018 7:35:55 PM ******/
CREATE DATABASE [SalesManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SalesManagement', FILENAME = N'E:\Database\SQLExpress\SalesManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SalesManagement_log', FILENAME = N'E:\Database\SQLExpress\SalesManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SalesManagement] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SalesManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SalesManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SalesManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SalesManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SalesManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SalesManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [SalesManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SalesManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SalesManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SalesManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SalesManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SalesManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SalesManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SalesManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SalesManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SalesManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SalesManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SalesManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SalesManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SalesManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SalesManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SalesManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SalesManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SalesManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SalesManagement] SET  MULTI_USER 
GO
ALTER DATABASE [SalesManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SalesManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SalesManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SalesManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SalesManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SalesManagement] SET QUERY_STORE = OFF
GO
USE [SalesManagement]
GO
/****** Object:  UserDefinedFunction [dbo].[TotalRevenueOfMonth]    Script Date: 12/18/2018 7:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[TotalRevenueOfMonth](@month tinyint,@year smallint)
RETURNS decimal(25,3)
AS
BEGIN
	IF @month is null  OR @month = 0 OR @month > 12
		Set @month = DATEPART(MM,GetDate())
	IF @year is null OR @year > DATEPART(YYYY,GetDate())
		Set @year = DATEPART(YYYY,GetDate())
	DECLARE @fromDate datetime = Concat(@Year,'-',@Month,'-1')
	DECLARE @toDate datetime = DATEADD(MM,1,@FromDate)
	DECLARE @total decimal(25,3) = 
		(SELECT SUM(O.TotalPerInvoice) AS  [Total]
		FROM(SELECT O.InvoiceID, O.CustomerID, TotalPerInvoice = (SUM(OD.UnitPrice*OD.Quantity)+ O.Freight)
			FROM Invoices O,  InvoiceDetails OD
			Where  O.InvoiceID  = OD.InvoiceID AND O.InvoiceDate >= @FromDate AND O.InvoiceDate < @toDate
		Group by O.InvoiceID, O.CustomerID, O.Freight) O)
	RETURN @total
END
GO
/****** Object:  UserDefinedFunction [dbo].[TotalRevenueOfQuarter]    Script Date: 12/18/2018 7:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[TotalRevenueOfQuarter](@quarter tinyint,@year smallint)
RETURNS decimal(30,3)
AS
BEGIN
	IF @year is null OR @year > DATEPART(YYYY,GetDate())
		Set @year = DATEPART(YYYY,GetDate())
	DECLARE @month tinyint 
	IF @quarter is null OR @quarter = 0 OR @quarter > 4
	BEGIN
		DECLARE @tempMonth tinyint = DATEPART(MM,GetDate())
		WHILE @tempMonth !=	 1 AND @tempMonth != 4 AND @tempMonth != 7 AND @tempMonth != 10
		BEGIN
			SET @tempMonth  = @tempMonth - 1
		END
		SET @month = @tempMonth
	END
	ELSE
		SET @month = (CASE
			WHEN @quarter = 1 then 1
			WHEN @quarter = 2 then 4
			WHEN @quarter = 3 then 7
			WHEN @quarter = 4 then 10
		END)
	DECLARE @fromDate datetime = Concat(@Year,'-',@Month,'-1')
	DECLARE @toDate datetime = DATEADD(MM,3,@FromDate)
	DECLARE @total decimal(30,3) = 
		(SELECT SUM(O.TotalPerInvoice) AS  [Total]
		FROM(SELECT O.InvoiceID, O.CustomerID, TotalPerInvoice = (SUM(OD.UnitPrice*OD.Quantity)+ O.Freight)
			FROM Invoices O,  InvoiceDetails OD
			Where  O.InvoiceID  = OD.InvoiceID AND O.InvoiceDate >= @FromDate AND O.InvoiceDate < @toDate
		Group by O.InvoiceID, O.CustomerID, O.Freight) O)
	RETURN @total
END
GO
/****** Object:  UserDefinedFunction [dbo].[TotalSpendOfCustomers]    Script Date: 12/18/2018 7:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[TotalSpendOfCustomers](@month tinyint, @year smallint)
RETURNS @Table Table
(
	CustomerID int,
	[Name] nvarchar(60),
	[TotalPurchased] int,
	[Total] decimal(18,3)
)
AS
BEGIN
	IF @month is null  OR @month = 0 OR @month > 12
		Set @month = DATEPART(MM,GetDate())
	IF @year is null OR @year > DATEPART(YYYY,GetDate())
		Set @year = DATEPART(YYYY,GetDate())
	DECLARE @fromDate datetime = Concat(@Year,'-',@Month,'-1')
	DECLARE @toDate datetime = DATEADD(MM,1,@FromDate)
	INSERT INTO @Table
		SELECT O.CustomerID AS [CustomerID], C.[Name] AS [Name],Count(*) AS [TotalPurchased],SUM(O.TotalPerInvoice) AS  [Total]
		FROM(
			SELECT O.InvoiceID, O.CustomerID, TotalPerInvoice = (SUM(OD.UnitPrice*OD.Quantity)+ O.Freight)
			FROM Invoices O,  InvoiceDetails OD
			Where  O.InvoiceID  = OD.InvoiceID AND O.InvoiceDate >= @fromDate AND O.InvoiceDate < @toDate
			Group by O.InvoiceID, O.CustomerID, O.Freight
			) O, Customers C
		WHERE O.CustomerID = C.CustomerID
		GROUP BY O.CustomerID, C.[Name]
	Return 
END
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/18/2018 7:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[Gender] [bit] NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 12/18/2018 7:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Gender] [bit] NOT NULL,
	[ID] [varchar](12) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[JobTitle] [nvarchar](10) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 12/18/2018 7:35:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [decimal](10, 3) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 12/18/2018 7:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[Freight] [decimal](10, 3) NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/18/2018 7:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NOT NULL,
	[AddedDate] [datetime] NOT NULL,
	[QuantityPerUnit] [nvarchar](30) NULL,
	[UnitPrice] [decimal](10, 0) NOT NULL,
	[UnitsInStock] [int] NOT NULL,
	[UnitsOnInvoice] [int] NOT NULL,
	[Discontinued] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InvoiceDetails] ADD  CONSTRAINT [DF_InvoiceDetails_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[InvoiceDetails] ADD  CONSTRAINT [DF_InvoiceDetails_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Invoices] ADD  CONSTRAINT [DF_Invoices_Freight]  DEFAULT ((0)) FOR [Freight]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UnitPrice]  DEFAULT ((0)) FOR [UnitPrice]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UnitsInStock]  DEFAULT ((0)) FOR [UnitsInStock]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_UnitsOnInvoice]  DEFAULT ((0)) FOR [UnitsOnInvoice]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_Discontinued]  DEFAULT ((0)) FOR [Discontinued]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[Invoices] ([InvoiceID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Invoices]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_Products]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Customers]
GO
ALTER TABLE [dbo].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Invoices] CHECK CONSTRAINT [FK_Invoices_Employees]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_UnitsInStock] CHECK  (([UnitsInStock]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_UnitsInStock]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [CK_Products_UnitsOnInvoice] CHECK  (([UnitsOnInvoice]>=(0)))
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_UnitsOnInvoice]
GO
USE [master]
GO
ALTER DATABASE [SalesManagement] SET  READ_WRITE 
GO
