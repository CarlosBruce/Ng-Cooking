

-- Description : Delete datas from table => UserLevel with Id => IdUserLevel
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_UserLevel]
  (@IdUserLevel int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[UserLevel] WHERE [IdUserLevel]=@IdUserLevel;
END