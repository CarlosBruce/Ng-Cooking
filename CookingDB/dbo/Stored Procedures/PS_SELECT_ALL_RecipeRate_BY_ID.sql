

-- Description : Retieve all datas from  table  => RecipeRate  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_RecipeRate_BY_ID]
  (@IdRecipe int)
AS
BEGIN
SELECT [RecipeRate].[IdRecipe] , [RecipeRate].[Rate] , [RecipeRate].[IdUser] ,[RecipeRate].[Comment],[RecipeRate].[Title] 
	FROM [dbo].[RecipeRate] (nolock) as [RecipeRate]
 WHERE [IdRecipe]=@IdRecipe;
    END