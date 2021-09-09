CREATE PROCEDURE GetAllStudentsSubmitsAssOnSameWeekAsDate @date VARCHAR(30)
AS
BEGIN
DECLARE @week AS INT=(SELECT DATEPART(week, (SELECT CONVERT(DATE, @date, 103))));
SELECT * FROM Students WHERE Email IN
                             (SELECT StudentEmail FROM AssignmentsStudents
                             WHERE AssignmentTitle IN
                                   (SELECT Title FROM Assignments
                                   WHERE (SELECT DATEPART(week, (SELECT CONVERT(DATE, EndDate, 103)))) = @week));
END
RETURN 0
