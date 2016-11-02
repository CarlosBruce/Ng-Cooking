

-- Description : Delete datas from table => RecipeIngredient with Id => IdIngredient
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_RecipeIngredient_By_IdRecipe]
  (@IdRecipe int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[RecipeIngredient] WHERE [IdRecipe]=@IdRecipe;
END