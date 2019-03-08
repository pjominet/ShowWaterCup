CREATE TABLE [swc].[PlayerIAStep] (
    [AiId]           INT NOT NULL,
    [ParentStepId]   INT NULL,
    [ActionTypeId]   INT NOT NULL,
    [PlayerAIStepId] INT NOT NULL,
    CONSTRAINT [PK_PlayerIAStep] PRIMARY KEY CLUSTERED ([PlayerAIStepId] ASC),
    FOREIGN KEY ([AiId]) REFERENCES [swc].[PlayerIA] ([AiId]),
    FOREIGN KEY ([ParentStepId]) REFERENCES [swc].[PlayerIAStep] ([PlayerAIStepId]),
    CONSTRAINT [FK__PlayerIAS__Actio__4F7CD00D] FOREIGN KEY ([ActionTypeId]) REFERENCES [nomenclature].[ActionType] ([ActionTypeId])
);

