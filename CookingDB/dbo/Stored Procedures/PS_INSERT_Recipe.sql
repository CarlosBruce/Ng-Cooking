

-- Description : Insert datas in  table => Recipe on Columns => [IdRecipeCategory],[UrlRecipePicture],[IdUser] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_Recipe]
  (@IdRecipeCategory int,@UrlRecipePicture nchar(150),@IdUser int,@IdRecipe int=NULL,@Name nchar(150),@CreationDate Datetime2=NULL, @Preparation text=NULL)
AS
BEGIN
      INSERT INTO [dbo].[Recipe]
        ([IdRecipeCategory],[UrlRecipePicture],[IdUser],[Name],[CreationDate],Preparation)
      VALUES
        (@IdRecipeCategory,@UrlRecipePicture,@IdUser,@Name,@CreationDate,@Preparation);
	  SELECT CAST(SCOPE_IDENTITY() as int);
    END