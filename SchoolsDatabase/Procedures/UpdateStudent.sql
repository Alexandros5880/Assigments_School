CREATE PROCEDURE UpdateStudent @firstname VARCHAR(50), @lastname VARCHAR(50), @age INT, 
								@gender VARCHAR(10), @email VARCHAR(300), @phone VARCHAR(15), @searchemail VARCHAR(300)
AS
BEGIN
UPDATE Students SET FirstName=@firstname, LastName=@lastname, Age=@age, Gender=@gender, Email=@email, Phone=@phone WHERE Email=@searchemail;
END
RETURN 0
