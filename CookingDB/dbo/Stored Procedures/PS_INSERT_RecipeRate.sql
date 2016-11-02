

-- Description : Insert datas in  table => RecipeRate on Columns => [Rate],[IdUser] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_RecipeRate]
  (@Rate decimal,@IdUser int,@IdRecipe int=NULL,@Comment text=NULL,@Title nvarchar(30)=NULL)
AS
BEGIN
      INSERT INTO [dbo].[RecipeRate]
        ([Rate],[IdUser],[IdRecipe],[Comment],[Title])
      VALUES
        (@Rate,@IdUser,@IdRecipe,@Comment,@Title);
	  SELECT CAST(SCOPE_IDENTITY() as int);
    END