

-- Description : Retieve all datas from  table  => IngredientCategory  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_IngredientCategory_BY_ID]
  (@IdIngredientCategory int)
AS
BEGIN
SELECT [IngredientCategory].[IdIngredientCategory] , [IngredientCategory].[Name] , [IngredientCategory].[Description] 
	FROM [dbo].[IngredientCategory] (nolock) as [IngredientCategory]
 WHERE [IdIngredientCategory]=@IdIngredientCategory;
    END