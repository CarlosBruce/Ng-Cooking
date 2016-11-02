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
    public class RecipeController : ApiController
    {

        private IRecipeService RecipeService;

        public RecipeController( IRecipeService _iRecipeService )
        {
            this.RecipeService = _iRecipeService;
        }

        [HttpGet]
        public HttpResponseMessage Get( int id )
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Recipe recipe =this.RecipeService.Get(id);
                response = Request.CreateResponse<Recipe>( HttpStatusCode.OK, recipe );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }

            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                List<Recipe> recipes =this.RecipeService.Get();
                response = Request.CreateResponse<List<Recipe>>( HttpStatusCode.OK, recipes );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;

        }

        [HttpPost]
        public HttpResponseMessage Post( [FromBody]Recipe r )
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if( this.RecipeService.Add( r ) )
                    response = Request.CreateResponse<Recipe>( HttpStatusCode.OK, r );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;
        }
    }
}
