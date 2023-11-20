
Create Database [StudentGrades]
Go

Use [StudentGrades]
Go

CREATE TABLE [dbo].[Student] (
    [StudentId]  INT        IDENTITY (1, 1) NOT NULL,
    [Name]       NCHAR (20) NOT NULL,
    CONSTRAINT [pk_Student] PRIMARY KEY CLUSTERED ([StudentId] ASC)
);
Go
CREATE TABLE [dbo].[Grades] (
    [GradeId]  INT        IDENTITY (1, 1) NOT NULL,
    [Score] INT        NOT NULL,
    [StudentId] INT NOT NULL,
    CONSTRAINT [pk_Grades] PRIMARY KEY CLUSTERED ([GradeId] ASC),
    CONSTRAINT [FK_Grades_Student] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([StudentId]),
);
Go


