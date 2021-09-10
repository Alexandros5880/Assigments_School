CREATE PROCEDURE DeleteTrainer @email VARCHAR(300)
AS
BEGIN
DELETE FROM TrainersCourses WHERE TrainerEmail=@email;
DELETE FROM Trainers WHERE Email=@email;
END
RETURN 0
