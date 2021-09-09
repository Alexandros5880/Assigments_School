CREATE PROCEDURE [dbo].[GetAllAssignmentsPerCourseAndStudentByIds]
 @c_id INT,
 @s_id INT
AS
BEGIN

DECLARE @MyCourseTitle AS NVARCHAR(100);
SELECT @MyCourseTitle = Title FROM Courses WHERE Id=@c_id;

DECLARE @MyStudentEmail AS NVARCHAR(300);
SELECT @MyStudentEmail = Email FROM Students WHERE Id=@s_id;

EXEC GetAllAssignmentsPerCourseAndStudent @MyCourseTitle, @MyStudentEmail;

END
RETURN 0
