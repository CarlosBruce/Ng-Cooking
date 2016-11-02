

-- Description : Insert datas in  table => User on Columns => [Login],[Email],[Password],[UrlProfilPicture] with all values of table.
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_INSERT_User]
  (@Login nchar(20),@Email nvarchar(100),@Password nvarchar(50),@IdUser int=NULL,@UrlProfilPicture nchar(250)=NULL)
AS
BEGIN
      INSERT INTO [dbo].[User]
        ([Login],[Email],[Password],[UrlProfilPicture])
      VALUES
        (@Login,@Email,@Password,@UrlProfilPicture);
	  SELECT CAST(SCOPE_IDENTITY() as int);
    END