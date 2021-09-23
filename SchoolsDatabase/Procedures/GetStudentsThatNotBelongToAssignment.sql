CREATE PROCEDURE [dbo].[GetStudentsThatNotBelongToAssignment]
@title VARCHAR(100)
AS
BEGIN
SELECT * FROM Students WHERE Email NOT IN
(SELECT StudentEmail FROM AssignmentsStudents WHERE AssignmentTitle=@title);
END
RETURN 0
