CREATE TABLE [dbo].[ClaimType] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR(50)            NOT NULL,
    CONSTRAINT [PK_ClaimType] PRIMARY KEY CLUSTERED ([Id] ASC),
);


