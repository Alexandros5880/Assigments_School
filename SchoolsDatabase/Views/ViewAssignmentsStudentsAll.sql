CREATE VIEW [dbo].[ViewAssignmentsStudentsAll]
	AS
	SELECT
	a.Id AS A_ID, a.Title, s.FirstName + s.LastName AS S_Name, s.Email
	FROM Assignments AS a
	FULL JOIN AssignmentsStudents AS ass
	ON ass.AssignmentTitle = a.Title
	FULL JOIN Students AS s
	ON ass.StudentEmail = s.Email;