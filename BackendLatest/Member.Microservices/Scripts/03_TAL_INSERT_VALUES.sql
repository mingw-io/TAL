USE [TAL]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- SET IDENTITY_INSERT [dbo].[Occupation] ON

INSERT INTO [dbo].[Occupation] ([Id], [Name]) 
VALUES (1, 'Cleaner'), (2, 'Doctor'), (3, 'Author'), (4,'Farmer'), (5,'Mechanic'), (6,'Florist')

-- SET IDENTITY_INSERT [dbo].[Occupation] OFF

GO

SET IDENTITY_INSERT [dbo].[Member] ON

INSERT INTO [dbo].[Member] ([Id], [Name], [DOB], [OccupationId]) 
VALUES (1, 'Sergio', '1980-01-26', 3)

SET IDENTITY_INSERT [dbo].[Member] OFF

GO