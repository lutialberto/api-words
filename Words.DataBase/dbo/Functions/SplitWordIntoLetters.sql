CREATE FUNCTION SplitWordIntoLetters
(
	@Word VARCHAR(50)
)
RETURNS 
@Letters TABLE (Letter char)
AS
BEGIN
	INSERT @Letters
	SELECT 
		SUBSTRING(word,Number,1) AS letter
	FROM (SELECT @Word as word) as t
	INNER JOIN master.dbo.spt_values 
		ON Number BETWEEN 1 AND LEN(word)
		AND type='P'

	RETURN
END