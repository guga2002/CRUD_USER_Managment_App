CREATE TABLE [dbo].[Coments] (
    [ComentID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Body]     NVARCHAR (MAX) NOT NULL,
    [PostID]   INT            NOT NULL,
    CONSTRAINT [PK_Coments] PRIMARY KEY CLUSTERED ([ComentID] ASC),
    CONSTRAINT [FK_Coments_User_Posts_PostID] FOREIGN KEY ([PostID]) REFERENCES [dbo].[User_Posts] ([UserPostID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Coments_PostID]
    ON [dbo].[Coments]([PostID] ASC);

