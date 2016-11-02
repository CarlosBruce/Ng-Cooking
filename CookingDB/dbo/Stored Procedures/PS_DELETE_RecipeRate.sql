

-- Description : Delete datas from table => RecipeRate with Id => IdRecipe
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_RecipeRate]
  (@IdRecipe int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[RecipeRate] WHERE [IdRecipe]=@IdRecipe;
END