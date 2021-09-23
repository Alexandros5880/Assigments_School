CREATE VIEW [dbo].[ViewCourseTrainersStudentsAll]
	AS
	SELECT 
		c.Id AS C_ID, c.Title, c.Description,
		t.Id AS T_ID, t.FirstName + t.LastName AS T_Name, t.Email AS T_Email,
		s.Id AS S_ID, s.FirstName + s.LastName AS S_Name, s.Email AS S_Email 
		FROM Courses AS c
		FULL JOIN TrainersCourse AS tc
		ON tc.CourseTitle = c.Title
		FULL JOIN Trainers AS t
		ON tc.TrainerEmail = t.Email
		FULL JOIN StudentsCourse sc
		ON sc.CourseTitle = c.Title
		FULL JOIN Students AS s
		ON sc.StudentEmail = s.Email;
