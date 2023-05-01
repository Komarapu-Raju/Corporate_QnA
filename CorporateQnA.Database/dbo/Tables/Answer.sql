CREATE TABLE [dbo].[Answer] (
    [Id]             UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [QuestionId]     UNIQUEIDENTIFIER NOT NULL,
    [Description]    NVARCHAR (MAX)   NOT NULL,
    [AnsweredBy]     UNIQUEIDENTIFIER NOT NULL,
    [AnsweredOn]     DATETIME         DEFAULT (getdate()) NULL,
    [IsBestSolution] BIT              DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AnsweredBy]) REFERENCES [dbo].[Employee] ([Id]),
    FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id])
);

