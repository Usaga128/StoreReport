CREATE TABLE [dbo].[Store] (
    [StoreID]     INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Phone]       NVARCHAR (MAX) NULL,
    [ContactName] NVARCHAR (MAX) NULL,
    [Address]     NVARCHAR (MAX) NULL,
    [GeoAddress]  NVARCHAR (MAX) NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [Status]      INT            NOT NULL,
    [FranchiseID] INT            NOT NULL,
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([StoreID] ASC)
);

