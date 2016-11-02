

-- Description : Retieve all datas from  table  => Ingredient  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_Ingredient]
AS
BEGIN
SELECT [Ingredient].[IdIngredient] , [Ingredient].[Name] , [Ingredient].[Calories] , [Ingredient].[IdIngredientCategory] ,[Ingredient].UrlIngredientPicture
	FROM [dbo].[Ingredient] (nolock) as [Ingredient]
    END