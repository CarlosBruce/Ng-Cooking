CREATE TABLE [dbo].[IngredientCategory]
(
	[IdIngredientCategory] INT IDENTITY (1,1), 
    [Name] NCHAR(60) NOT NULL, 
    [Description] NVARCHAR(120) NULL,
	CONSTRAINT [PK_IngredientCategory] PRIMARY KEY CLUSTERED ([IdIngredientCategory] ASC), 

)
