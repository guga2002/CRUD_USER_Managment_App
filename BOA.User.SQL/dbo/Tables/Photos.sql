CREATE TABLE [dbo].[Photos] (
    [PhotoID]      INT            IDENTITY (1, 1) NOT NULL,
    [Tittle]       NVARCHAR (MAX) NOT NULL,
    [URL]          NVARCHAR (MAX) NOT NULL,
    [thumbnailUrl] NVARCHAR (MAX) NOT NULL,
    [AlbumID]      INT            NOT NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED ([PhotoID] ASC),
    CONSTRAINT [FK_Photos_Albums_AlbumID] FOREIGN KEY ([AlbumID]) REFERENCES [dbo].[Albums] ([AlbumID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Photos_AlbumID]
    ON [dbo].[Photos]([AlbumID] ASC);

