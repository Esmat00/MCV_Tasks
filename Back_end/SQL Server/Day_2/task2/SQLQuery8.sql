/* CREATE PROCEDURE IncreaseSalariesByRange
AS
BEGIN
    UPDATE Emp
    SET salary = salary * 1.30
    WHERE salary between 1000 AND 3000;

    UPDATE Emp
    SET salary = salary * 1.40
    WHERE salary between 3000 AND 9000;

    UPDATE Emp
    SET salary = salary * 1.50
    WHERE salary >= 9000;
END;

*/


-- exec IncreaseSalariesByRange;
select * from Emp