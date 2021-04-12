--Create Tables 
CREATE TABLE [dbo].[UserQueries] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Query]     NVARCHAR (100) NULL,
    [DateQuery] DATETIME       NOT NULL,
    CONSTRAINT [PK_UserQueries] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Results] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [Title]         NVARCHAR (100)  NULL,
    [Link]          NVARCHAR (3000) NULL,
    [UserQueriesId] INT             NULL,
    CONSTRAINT [PK_Results] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Results_UserQueries_UserQueriesId] FOREIGN KEY ([UserQueriesId]) REFERENCES [dbo].[UserQueries] ([Id])
);
GO

--Stored Procedure
CREATE PROCEDURE [dbo].[GetResultsByDate]
	@FromDate DateTime
AS
BEGIN
    Select Query, Title, Link
    From UserQueries u, Results r
    Where u.Id = r.UserQueriesId And DateQuery > @FromDate
END
GO