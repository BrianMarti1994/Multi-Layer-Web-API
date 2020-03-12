USE [VehicleDb]
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 19/02/2020 23:06:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE DATABASE VehicleDb;


USE [VehicleDb]
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 12/03/2020 10:11:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleMake](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Abrv] [nvarchar](50) NULL,
 CONSTRAINT [PK_VehicleMake] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 12/03/2020 10:11:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehicleModel](
	[Id] [int] NOT NULL,
	[MakeId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Abrv] [nvarchar](50) NULL,
 CONSTRAINT [PK_VehicleModel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[VehicleModel]  WITH CHECK ADD  CONSTRAINT [FK_VehicleMake_Id] FOREIGN KEY([MakeId])
REFERENCES [dbo].[VehicleMake] ([Id])
GO
ALTER TABLE [dbo].[VehicleModel] CHECK CONSTRAINT [FK_VehicleMake_Id]
GO
