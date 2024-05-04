DECLARE @WordId INT;
DECLARE word_cursor CURSOR
    FOR SELECT Id FROM Word
OPEN word_cursor
FETCH NEXT FROM word_cursor INTO @WordId

WHILE @@FETCH_STATUS = 0
BEGIN
	EXEC WordPermutationExpression_Insert @WordId
	FETCH NEXT FROM word_cursor INTO @WordId
END
CLOSE word_cursor;
DEALLOCATE word_cursor;