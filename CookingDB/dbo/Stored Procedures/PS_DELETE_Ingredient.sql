

-- Description : Delete datas from table => Ingredient with Id => IdIngredient
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_Ingredient]
  (@IdIngredient int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[Ingredient] WHERE [IdIngredient]=@IdIngredient;
END