create table [dbo].[UserTasks]
(
	[UserTaskId] INT NOT NULL PRIMARY KEY IDENTITY,
	[TaskId] INT NOT NULL,
	[UserId] INT NOT NULL,
	[StateId] INT NOT NULL

	FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
	FOREIGN KEY (UserId) REFERENCES UserProfiles(UserId),
	FOREIGN KEY (StateId) REFERENCES TaskStates(StateId),
)