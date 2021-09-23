CREATE PROCEDURE GetCourseTitleByAssignmentTitle
@title VARCHAR(100)
AS
BEGIN
SELECT TOP 1 CourseTitle FROM AssignmentsCourse WHERE AssignmentTitle=@title;
END
RETURN 0
