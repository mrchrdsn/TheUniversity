CREATE TABLE [dbo].[Student] (
    [StudentID]    INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50)  NOT NULL,
    [MiddleName]   NVARCHAR (50)  NULL,
    [LastName]     NVARCHAR (50)  NOT NULL,
    [GradeLevel]   NVARCHAR (MAX) NOT NULL,
    [EnrollDate]   DATETIME2 (7)  NOT NULL,
    [HomeSchoolId] INT            NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([StudentID] ASC)
);

