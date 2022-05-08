USE [TAL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Occupation]') AND type in (N'U'))
DROP TABLE [dbo].[Occupation]
GO

CREATE TABLE [dbo].[Occupation](
	[Id] [int] NOT NULL PRIMARY KEY,
	[Name] [varchar] (64) NOT NULL,
    [Created] [datetime] NULL DEFAULT GETDATE(),
    [CreatedBy] [nvarchar](255) NULL DEFAULT SUSER_NAME(),
    [Updated] [datetime] NULL DEFAULT GETDATE(),
    [UpdatedBy] [nvarchar](255) NULL DEFAULT SUSER_NAME(),
    [IsDeleted] [bit] NULL DEFAULT 0
) ON [PRIMARY]
GO

--

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Member]') AND type in (N'U'))
DROP TABLE [dbo].[Member]
GO

CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Name] [varchar] (128) NOT NULL,
	[DOB] [DATE] NOT NULL,
	[OccupationId] [int] FOREIGN KEY REFERENCES Occupation(Id),
    [Created] [datetime] NULL DEFAULT GETDATE(),
    [CreatedBy] [nvarchar](255) NULL DEFAULT SUSER_NAME(),
    [Updated] [datetime] NULL DEFAULT GETDATE(),
    [UpdatedBy] [nvarchar](255) NULL DEFAULT SUSER_NAME(),
    [IsDeleted] [bit] NULL DEFAULT 0
) ON [PRIMARY]

GO