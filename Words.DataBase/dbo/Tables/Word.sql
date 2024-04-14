CREATE TABLE [dbo].[Word] (
    [Id]          INT IDENTITY(1,1)         NOT NULL,
    [Value]       VARCHAR (50) UNIQUE NOT NULL,
    [SimpleValue] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Word] PRIMARY KEY CLUSTERED ([Id] ASC)
);

