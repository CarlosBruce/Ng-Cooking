

-- Description : Retieve all datas from  table  => RecipeIngredient  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_COMPLETE_RecipeIngredient]
AS
BEGIN
SELECT [RecipeIngredient].[IdRecipe] , [RecipeIngredient].[IdIngredient] 
	, [Ingredient].[IdIngredient] as [IngredientIdIngredient] , [Ingredient].[Calories] , [Ingredient].[IdIngredientCategory] , [Ingredient].[Name]
	, [Recipe].[IdRecipe] as [RecipeIdRecipe] , [Recipe].[IdRecipeCategory] , [Recipe].[IdUser] , [Recipe].[UrlRecipePicture],[Recipe].[CreationDate],Recipe.Name
	FROM [dbo].[RecipeIngredient] (nolock) as [RecipeIngredient]
	JOIN [dbo].[Ingredient] (nolock) as [Ingredient] on [Ingredient].[IdIngredient] = [RecipeIngredient].[IdIngredient]
	JOIN [dbo].[Recipe] (nolock) as [Recipe] on [Recipe].[IdRecipe] = [RecipeIngredient].[IdRecipe]
    END