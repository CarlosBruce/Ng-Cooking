

-- Description : Retieve all datas from  table  => IngredientCategory  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_IngredientCategory]
AS
BEGIN
SELECT [IngredientCategory].[IdIngredientCategory] , [IngredientCategory].[Name] , [IngredientCategory].[Description] 
	FROM [dbo].[IngredientCategory] (nolock) as [IngredientCategory]
    END