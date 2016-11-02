

-- Description : Retieve all datas from  table  => User  without jointures values  
-- ===================================================================

CREATE PROCEDURE [dbo].[PS_SELECT_ALL_User]
AS
BEGIN
SELECT [User].[IdUser] , [User].[Login] , [User].[Email] , [User].[Password] , [User].[UrlProfilPicture] 
	FROM [dbo].[User] (nolock) as [User]
    END