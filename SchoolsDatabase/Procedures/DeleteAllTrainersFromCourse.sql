CREATE PROCEDURE [dbo].[DeleteAllTrainersFromCourse]
	@title VARCHAR(100)
AS
BEGIN
	DELETE FROM TrainersCourses WHERE CourseTitle = @title
END
RETURN 0
