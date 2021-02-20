create view vUserTasks as 
select UserTasks.UserId,
		Tasks.TaskId,
		Tasks.Name as TaskName,
		Tasks.Description,
		Tasks.StartDate,
		Tasks.DeadlineDate,
		TaskStates.StateName as State
from [UserTasks] inner join [Tasks] on UserTasks.TaskId = Tasks.TaskId
inner join [TaskStates] on UserTasks.StateId = TaskStates.StateId