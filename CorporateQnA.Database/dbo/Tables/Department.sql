﻿CREATE TABLE [dbo].[Department] (
    [Id]    UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Title] NVARCHAR (150)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Title] ASC)
);
