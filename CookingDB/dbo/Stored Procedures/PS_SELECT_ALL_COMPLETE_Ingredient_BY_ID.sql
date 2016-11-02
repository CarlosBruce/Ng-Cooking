

-- Description : Retieve all datas from  table  => Ingredient  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_COMPLETE_Ingredient_BY_ID]
  (@IdIngredient int)
AS
BEGIN
SELECT [Ingredient].[IdIngredient] , [Ingredient].[Name] , [Ingredient].[Calories] , [Ingredient].[IdIngredientCategory] ,[Ingredient].UrlIngredientPicture
	,  [IngredientCategory].[IdIngredientCategory] as [IngredientCategoryIdIngredientCategory], [IngredientCategory].[Description] , [IngredientCategory].[Name]
	FROM [dbo].[Ingredient] (nolock) as [Ingredient]
	JOIN [dbo].[IngredientCategory] (nolock) as [IngredientCategory] on [IngredientCategory].[IdIngredientCategory] = [Ingredient].[IdIngredientCategory]
 WHERE [IdIngredient]=@IdIngredient;
    END