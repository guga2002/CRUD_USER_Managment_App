CREATE TABLE [dbo].[ToDos] (
    [ToDoID]     INT            IDENTITY (1, 1) NOT NULL,
    [title]      NVARCHAR (MAX) NULL,
    [IScomplete] BIT            NOT NULL,
    [UserID]     INT            NOT NULL,
    CONSTRAINT [PK_ToDos] PRIMARY KEY CLUSTERED ([ToDoID] ASC),
    CONSTRAINT [FK_ToDos_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ToDos_UserID]
    ON [dbo].[ToDos]([UserID] ASC);

