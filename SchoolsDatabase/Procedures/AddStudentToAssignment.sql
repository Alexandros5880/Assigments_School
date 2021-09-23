CREATE PROCEDURE [dbo].[AddStudentToAssignment]
@assignmenttitle VARCHAR(100), 
@studentemail VARCHAR(100)
AS
BEGIN
INSERT INTO AssignmentsStudents(StudentEmail, AssignmentTitle) VALUES (@studentemail, @assignmenttitle);
END
RETURN 0
