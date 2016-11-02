

-- Description : Delete datas from table => Recipe with Id => IdRecipe
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_Recipe]
  (@IdRecipe int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[Recipe] WHERE [IdRecipe]=@IdRecipe;
END