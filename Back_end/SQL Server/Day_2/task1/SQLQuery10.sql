use test
DECLARE @Rank INT = 2;  

WITH SalaryRanks AS (
    SELECT 
        E.EmpID,
        E.EmpName,
        E.JobTitle,
        E.Salary,
        D.DepName,
        DENSE_RANK() OVER (ORDER BY E.Salary DESC) AS SalaryRank
    FROM Emp E
    JOIN Dep D ON E.DepID = D.DepID
)

SELECT 
    EmpID,
    EmpName,
    JobTitle,
    Salary,
    DepName,
    SalaryRank
FROM SalaryRanks
WHERE SalaryRank = @Rank;
