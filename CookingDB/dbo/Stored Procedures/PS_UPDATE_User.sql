

-- Description : Update datas in  table => User
CREATE PROCEDURE [dbo].[PS_UPDATE_User]
  (@Login nchar(20),@Email nvarchar(100),@Password nvarchar(50),@IdUser int=NULL,@UrlProfilPicture nchar(250)=NULL)
AS
BEGIN
    BEGIN
      UPDATE [dbo].[User]
        SET [Login]=@Login,[Email]=@Email,[Password]=@Password,[UrlProfilPicture]=@UrlProfilPicture
        WHERE [IdUser]=@IdUser;
    END
END