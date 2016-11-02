

-- Description : Retieve all datas from  table  => RecipeCategory  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_RecipeCategory_BY_ID]
  (@IdRecipeCategory int)
AS
BEGIN
SELECT [RecipeCategory].[IdRecipeCategory] , [RecipeCategory].[Name] 
	FROM [dbo].[RecipeCategory] (nolock) as [RecipeCategory]
 WHERE [IdRecipeCategory]=@IdRecipeCategory;
    END