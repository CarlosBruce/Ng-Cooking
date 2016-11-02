

-- Description : Update datas in  table => RecipeRate
CREATE PROCEDURE [dbo].[PS_UPDATE_RecipeRate]
  (@Rate decimal,@IdUser int,@IdRecipe int=NULL)
AS
BEGIN
    BEGIN
      UPDATE [dbo].[RecipeRate]
        SET [Rate]=@Rate,[IdUser]=@IdUser
        WHERE [IdRecipe]=@IdRecipe;
    END
END