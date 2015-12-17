USE [frcrankdb01]
GO

SELECT [Id]
      ,[Rank]
      ,[Name]
      ,[NextMatch]
      ,[LastUpdated]
  FROM [dbo].[Teams]
GO


UPDATE [dbo].[Teams] SET [Rank] = 15, [LastUpdated] = GETUTCDATE() WHERE [Id] = 537