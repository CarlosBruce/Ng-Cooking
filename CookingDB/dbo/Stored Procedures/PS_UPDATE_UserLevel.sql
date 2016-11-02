

-- Description : Update datas in  table => UserLevel
CREATE PROCEDURE [dbo].[PS_UPDATE_UserLevel]
  (@Name nvarchar(50),@RateMin decimal,@RateMax decimal,@IdUserLevel int=NULL,@Description nvarchar(120)=NULL)
AS
BEGIN
    BEGIN
      UPDATE [dbo].[UserLevel]
        SET [Name]=@Name,[RateMin]=@RateMin,[RateMax]=@RateMax,[Description]=@Description
        WHERE [IdUserLevel]=@IdUserLevel;
    END
END