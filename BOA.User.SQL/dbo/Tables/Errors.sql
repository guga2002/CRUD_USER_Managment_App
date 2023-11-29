CREATE TABLE [dbo].[Errors] (
    [ErrorID] INT            IDENTITY (1, 1) NOT NULL,
    [text]    NVARCHAR (MAX) NOT NULL,
    [type]    INT            NOT NULL,
    [time]    DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Errors] PRIMARY KEY CLUSTERED ([ErrorID] ASC)
);

