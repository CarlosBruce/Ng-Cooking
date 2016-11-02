

-- Description : Retieve all datas from  table  => Recipe  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_RecipeRate_BY_User_ID]
  (@IdUser int)
AS
BEGIN
SELECT [RecipeRate].[IdRecipe] , [RecipeRate].[Rate] , [RecipeRate].[IdUser] ,[RecipeRate].[Comment],[RecipeRate].[Title] 
	FROM [dbo].[RecipeRate] (nolock) as [RecipeRate]
	JOIN [dbo].[Recipe] (nolock) as [Recipe] on [Recipe].[IdRecipe] = [RecipeRate].[IdRecipe]
	where [Recipe].[IdUser] = @IdUser
END