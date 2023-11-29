CREATE TABLE [dbo].[Albums] (
    [AlbumID] INT            IDENTITY (1, 1) NOT NULL,
    [Title]   NVARCHAR (MAX) NOT NULL,
    [UserID]  INT            NOT NULL,
    CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED ([AlbumID] ASC),
    CONSTRAINT [FK_Albums_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Albums_UserID]
    ON [dbo].[Albums]([UserID] ASC);

