

-- Description : Insert datas in  table => RecipeCategory on Columns => [Name] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_RecipeCategory]
  (@IdRecipeCategory int=NULL,@Name nchar(50)=NULL)
AS
BEGIN
      INSERT INTO [dbo].[RecipeCategory]
        ([Name])
      VALUES
        (@Name);
	  SELECT CAST(SCOPE_IDENTITY() as int);
    END