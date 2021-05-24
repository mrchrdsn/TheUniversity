CREATE TABLE [dbo].[SchoolAdministrator] (
    [SchoolAdministratorID] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]             NVARCHAR (50)  NOT NULL,
    [LastName]              NVARCHAR (50)  NOT NULL,
    [Password]              NVARCHAR (50)  NOT NULL,
    [Email]                 NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_SchoolAdministrator] PRIMARY KEY CLUSTERED ([SchoolAdministratorID] ASC)
);

