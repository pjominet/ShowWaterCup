CREATE TABLE [swc].[PlayerAI] (
    [AiId]     INT NOT NULL,
    [PlayerId] INT NOT NULL,
    CONSTRAINT [aiId_pk] PRIMARY KEY CLUSTERED ([AiId] ASC),
    FOREIGN KEY ([PlayerId]) REFERENCES [swc].[Player] ([Id])
);

