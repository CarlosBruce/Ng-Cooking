

-- Description : Update datas in  table => RecipeIngredient
CREATE PROCEDURE [dbo].[PS_UPDATE_RecipeIngredient]
  (@IdRecipe int,@IdIngredient int=NULL)
AS
BEGIN
    BEGIN
      UPDATE [dbo].[RecipeIngredient]
        SET [IdRecipe]=@IdRecipe
        WHERE [IdIngredient]=@IdIngredient;
    END
END