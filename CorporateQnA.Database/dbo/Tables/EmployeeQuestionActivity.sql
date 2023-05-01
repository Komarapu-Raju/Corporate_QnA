CREATE TABLE [dbo].[EmployeeQuestionActivity] (
    [Id]         UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [QuestionId] UNIQUEIDENTIFIER NOT NULL,
    [EmployeeId] UNIQUEIDENTIFIER NOT NULL,
    [ViewedOn]   DATETIME         DEFAULT (getdate()) NULL,
    [VoteStatus] INT              DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employee] ([Id]),
    FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([Id]),
    CONSTRAINT [Unique_Que_Emp] UNIQUE NONCLUSTERED ([QuestionId] ASC, [EmployeeId] ASC)
);

