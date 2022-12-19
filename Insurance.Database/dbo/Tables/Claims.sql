CREATE TABLE [dbo].[Claims] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]       INT            NOT NULL,
    [ClaimDate]     DATETIME2            NOT NULL,
    [LossDate]     DATETIME2            NOT NULL,
    [AssuredName]     VARCHAR(100)            NOT NULL,
    [IncurredLoss]     DECIMAL(15, 2)            NOT NULL,
    [Closed] Bit NOT NULL,
    CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Claims_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id])
);

GO
CREATE NONCLUSTERED INDEX [IX_Claims_CompanyId]
    ON [dbo].[Claims]([CompanyId] ASC);
