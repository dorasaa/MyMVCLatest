
-- The statement is now blocking, even with the NOLOCK query hint!
-- SQL Server has to compile the query, and requests a Sch-S lock (Schema Stability lock).
-- This lock is incompatible with the Sch-M lock!


--set transaction isolation level read uncommitted
SELECT * FROM TestTable  WITH (NOLOCK)
GO