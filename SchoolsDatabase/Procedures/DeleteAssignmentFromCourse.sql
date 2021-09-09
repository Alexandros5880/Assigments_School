CREATE PROCEDURE DeleteAssignmentFromCourse @coursetitle VARCHAR(200), @assignmenttitle VARCHAR(200)
AS
BEGIN
DELETE FROM AssignmentsCourse WHERE CourseTitle=@coursetitle AND AssignmentTitle=@assignmenttitle;
END
RETURN 0
