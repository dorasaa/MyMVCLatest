CREATE TABLE TestTable
(
    Column1 INT,
    Column2 INT,
    Column3 INT
)
GO
 
-- Insert some test data
DECLARE @i INT = 0
 
WHILE (@i < 10000)
BEGIN
    INSERT INTO TestTable VALUES (@i, @i + 1, @i + 2)
    SET @i += 1
END
GO



BEGIN TRANSACTION
 
-- Add a new column
-- DDL statements require a Sch-M lock on the objects that are modified.
-- In this case, the table "TestTable" gets a Sch-M lock (Schema modification lock)!
ALTER TABLE TestTable ADD Column4 INT

commit;