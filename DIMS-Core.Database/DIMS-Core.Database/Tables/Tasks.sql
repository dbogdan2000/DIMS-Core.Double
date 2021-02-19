create table [dbo].[Tasks]
(
	[TaskId] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	[Description] NVARCHAR(255) NULL,
	[StartDate] DATETIME NOT NULL,
	[DeadlineDate] DATETIME NOT NULL,
)