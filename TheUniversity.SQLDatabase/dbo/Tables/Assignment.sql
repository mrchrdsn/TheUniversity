CREATE TABLE [dbo].[Assignment] (
    [AssignmentID]          INT            IDENTITY (1, 1) NOT NULL,
    [CourseID]              INT            NOT NULL,
    [AssignmentDescription] NVARCHAR (MAX) NOT NULL,
    [AssignmentGrade]       INT            NOT NULL,
    CONSTRAINT [PK_Assignment] PRIMARY KEY CLUSTERED ([AssignmentID] ASC),
    CONSTRAINT [FK_Assignment_Course_CourseID] FOREIGN KEY ([CourseID]) REFERENCES [dbo].[Course] ([CourseID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Assignment_CourseID]
    ON [dbo].[Assignment]([CourseID] ASC);

