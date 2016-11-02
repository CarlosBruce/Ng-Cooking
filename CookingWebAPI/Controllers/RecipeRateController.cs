using Cooking.Entities;
using Cooking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CookingWebAPI.Controllers
{
    [EnableCors( origins: "*", headers: "*", methods: "*" )]
    public class RecipeRateController : ApiController
    {

        private IRecipeRateService RecipeRateService;

        public RecipeRateController( IRecipeRateService _iRecipeRateService )
        {
            this.RecipeRateService = _iRecipeRateService;
        }

        [HttpPost]
        public HttpResponseMessage Post( [FromBody]RecipeRate rt )
        {
            HttpResponseMessage response = new HttpResponseMessage();


                if( this.RecipeRateService.Add( rt ) )
                    response = Request.CreateResponse<RecipeRate>( HttpStatusCode.OK, rt );
                else
                    response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, new Exception("Erreur lors de l'ajout de note") );

            return response;
        }
    }
}
