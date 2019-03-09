CREATE TABLE [swc].[Player] (
    [Id]           INT           NOT NULL,
    [Name]         VARCHAR (100) NULL,
    [CharacterId]  INT           NOT NULL,
    [HitPoints]    INT           NULL,
    [PositionId]   INT           NULL,
    [ActionPoints] INT           NULL,
    [AiId]         INT           NULL,
    CONSTRAINT [id_pk] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AiId]) REFERENCES [swc].[PlayerAI] ([AiId]),
    FOREIGN KEY ([CharacterId]) REFERENCES [nomenclature].[Character] ([CharacterId]),
    FOREIGN KEY ([PositionId]) REFERENCES [swc].[Position] ([PositionId])
);

