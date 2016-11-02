

-- Description : Retieve all datas from  table  => RecipeIngredient  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_RecipeIngredient_BY_ID]
  (@IdIngredient int)
AS
BEGIN
SELECT [RecipeIngredient].[IdRecipe] , [RecipeIngredient].[IdIngredient] 
	FROM [dbo].[RecipeIngredient] (nolock) as [RecipeIngredient]
 WHERE [IdIngredient]=@IdIngredient;
    END