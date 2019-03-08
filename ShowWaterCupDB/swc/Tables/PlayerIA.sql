CREATE TABLE [swc].[PlayerIA] (
    [AiId]         INT NOT NULL,
    [PlayerId]     INT NOT NULL,
    [ActionNumber] INT NULL,
    CONSTRAINT [aiId_pk] PRIMARY KEY CLUSTERED ([AiId] ASC),
    FOREIGN KEY ([PlayerId]) REFERENCES [swc].[Player] ([Id])
);

