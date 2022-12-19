CREATE TABLE [dbo].[Company] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR(200)            NOT NULL,
    [Address1]     VARCHAR(100)            NOT NULL,
    [Address2]     VARCHAR(100)            NOT NULL,
    [Address3]     VARCHAR(100)            NOT NULL,
    [Postcode]     VARCHAR(20)            NOT NULL,
    [Country] VARCHAR(50) NOT NULL,
    [Active] Bit NOT Null,
    [InsuranceEndDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC),
);
