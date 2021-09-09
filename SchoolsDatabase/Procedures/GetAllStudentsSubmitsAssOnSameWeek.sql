CREATE PROCEDURE GetAllStudentsSubmitsAssOnSameWeek
AS
BEGIN
DECLARE @numGivenWeekDate AS VARCHAR(100)=(SELECT DATEPART(week, (SELECT CONVERT(DATE, (SELECT CAST( GETDATE() AS Date)), 103)))),
		@numNowWeekDate AS VARCHAR(100)=(SELECT DATEPART(week, (SELECT CAST( GETDATE() AS Date ))));
SELECT * FROM Students WHERE Email IN (SELECT StudentEmail FROM AssignmentsStudents WHERE AssignmentTitle IN 
                                        (SELECT Title FROM Assignments WHERE @numGivenWeekDate = @numGivenWeekDate ));
END
RETURN 0
