CREATE PROCEDURE InsertTrainer @firstname VARCHAR(50), @lastname VARCHAR(50), @age VARCHAR(15), 
								@gender VARCHAR(10), @startdate VARCHAR(30), @email VARCHAR(300), @phone VARCHAR(15)
AS
BEGIN
INSERT INTO Trainers (FirstName, LastName, Age, Gender, StartDate, Email, Phone) VALUES (@firstname, @lastname, @age, @gender, @startdate, @email, @phone);
END
RETURN 0
