

-- Description : Insert datas in  table => IngredientCategory on Columns => [Name],[Description] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_IngredientCategory]
  (@Name nchar(60),@IdIngredientCategory int=NULL,@Description nvarchar(120)=NULL)
AS
BEGIN
      INSERT INTO [dbo].[IngredientCategory]
        ([Name],[Description])
      VALUES
        (@Name,@Description);
	  SELECT CAST(SCOPE_IDENTITY() as int);
    END