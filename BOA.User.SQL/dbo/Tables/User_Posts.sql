CREATE TABLE [dbo].[User_Posts] (
    [UserPostID] INT            IDENTITY (1, 1) NOT NULL,
    [Tittle]     NVARCHAR (MAX) NULL,
    [Body]       NVARCHAR (MAX) NULL,
    [UserID]     INT            NOT NULL,
    CONSTRAINT [PK_User_Posts] PRIMARY KEY CLUSTERED ([UserPostID] ASC),
    CONSTRAINT [FK_User_Posts_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_User_Posts_UserID]
    ON [dbo].[User_Posts]([UserID] ASC);

