

-- Description : Update datas in  table => IngredientCategory
CREATE PROCEDURE [dbo].[PS_UPDATE_IngredientCategory]
  (@Name nchar(60),@IdIngredientCategory int=NULL,@Description nvarchar(120)=NULL)
AS
BEGIN
    BEGIN
      UPDATE [dbo].[IngredientCategory]
        SET [Name]=@Name,[Description]=@Description
        WHERE [IdIngredientCategory]=@IdIngredientCategory;
    END
END