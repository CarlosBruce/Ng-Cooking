

-- Description : Delete datas from table => RecipeIngredient with Id => IdIngredient
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_RecipeIngredient]
  (@IdIngredient int,@IdRecipe int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[RecipeIngredient] WHERE [IdIngredient]=@IdIngredient and [IdRecipe]=@IdRecipe;
END