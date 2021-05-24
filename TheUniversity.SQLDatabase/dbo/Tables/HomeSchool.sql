CREATE TABLE [dbo].[HomeSchool] (
    [HomeSchoolID]    INT            IDENTITY (1, 1) NOT NULL,
    [AdministratorID] INT            NOT NULL,
    [SchoolName]      NVARCHAR (150) NOT NULL,
    CONSTRAINT [PK_HomeSchool] PRIMARY KEY CLUSTERED ([HomeSchoolID] ASC),
    CONSTRAINT [FK_HomeSchool_SchoolAdministrator_AdministratorID] FOREIGN KEY ([AdministratorID]) REFERENCES [dbo].[SchoolAdministrator] ([SchoolAdministratorID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_HomeSchool_AdministratorID]
    ON [dbo].[HomeSchool]([AdministratorID] ASC);

