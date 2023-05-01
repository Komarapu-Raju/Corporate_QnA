CREATE TABLE [dbo].[Category] (
    [Id]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Title]       NVARCHAR (100)   NOT NULL,
    [Description] NVARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Title] ASC)
);

