CREATE PROCEDURE GetAllStudentsOfAssignment  @title VARCHAR(100)
AS
BEGIN
SELECT * FROM Students WHERE Email IN
(SELECT StudentEmail FROM AssignmentsStudents WHERE AssignmentTitle=@title);
END
RETURN 0
