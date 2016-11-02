using Cooking.Repository;
using Cooking.Service;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace CookingWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IIngredientCategoryService, IngredientCategoryService>();
            container.RegisterType<IIngredientCategoryRepository, IngredientCategoryRepository>();

            container.RegisterType<IIngredientService, IngredientService>();
            container.RegisterType<IIngredientRepository, IngredientRepository>();


            container.RegisterType<IRecipeCategoryRepository, RecipeCategoryRepository>();
            container.RegisterType<IRecipeCategoryService, RecipeCategoryService>();

            container.RegisterType<IRecipeService, RecipeService>();
            container.RegisterType<IRecipeRepository, RecipeRepository>();

            container.RegisterType<IRecipeRateService, RecipeRateService>();
            container.RegisterType<IRecipeRateRepository, RecipeRateRepository>();

            container.RegisterType<IRecipeIngredientService, RecipeIngredientService>();
            container.RegisterType<IRecipeIngredientRepository, RecipeIngredientRepository>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}