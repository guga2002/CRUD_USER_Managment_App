CREATE TABLE [dbo].[Companies] (
    [CompanieID]  INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [CatchPhrase] NVARCHAR (MAX) NULL,
    [BS]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ([CompanieID] ASC)
);

