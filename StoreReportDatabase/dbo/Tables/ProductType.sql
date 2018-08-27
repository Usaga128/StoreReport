CREATE TABLE [dbo].[ProductType] (
    [ProductTypeID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([ProductTypeID] ASC)
);

