CREATE TABLE [dbo].[Item] (
    [ItemID]        INT            IDENTITY (1, 1) NOT NULL,
    [ProductCode]   NVARCHAR (MAX) NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Description]   NVARCHAR (MAX) NULL,
    [CreatedDate]   DATETIME2 (7)  NOT NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [ProductTypeID] INT            NOT NULL,
    CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED ([ItemID] ASC)
);

