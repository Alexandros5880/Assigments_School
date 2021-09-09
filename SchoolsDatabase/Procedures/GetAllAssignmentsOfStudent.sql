CREATE PROCEDURE GetAllAssignmentsOfStudent @email VARCHAR(300)
AS
BEGIN
SELECT * FROM Assignments WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail=@email);
END
RETURN 0
