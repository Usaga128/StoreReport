CREATE TABLE [dbo].[Franchise] (
    [FranchiseID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [Status]      INT            NOT NULL,
    CONSTRAINT [PK_Franchise] PRIMARY KEY CLUSTERED ([FranchiseID] ASC)
);

