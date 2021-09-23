CREATE PROCEDURE [dbo].[GetTrainersThaNotBelongToCourse]
@title VARCHAR(100)
AS
BEGIN
SELECT * FROM Trainers tr WHERE Email NOT IN (SELECT TrainerEmail FROM TrainersCourse WHERE CourseTitle=@title);
END
RETURN 0
