CREATE TABLE [dbo].[Recipe] (
    [IdRecipe]         INT         IDENTITY (1, 1) NOT NULL,
    [IdRecipeCategory] INT         NOT NULL,
    [UrlRecipePicture] NCHAR (150) NOT NULL,
    [IdUser]           INT         NOT NULL,
    [Name]             NCHAR (150) NULL,
    [CreationDate] DATETIME2 NULL, 
    [Preparation] TEXT NULL, 
    CONSTRAINT [PK_Recipe] PRIMARY KEY CLUSTERED ([IdRecipe] ASC),
    CONSTRAINT [FK_Recipe_RecipeCategory] FOREIGN KEY ([IdRecipeCategory]) REFERENCES [dbo].[RecipeCategory] ([IdRecipeCategory]),
    CONSTRAINT [FK_Recipe_User] FOREIGN KEY ([IdUser]) REFERENCES [dbo].[User] ([IdUser])
);


