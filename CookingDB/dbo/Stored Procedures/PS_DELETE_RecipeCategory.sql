

-- Description : Delete datas from table => RecipeCategory with Id => IdRecipeCategory
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_RecipeCategory]
  (@IdRecipeCategory int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[RecipeCategory] WHERE [IdRecipeCategory]=@IdRecipeCategory;
END