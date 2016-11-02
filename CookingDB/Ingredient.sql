CREATE TABLE [dbo].[Ingredient] (
    [IdIngredient]         INT          IDENTITY (1, 1) NOT NULL,
    [Name]                 NCHAR (50)   NOT NULL,
    [Calories]             DECIMAL (18) NOT NULL,
    [IdIngredientCategory] INT          NOT NULL,
    [UrlIngredientPicture] NCHAR (150)  NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY CLUSTERED ([IdIngredient] ASC),
    CONSTRAINT [FK_Ingredient_IngredientCategory] FOREIGN KEY ([IdIngredientCategory]) REFERENCES [dbo].[IngredientCategory] ([IdIngredientCategory])
);


