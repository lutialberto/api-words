CREATE PROCEDURE WordTabooCard_Insert 
	@WordToGuess VARCHAR(50), 
	@UnmentionableWords VARCHAR(400)
AS
BEGIN
	DECLARE @FormattedWordToGuess VARCHAR(50) = TRIM(LOWER(@WordToGuess));
	DECLARE @FormattedUnmentionableWords VARCHAR(400) = TRIM(LOWER(@UnmentionableWords));

	IF(NOT EXISTS(
		SELECT 1 
		FROM WordTabooCard
		WHERE WordToGuess = @FormattedWordToGuess
	)) 
	BEGIN
		INSERT INTO WordTabooCard(
			WordToGuess,
			UnmentionableWords
		) 
		VALUES(
			@FormattedWordToGuess,
			@FormattedUnmentionableWords
		)
	END
END