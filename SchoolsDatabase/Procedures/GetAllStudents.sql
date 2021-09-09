CREATE PROCEDURE [dbo].[GetAllStudents]
	AS
BEGIN
	SELECT * FROM [dbo].[Students];
	RETURN 0
END