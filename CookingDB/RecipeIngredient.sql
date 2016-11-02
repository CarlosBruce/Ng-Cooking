CREATE TABLE [dbo].[RecipeIngredient]
(
	[IdRecipe] INT NOT NULL, 
    [IdIngredient] INT NOT NULL, 
    CONSTRAINT [FK_RecipeIngredient_Recipe] FOREIGN KEY ([IdRecipe]) REFERENCES [Recipe]([IdRecipe]), 
    CONSTRAINT [FK_RecipeIngredient_Ingredient] FOREIGN KEY ([IdIngredient]) REFERENCES [Ingredient]([IdIngredient]),
	CONSTRAINT [PK_RecipeIngredient] PRIMARY KEY CLUSTERED ([IdRecipe] ,[IdIngredient]), 
)
