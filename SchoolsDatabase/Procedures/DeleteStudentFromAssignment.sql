CREATE PROCEDURE DeleteStudentFromAssignment @studentemail VARCHAR(100),  @assignmenttitle VARCHAR(100)
AS
BEGIN
DELETE FROM AssignmentsStudents WHERE AssignmentTitle=@assignmenttitle AND StudentEmail=@studentemail;
END
RETURN 0
