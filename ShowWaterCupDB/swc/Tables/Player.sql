CREATE TABLE [swc].[Player] (
    [Id]          INT           NOT NULL,
    [Name]        VARCHAR (100) NULL,
    [CharacterId] INT           NOT NULL,
    CONSTRAINT [id_pk] PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CharacterId]) REFERENCES [nomenclature].[Character] ([CharacterId])
);

