USE [pp_lab2]
GO
/****** Object:  Table [dbo].[Requests]    Script Date: 05.04.2020 13:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Requests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
 CONSTRAINT [PK_Requests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceRequest]    Script Date: 05.04.2020 13:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceRequest](
	[service_id] [int] NOT NULL,
	[request_id] [int] NOT NULL,
 CONSTRAINT [PK_ServiceRequest] PRIMARY KEY CLUSTERED 
(
	[service_id] ASC,
	[request_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Services]    Script Date: 05.04.2020 13:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[price] [float] NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05.04.2020 13:48:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Requests]  WITH CHECK ADD  CONSTRAINT [FK_Requests_Users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Requests] CHECK CONSTRAINT [FK_Requests_Users]
GO
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequest_Requests] FOREIGN KEY([request_id])
REFERENCES [dbo].[Requests] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FK_ServiceRequest_Requests]
GO
ALTER TABLE [dbo].[ServiceRequest]  WITH CHECK ADD  CONSTRAINT [FK_ServiceRequest_Services] FOREIGN KEY([service_id])
REFERENCES [dbo].[Services] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ServiceRequest] CHECK CONSTRAINT [FK_ServiceRequest_Services]
GO
