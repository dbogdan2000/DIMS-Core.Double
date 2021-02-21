create view vTasks as 
select Tasks.TaskId,
		Tasks.Name,
		Tasks.Description,
		Tasks.StartDate,
		Tasks.DeadlineDate
from [Tasks]