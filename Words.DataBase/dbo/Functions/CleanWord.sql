CREATE FUNCTION dbo.CleanWord (
    @word NVARCHAR(100)
)
RETURNS NVARCHAR(100)
AS
BEGIN
    DECLARE @pos INT, @result NVARCHAR(100)

    -- Buscar la posición del primer "/"
    SET @pos = CHARINDEX('/', @word)

    -- Si hay "/", cortar hasta esa posición - 1
    IF @pos > 0
        SET @result = LEFT(@word, @pos - 1)
    ELSE
		SET @result = @word
	RETURN @result
END