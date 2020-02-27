USE [VehicleDb]
GO
/****** Object:  Table [dbo].[VehicleMake]    Script Date: 19/02/2020 23:06:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE DATABASE VehicleDb;


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
/****** Object:  Table [dbo].[VehicleModel]    Script Date: 19/02/2020 23:06:13 ******/
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
/****** Object:  StoredProcedure [dbo].[SpDeleteVehicle]    Script Date: 19/02/2020 23:06:13 ******/
SET ANSI_NULLS ON
GO