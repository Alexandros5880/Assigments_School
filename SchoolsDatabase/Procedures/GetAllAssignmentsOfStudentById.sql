CREATE PROCEDURE [dbo].[GetAllAssignmentsOfStudentById]
	@id int = 0
AS
BEGIN
SELECT * FROM Assignments WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail 
IN (SELECT TOP 1 Email FROM Students WHERE Id = @id));
END
RETURN 0
