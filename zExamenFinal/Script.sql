USE [Exam]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 18/8/2021 17:18:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[Id] [int] NOT NULL,
	[InvoiceHeaderId] [int] NOT NULL,
	[MaterialId] [int] NOT NULL,
	[Quantity] [decimal](16, 2) NOT NULL,
	[Discount] [decimal](16, 2) NOT NULL,
	[TotalLine] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceHeader]    Script Date: 18/8/2021 17:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceHeader](
	[Id] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[TotalAmount] [decimal](16, 2) NOT NULL,
	[TotalTax] [decimal](16, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceHeader] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 18/8/2021 17:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Detail] [varchar](200) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
 CONSTRAINT [PK_Material] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 18/8/2021 17:18:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InvoiceDetail] ADD  CONSTRAINT [DF_InvoiceDetail_Discount]  DEFAULT ((0)) FOR [Discount]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_InvoiceHeader] FOREIGN KEY([InvoiceHeaderId])
REFERENCES [dbo].[InvoiceHeader] ([Id])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_InvoiceHeader]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Material] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Material]
GO
ALTER TABLE [dbo].[Material]  WITH CHECK ADD  CONSTRAINT [FK_Material_User] FOREIGN KEY([CreateUserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Material] CHECK CONSTRAINT [FK_Material_User]
GO
