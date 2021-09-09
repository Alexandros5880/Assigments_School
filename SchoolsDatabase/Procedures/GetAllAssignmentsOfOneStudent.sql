CREATE PROCEDURE GetAllAssignmentsOfOneStudent @coursetitle VARCHAR(100), @studentemail VARCHAR(300)
AS
BEGIN
SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle=@coursetitle)
                                AND Title IN (SELECT AssignmentTitle FROM AssignmentsStudents WHERE StudentEmail=@studentemail);
END
RETURN 0
