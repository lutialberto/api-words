CREATE PROCEDURE WordPermutationExpression_Insert 
	@WordId INT
AS
BEGIN
	DECLARE @WordSimpleValue VARCHAR(50) = NULL,
			@ExistsExpression BIT = 0
	
	SELECT 
		@WordSimpleValue = w.SimpleValue,
		@ExistsExpression = IIF(wpe.WordId IS NOT NULL,1,0)
	FROM Word AS w 
	LEFT JOIN WordPermutationExpression AS wpe 
	ON w.Id = wpe.WordId
	WHERE w.Id = @WordId

	IF(@WordSimpleValue IS NOT NULL AND @ExistsExpression = 0) 
	BEGIN
		IF OBJECT_ID('tempdb..#letters') IS NOT NULL DROP TABLE #letters
		select letter into #letters from (SELECT letter FROM SplitWordIntoLetters(@WordSimpleValue)) letters

		IF OBJECT_ID('tempdb..#lettersSorted') IS NOT NULL DROP TABLE #lettersSorted
		select letter into #lettersSorted FROM #letters order by letter

		DECLARE @Letters VARCHAR (100) = (
			SELECT STRING_AGG (letter, '') 
			FROM #letters
		),
				@LettersSorted VARCHAR (50) = (
			SELECT STRING_AGG (letter, '') 
			FROM (
				SELECT TOP 150 letter 
				FROM #lettersSorted 
				order by letter
			) asd
		),
				@LettersSet VARCHAR (50) = (
			SELECT STRING_AGG (letter, '') 
			FROM (
				SELECT distinct letter 
				FROM #letters
			) dsa
		),
				@LettersSetOcurrences VARCHAR (50) = (
			SELECT STRING_AGG (letter, '') 
			FROM (
				SELECT COUNT(letter) letter 
				FROM (
					SELECT TOP 150 letter
					FROM #lettersSorted 
					order by letter
				) asd1
			group by letter 
			) asd2
		),
				@PermutationRegExp VARCHAR (150) = '^('+(
			SELECT STRING_AGG (letter+'{0,'+CAST(n AS VARCHAR(1))+'}', '') 
			FROM (
				SELECT COUNT(letter) n,letter
				FROM (
					SELECT TOP 150 letter
					FROM #lettersSorted 
					order by letter
				) asd1
			group by letter 
			) asd2
		)+')$'

		INSERT INTO WordPermutationExpression (
			 WordId
			,WordSimpleValue
			,LettersSorted
			,LettersSet
			,LettersSetOcurrences
			,PermutationRegExp
		) 
		VALUES(
			 @WordId
			,@WordSimpleValue
			,@LettersSorted
			,@LettersSet
			,CAST(@LettersSetOcurrences AS BIGINT)
			,@PermutationRegExp
		)
	END
END