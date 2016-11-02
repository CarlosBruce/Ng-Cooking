

-- Description : Update datas in  table => RecipeCategory
CREATE PROCEDURE [dbo].[PS_UPDATE_RecipeCategory]
  (@IdRecipeCategory int=NULL,@Name nchar(50)=NULL)
AS
BEGIN
    BEGIN
      UPDATE [dbo].[RecipeCategory]
        SET [Name]=@Name
        WHERE [IdRecipeCategory]=@IdRecipeCategory;
    END
END