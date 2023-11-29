CREATE TABLE [dbo].[UserProfiles] (
    [userProfileID]  INT            IDENTITY (1, 1) NOT NULL,
    [Firstname]      NVARCHAR (MAX) NOT NULL,
    [Lastname]       NVARCHAR (MAX) NOT NULL,
    [PersonalNumber] NVARCHAR (11)  NOT NULL,
    [AddressID]      INT            NOT NULL,
    [CompanieID]     INT            NOT NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([userProfileID] ASC),
    CONSTRAINT [FK_UserProfiles_Addresses_AddressID] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Addresses] ([AddressID]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserProfiles_Companies_CompanieID] FOREIGN KEY ([CompanieID]) REFERENCES [dbo].[Companies] ([CompanieID]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserProfiles_AddressID]
    ON [dbo].[UserProfiles]([AddressID] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserProfiles_CompanieID]
    ON [dbo].[UserProfiles]([CompanieID] ASC);

