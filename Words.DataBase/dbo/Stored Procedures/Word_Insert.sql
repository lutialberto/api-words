CREATE PROCEDURE [dbo].[Word_Insert] 
	@Value VARCHAR(50), 
	@SimpleValue VARCHAR(50) = NULL
AS
BEGIN
	DECLARE @CleanValue VARCHAR(50) = dbo.CleanWord(@Value);
	DECLARE @CleanSimpleValue VARCHAR(50) = dbo.CleanWord(@SimpleValue);
	DECLARE @FormattedValue VARCHAR(50) = TRIM(LOWER(@CleanValue));

	IF(NOT EXISTS(
		SELECT 1 
		FROM Word 
		WHERE [Value] = @FormattedValue
	)) 
	BEGIN
		DECLARE @FormattedSimpleValue VARCHAR(50) = TRIM(LOWER((ISNULL(@CleanSimpleValue,@FormattedValue))))

		SET @FormattedSimpleValue = REPLACE(@FormattedSimpleValue,'á','a')
		SET @FormattedSimpleValue = REPLACE(@FormattedSimpleValue,'é','e')
		SET @FormattedSimpleValue = REPLACE(@FormattedSimpleValue,'í','i')
		SET @FormattedSimpleValue = REPLACE(@FormattedSimpleValue,'ó','o')
		SET @FormattedSimpleValue = REPLACE(@FormattedSimpleValue,'ú','u')
		SET @FormattedSimpleValue = REPLACE(@FormattedSimpleValue,'ü','u')

		INSERT INTO Word (
			[Value],
			SimpleValue
		) 
		VALUES(
			@FormattedValue, 
			@FormattedSimpleValue
		)
	END
END
GO
