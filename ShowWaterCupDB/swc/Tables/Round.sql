CREATE TABLE [swc].[Round] (
    [RoundId]      INT NOT NULL,
    [TournamentId] INT NOT NULL,
    CONSTRAINT [roundId_pk] PRIMARY KEY CLUSTERED ([RoundId] ASC),
    FOREIGN KEY ([TournamentId]) REFERENCES [swc].[Tournament] ([TournamentId])
);

