CREATE TABLE [dbo].[WordWordleWrongGuess] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Word] VARCHAR (15) NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_WordWordleWrongGuess] PRIMARY KEY CLUSTERED ([Id] ASC)
);

