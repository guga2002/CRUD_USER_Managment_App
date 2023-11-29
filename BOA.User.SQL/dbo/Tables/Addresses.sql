CREATE TABLE [dbo].[Addresses] (
    [AddressID] INT            IDENTITY (1, 1) NOT NULL,
    [street]    NVARCHAR (MAX) NULL,
    [suite]     NVARCHAR (MAX) NULL,
    [zipcode]   NVARCHAR (MAX) NULL,
    [city]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED ([AddressID] ASC)
);

