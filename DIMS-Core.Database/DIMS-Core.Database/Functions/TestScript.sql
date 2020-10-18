-- tests for functions --
-- GetFullAge
declare @BirthOfDate datetime;

set @BirthOfDate = '1993-10-28';

select dbo.GetFullAge(@BirthOfDate)

-- add here next one function with sample how to chek it