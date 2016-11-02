

-- Description : Update datas in  table => Recipe
CREATE PROCEDURE [dbo].[PS_UPDATE_Recipe]
  (@IdRecipeCategory int,@UrlRecipePicture nchar(150),@IdUser int,@Name nchar(150),@IdRecipe int=NULL)
AS
BEGIN
    BEGIN
      UPDATE [dbo].[Recipe]
        SET [IdRecipeCategory]=@IdRecipeCategory,[UrlRecipePicture]=@UrlRecipePicture,[IdUser]=@IdUser,[Name]=@Name
        WHERE [IdRecipe]=@IdRecipe;
    END
END