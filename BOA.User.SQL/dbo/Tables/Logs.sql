CREATE TABLE [dbo].[Logs] (
    [LogID] INT            IDENTITY (1, 1) NOT NULL,
    [text]  NVARCHAR (MAX) NOT NULL,
    [type]  INT            NOT NULL,
    [time]  DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([LogID] ASC)
);

