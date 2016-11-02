

-- Description : Delete datas from table => IngredientCategory with Id => IdIngredientCategory
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_IngredientCategory]
  (@IdIngredientCategory int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[IngredientCategory] WHERE [IdIngredientCategory]=@IdIngredientCategory;
END