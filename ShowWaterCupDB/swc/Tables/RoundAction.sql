CREATE TABLE [swc].[RoundAction] (
    [ActionId]     INT           NOT NULL,
    [PlayerId]     INT           NOT NULL,
    [ActionTypeId] INT           NOT NULL,
    [Target]       VARCHAR (100) NOT NULL,
    [RoundId]      INT           NOT NULL,
    CONSTRAINT [actionId_pk] PRIMARY KEY CLUSTERED ([ActionId] ASC),
    FOREIGN KEY ([ActionTypeId]) REFERENCES [nomenclature].[ActionType] ([ActionTypeId]),
    FOREIGN KEY ([PlayerId]) REFERENCES [swc].[Player] ([Id]),
    FOREIGN KEY ([RoundId]) REFERENCES [swc].[Round] ([RoundId])
);

