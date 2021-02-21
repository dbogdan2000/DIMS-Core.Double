CREATE VIEW [dbo].[vUserTracks]
	AS SELECT 
		UserProfiles.UserId,
		Tasks.TaskId,
		TaskTracks.TaskTrackId,
		Tasks.[Name] as TaskName,
		TaskTracks.TrackNote,
		TaskTracks.TrackDate
		FROM UserProfiles
		INNER JOIN UserTasks on UserProfiles.UserId = UserTasks.UserId
		INNER JOIN TaskTracks on UserTasks.TaskId = TaskTracks.UserTaskId
		INNER JOIN Tasks on UserTasks.TaskId = Tasks.TaskId
