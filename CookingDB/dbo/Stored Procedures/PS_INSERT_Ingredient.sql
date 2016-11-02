

-- Description : Insert datas in  table => Ingredient on Columns => [Name],[Calories],[IdIngredientCategory] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_Ingredient]
  (@Name nchar(50),@Calories decimal,@IdIngredientCategory int,@IdIngredient int,@UrlIngredientPicture nchar(150))
AS
BEGIN
      INSERT INTO [dbo].[Ingredient]
        ([Name],[Calories],[IdIngredientCategory],UrlIngredientPicture)
      VALUES
        (@Name,@Calories,@IdIngredientCategory,@UrlIngredientPicture);
	  SELECT CAST(SCOPE_IDENTITY() as int);
    END