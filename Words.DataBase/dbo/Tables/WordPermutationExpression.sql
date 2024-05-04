CREATE TABLE [dbo].[WordPermutationExpression] (
    [WordId]               INT           NOT NULL,
    [WordSimpleValue]      VARCHAR (50)  NOT NULL,
    [LettersSorted]        VARCHAR (50)  NOT NULL,
    [LettersSet]           VARCHAR (50)  NOT NULL,
    [LettersSetOcurrences] BIGINT        NOT NULL,
    [PermutationRegExp]    VARCHAR (150) NOT NULL,
    CONSTRAINT [PK_WordPermutationExpression] PRIMARY KEY CLUSTERED ([WordId] ASC),
    FOREIGN KEY ([WordId]) REFERENCES [dbo].[Word] ([Id]),
    UNIQUE NONCLUSTERED ([WordId] ASC),
    UNIQUE NONCLUSTERED ([WordSimpleValue] ASC)
);

