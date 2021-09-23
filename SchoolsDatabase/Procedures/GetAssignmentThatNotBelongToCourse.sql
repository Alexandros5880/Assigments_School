CREATE PROCEDURE [dbo].[GetAssignmentThatNotBelongToCourse]
@title VARCHAR(100)
AS
BEGIN
SELECT * FROM Assignments ass WHERE Title NOT IN (SELECT AssignmentTitle FROM AssignmentsCourse WHERE CourseTitle=@title);
END
RETURN 0
