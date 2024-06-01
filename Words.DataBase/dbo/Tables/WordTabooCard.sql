CREATE TABLE [dbo].[WordTabooCard] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [WordToGuess]        VARCHAR (50)  NOT NULL,
    [UnmentionableWords] VARCHAR (400) NOT NULL,
    CONSTRAINT [PK_WordTabooCard] PRIMARY KEY CLUSTERED ([Id] ASC)
);

