CREATE TABLE [dbo].[RecipeRate]
(
	[IdRecipe] INT NOT NULL, 
    [Rate] DECIMAL NOT NULL, 
    [IdUser] INT NOT NULL, 
    [Comment] TEXT NULL, 
    [Title] NCHAR(30) NULL, 
    CONSTRAINT [FK_RecipeRate_Recipe] FOREIGN KEY ([IdRecipe]) REFERENCES [Recipe]([IdRecipe]), 
    CONSTRAINT [FK_RecipeRate_User] FOREIGN KEY ([IdUser]) REFERENCES [User]([IdUser]), 
    CONSTRAINT [PK_UserRecipeRate] PRIMARY KEY ([IdUser],[IdRecipe]) 
)
