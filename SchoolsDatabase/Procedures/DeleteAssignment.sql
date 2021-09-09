CREATE PROCEDURE DeleteAssignment @assignmenttitle VARCHAR(100)
AS
BEGIN
DELETE FROM AssignmentsCourse WHERE AssignmentTitle=@assignmenttitle;
DELETE FROM AssignmentsStudents WHERE AssignmentTitle=@assignmenttitle;
DELETE FROM Assignments WHERE Title=@assignmenttitle;
END
RETURN 0
