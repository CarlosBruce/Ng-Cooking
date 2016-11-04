namespace Cooking.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Web.Http.Routing;
    public partial class User 
    {
        public User()
        {
            this.Recipes = new List<Recipe>();
            this.RecipeRates = new List<RecipeRate>();
        }
    
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UrlProfilPicture { get; set; }


        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<RecipeRate> RecipeRates { get; set; }


    }
}
