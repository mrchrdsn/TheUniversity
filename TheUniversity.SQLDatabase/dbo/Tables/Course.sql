CREATE TABLE [dbo].[Course] (
    [CourseID]    INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Credits]     INT            NOT NULL,
    [StudentID]   INT            NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([CourseID] ASC),
    CONSTRAINT [FK_Course_Student_StudentID] FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Student] ([StudentID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Course_StudentID]
    ON [dbo].[Course]([StudentID] ASC);

