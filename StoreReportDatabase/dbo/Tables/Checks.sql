CREATE TABLE [dbo].[Checks] (
    [ChecksID]     INT            IDENTITY (1, 1) NOT NULL,
    [Question]     NVARCHAR (MAX) NOT NULL,
    [QuestionType] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Checks] PRIMARY KEY CLUSTERED ([ChecksID] ASC)
);

