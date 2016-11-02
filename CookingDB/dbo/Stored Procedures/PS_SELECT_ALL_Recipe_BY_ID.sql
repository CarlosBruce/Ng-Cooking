

-- Description : Retieve all datas from  table  => Recipe  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_Recipe_BY_ID]
  (@IdRecipe int)
AS
BEGIN
SELECT [Recipe].[CreationDate],[Recipe].[IdRecipe] , [Recipe].[IdRecipeCategory] , [Recipe].[UrlRecipePicture] , [Recipe].[IdUser] ,Recipe.[Name], [Recipe].[Preparation] 
	FROM [dbo].[Recipe] (nolock) as [Recipe]
 WHERE [IdRecipe]=@IdRecipe;
    END