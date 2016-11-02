

-- Description : Retieve all datas from  table  => Ingredient  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_Ingredient_BY_RecipeID]
  (@IdRecipe int)
AS
BEGIN
SELECT [Ingredient].[IdIngredient] , [Ingredient].[Name] , [Ingredient].[Calories] , [Ingredient].[IdIngredientCategory] ,[Ingredient].UrlIngredientPicture
	FROM [dbo].[Ingredient] (nolock) as [Ingredient]
	JOIN [dbo].[RecipeIngredient] (nolock) as [RecipeIngredient] on [Ingredient].IdIngredient = [RecipeIngredient].IdIngredient
WHERE [RecipeIngredient].IdRecipe=@IdRecipe;
    END