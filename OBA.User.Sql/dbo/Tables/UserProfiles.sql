CREATE TABLE [dbo].[UserProfiles] (
    [userProfileID]  INT            IDENTITY (1, 1) NOT NULL,
    [Firstname]      NVARCHAR (MAX) NOT NULL,
    [Lastname]       NVARCHAR (MAX) NOT NULL,
    [UserID]         NVARCHAR (450) NOT NULL,
    [PersonalNumber] NVARCHAR (11)  DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([userProfileID] ASC),
    CONSTRAINT [FK_UserProfiles_AspNetUsers_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserProfiles_UserID]
    ON [dbo].[UserProfiles]([UserID] ASC);

