

-- Description : Retieve all datas from  table  => Ingredient  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_Ingredient_BY_ID]
  (@IdIngredient int)
AS
BEGIN
SELECT [Ingredient].[IdIngredient] , [Ingredient].[Name] , [Ingredient].[Calories] , [Ingredient].[IdIngredientCategory] ,[Ingredient].UrlIngredientPicture
	FROM [dbo].[Ingredient] (nolock) as [Ingredient]
 WHERE [IdIngredient]=@IdIngredient;
    END