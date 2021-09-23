CREATE PROCEDURE GetAllAssignmentsOfCourses 
@title VARCHAR(100)
AS
BEGIN
SELECT * FROM Assignments ass WHERE Title IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle=@title);
END
RETURN 0
