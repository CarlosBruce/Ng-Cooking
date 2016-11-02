

-- Description : Insert datas in  table => RecipeIngredient on Columns => [IdRecipe] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_RecipeIngredient]
  (@IdRecipe int,@IdIngredient int)
AS
BEGIN
      INSERT INTO [dbo].[RecipeIngredient]
        ([IdRecipe],[IdIngredient])
      VALUES
        (@IdRecipe,@IdIngredient);

    END