CREATE PROCEDURE DeleteStudent @email VARCHAR(300)
AS
BEGIN
DELETE FROM StudentsCourse WHERE StudentEmail = @email;
DELETE FROM AssignmentsStudents WHERE StudentEmail = @email;
DELETE FROM Students WHERE Email=@email;END
RETURN 0
