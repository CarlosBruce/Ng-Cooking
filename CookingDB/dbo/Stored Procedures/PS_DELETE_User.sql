

-- Description : Delete datas from table => User with Id => IdUser
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_DELETE_User]
  (@IdUser int)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM [dbo].[User] WHERE [IdUser]=@IdUser;
END