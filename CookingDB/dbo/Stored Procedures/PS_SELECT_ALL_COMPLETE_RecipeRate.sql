

-- Description : Retieve all datas from  table  => RecipeRate  with jointures values 
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_COMPLETE_RecipeRate]
AS
BEGIN
SELECT [RecipeRate].[IdRecipe] , [RecipeRate].[Rate] , [RecipeRate].[IdUser] ,[RecipeRate].[Comment],[RecipeRate].[Title] 
	, [Recipe].[IdRecipe] as [RecipeIdRecipe] , [Recipe].[IdRecipeCategory] , [Recipe].[IdUser] , [Recipe].[UrlRecipePicture],[Recipe].[CreationDate],Recipe.Name
	, [User].[IdUser] as [UserIdUser], [User].[Email]  , [User].[Login] , [User].[Password] , [User].[UrlProfilPicture]
	FROM [dbo].[RecipeRate] (nolock) as [RecipeRate]
	JOIN [dbo].[Recipe] (nolock) as [Recipe] on [Recipe].[IdRecipe] = [RecipeRate].[IdRecipe]
	JOIN [dbo].[User] (nolock) as [User] on [User].[IdUser] = [RecipeRate].[IdUser]
    END