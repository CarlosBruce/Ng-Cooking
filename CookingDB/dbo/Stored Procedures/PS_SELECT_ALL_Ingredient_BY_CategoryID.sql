

-- Description : Retieve all datas from  table  => Ingredient  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_Ingredient_BY_CategoryID]
  (@IdIngredientCategory int)
AS
BEGIN
SELECT [Ingredient].[IdIngredient] , [Ingredient].[Name] , [Ingredient].[Calories] , [Ingredient].[IdIngredientCategory] ,[Ingredient].UrlIngredientPicture
	FROM [dbo].[Ingredient] (nolock) as [Ingredient]
WHERE [IdIngredientCategory]=@IdIngredientCategory;
    END