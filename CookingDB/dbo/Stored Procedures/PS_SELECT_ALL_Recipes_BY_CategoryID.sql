

-- Description : Retieve all datas from  table  => Ingredient  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_Recipes_BY_CategoryID]
  (@IdRecipeCategory int)
AS
BEGIN
	SELECT [Recipe].[IdRecipe] , [Recipe].[IdRecipeCategory] , [Recipe].[UrlRecipePicture] , [Recipe].[IdUser] , [Recipe].[Name] , [Recipe].[Preparation] 
		FROM [dbo].[Recipe] (nolock) as [Recipe]
	WHERE [IdRecipeCategory]=@IdRecipeCategory;
END