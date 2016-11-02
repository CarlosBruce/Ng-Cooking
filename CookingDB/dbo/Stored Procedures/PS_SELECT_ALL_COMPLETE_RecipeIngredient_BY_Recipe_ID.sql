

-- Description : Retieve all datas from  table  => RecipeIngredient  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_COMPLETE_RecipeIngredient_BY_Recipe_ID]
  (@IdRecipe int)
AS
BEGIN
SELECT [RecipeIngredient].[IdRecipe] , [RecipeIngredient].[IdIngredient] 
	, [Ingredient].[IdIngredient] as [IngredientIdIngredient], [Ingredient].[Calories]  , [Ingredient].[IdIngredientCategory] , [Ingredient].[Name],[Ingredient].UrlIngredientPicture
	, [Recipe].[IdRecipe] as [RecipeIdRecipe] , [Recipe].[IdRecipeCategory] , [Recipe].[IdUser] , [Recipe].[UrlRecipePicture],Recipe.Name,[Recipe].[CreationDate]
	FROM [dbo].[RecipeIngredient] (nolock) as [RecipeIngredient]
	JOIN [dbo].[Ingredient] (nolock) as [Ingredient] on [Ingredient].[IdIngredient] = [RecipeIngredient].[IdIngredient]
	JOIN [dbo].[Recipe] (nolock) as [Recipe] on [Recipe].[IdRecipe] = [RecipeIngredient].[IdRecipe]
 WHERE [RecipeIngredient].[IdRecipe]=@IdRecipe;
    END