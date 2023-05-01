CREATE TABLE [dbo].[Question] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Title]       NVARCHAR (255)   NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    [CategoryId]  UNIQUEIDENTIFIER NOT NULL,
    [CreatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [CreatedOn]   DATETIME         DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    FOREIGN KEY ([CreatedBy]) REFERENCES [dbo].[Employee] ([Id])
);

