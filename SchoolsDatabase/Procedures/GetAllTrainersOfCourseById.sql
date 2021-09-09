CREATE PROCEDURE [dbo].[GetAllTrainersOfCourseById]
	@id int = 0
AS
BEGIN
SELECT * FROM Trainers st WHERE Email IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle 
IN (SELECT TOP 1 Title FROM Courses WHERE Id = @id));
END
RETURN 0
