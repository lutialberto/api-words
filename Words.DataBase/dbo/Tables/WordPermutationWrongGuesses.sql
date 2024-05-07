CREATE TABLE [dbo].[WordPermutationWrongGuesses] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [WrongGuesses] VARCHAR (250) NOT NULL,
    [Letters]      VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_WordPermutationWrongGuesses] PRIMARY KEY CLUSTERED ([Id] ASC)
);



