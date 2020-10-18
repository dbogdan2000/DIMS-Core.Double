CREATE TABLE [dbo].[Directions]
(
	[DirectionId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(250) NULL,
)
