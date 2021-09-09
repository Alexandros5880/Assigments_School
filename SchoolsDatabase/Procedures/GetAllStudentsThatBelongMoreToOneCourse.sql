CREATE PROCEDURE GetAllStudentsThatBelongMoreToOneCourse
AS
BEGIN
SELECT * FROM Students st WHERE Email IN (SELECT StudentEmail FROM StudentsCourse GROUP BY StudentEmail HAVING COUNT(*) > 1);
END
RETURN 0
