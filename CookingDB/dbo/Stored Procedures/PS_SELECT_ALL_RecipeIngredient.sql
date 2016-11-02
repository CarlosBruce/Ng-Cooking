

-- Description : Retieve all datas from  table  => RecipeIngredient  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_RecipeIngredient]
AS
BEGIN
SELECT [RecipeIngredient].[IdRecipe] , [RecipeIngredient].[IdIngredient] 
	FROM [dbo].[RecipeIngredient] (nolock) as [RecipeIngredient]
    END