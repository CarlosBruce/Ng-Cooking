

-- Description : Insert datas in  table => UserLevel on Columns => [Name],[RateMin],[RateMax],[Description] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_UserLevel]
  (@Name nvarchar(50),@RateMin decimal,@RateMax decimal,@IdUserLevel int=NULL,@Description nvarchar(120)=NULL)
AS
BEGIN
      INSERT INTO [dbo].[UserLevel]
        ([Name],[RateMin],[RateMax],[Description])
      VALUES
        (@Name,@RateMin,@RateMax,@Description);
	  SELECT CAST(SCOPE_IDENTITY() as int);
    END