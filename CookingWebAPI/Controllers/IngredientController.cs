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
    public class IngredientController : ApiController
    {
        private IIngredientService ingredientService;

        public IngredientController( IIngredientService _iIngredientService )
        {
            this.ingredientService = _iIngredientService;

        }

        // GET: api/IngredientCategory
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                List<Ingredient> igs =this.ingredientService.Get();
                response = Request.CreateResponse<List<Ingredient>>( HttpStatusCode.OK, igs );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }

            return response;
        }

        // GET: api/IngredientCategory/5
        public HttpResponseMessage Get( int id )
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Ingredient ig =this.ingredientService.Get(id);
                response = Request.CreateResponse<Ingredient>( HttpStatusCode.OK, ig );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }

            return response;
        }

        // POST: api/IngredientCategory
        public HttpResponseMessage Post( [FromBody]Ingredient ig )
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if( this.ingredientService.Add( ig ) )
                    response = Request.CreateResponse<Ingredient>( HttpStatusCode.OK, ig );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;
        }
    }
}
