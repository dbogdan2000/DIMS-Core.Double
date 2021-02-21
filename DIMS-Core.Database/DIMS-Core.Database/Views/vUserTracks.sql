CREATE VIEW [dbo].[vUserTracks]
	AS SELECT 
		UserTasks.UserId,
		Tasks.TaskId,
		TaskTracks.TaskTrackId,
		Tasks.[Name] as TaskName,
		TaskTracks.TrackNote,
		TaskTracks.TrackDate
		FROM UserTasks
		INNER JOIN TaskTracks on UserTasks.TaskId = TaskTracks.UserTaskId
		INNER JOIN Tasks on UserTasks.TaskId = Tasks.TaskId
