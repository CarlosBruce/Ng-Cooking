

-- Description : Update datas in  table => Ingredient
CREATE PROCEDURE [dbo].[PS_UPDATE_Ingredient]
  (@Name nchar(50),@Calories decimal,@IdIngredientCategory int,@IdIngredient int,@UrlIngredientPicture nchar(150))
AS
BEGIN
    BEGIN
      UPDATE [dbo].[Ingredient]
        SET [Name]=@Name,[Calories]=@Calories,[IdIngredientCategory]=@IdIngredientCategory,[Ingredient].UrlIngredientPicture = @UrlIngredientPicture
        WHERE [IdIngredient]=@IdIngredient;
    END
END