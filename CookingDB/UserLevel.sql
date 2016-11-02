CREATE TABLE [dbo].[UserLevel]
(
	[IdUserLevel] INT IDENTITY(1,1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [RateMin] DECIMAL NOT NULL, 
    [RateMax] DECIMAL NOT NULL, 
    [Description] NVARCHAR(120) NULL,
	CONSTRAINT [PK_UserLevel] PRIMARY KEY CLUSTERED ([IdUserLevel] ASC), 
)
