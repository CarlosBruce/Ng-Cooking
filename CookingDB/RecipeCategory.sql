CREATE TABLE [dbo].[RecipeCategory]
(
	[IdRecipeCategory] INT IDENTITY(1,1) , 
    [Name] NCHAR(50) NULL
	CONSTRAINT [PK_RecipeCategory] PRIMARY KEY CLUSTERED ([IdRecipeCategory] ASC), 
)
