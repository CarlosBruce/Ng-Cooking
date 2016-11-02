

-- Description : Retieve all datas from  table  => Recipe  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_COMPLETE_Recipe_BY_ID]
  (@IdRecipe int)
AS
BEGIN
SELECT [Recipe].[CreationDate],[Recipe].[IdRecipe] , [Recipe].[IdRecipeCategory] , [Recipe].[UrlRecipePicture] , [Recipe].[IdUser] , [Recipe].[Name] , [Recipe].[Preparation] 
	, [RecipeCategory].[IdRecipeCategory] as [RecipeCategoryIdRecipeCategory] , [RecipeCategory].[Name]
	,[User].[IdUser] as [UserIdUser] , [User].[Email]  , [User].[Login] , [User].[Password] , [User].[UrlProfilPicture]
	FROM [dbo].[Recipe] (nolock) as [Recipe]
	JOIN [dbo].[RecipeCategory] (nolock) as [RecipeCategory] on [RecipeCategory].[IdRecipeCategory] = [Recipe].[IdRecipeCategory]
	JOIN [dbo].[User] (nolock) as [User] on [User].[IdUser] = [Recipe].[IdUser]
 WHERE [IdRecipe]=@IdRecipe;
    END