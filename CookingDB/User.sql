CREATE TABLE [dbo].[User]
(
	[IdUser] INT IDENTITY(1,1), 
    [Login] NCHAR(20) NOT NULL, 
    [Email] NVARCHAR(100) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [UrlProfilPicture] NCHAR(250) NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([IdUser] ASC), 
	
)
