CREATE VIEW [dbo].[vUserProgress]
    AS SELECT
        UserProfiles.UserId,
        UserTasks.TaskId,
        TaskTracks.TaskTrackId,
        (UserProfiles.FirstName + ' ' + UserProfiles.LastName) as UserName,
        Tasks.[Name] as TaskName,
        TaskTracks.TrackNote,
        TaskTracks.TrackDate
        FROM UserProfiles
        INNER JOIN UserTasks on UserProfiles.UserId = UserTasks.UserId
        INNER JOIN TaskTracks on UserTasks.TaskId = TaskTracks.UserTaskId
        INNER JOIN Tasks on UserTasks.TaskId = Tasks.TaskId