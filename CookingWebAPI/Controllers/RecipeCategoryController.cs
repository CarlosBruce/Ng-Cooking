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
    public class RecipeCategoryController : ApiController
    {

        private IRecipeCategoryService RecipeCategoryService;

        public RecipeCategoryController( IRecipeCategoryService _iRecipeCategoryService )
        {
            this.RecipeCategoryService = _iRecipeCategoryService;
        }


        [HttpGet]
        public HttpResponseMessage Get( int id )
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                RecipeCategory recipeCategory =this.RecipeCategoryService.Get(id);
                response = Request.CreateResponse<RecipeCategory>( HttpStatusCode.OK, recipeCategory );
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
                List<RecipeCategory> recipeCategorys =this.RecipeCategoryService.Get();
                response = Request.CreateResponse<List<RecipeCategory>>( HttpStatusCode.OK, recipeCategorys );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;

        }

        [HttpPost]
        public HttpResponseMessage Post( [FromBody]RecipeCategory rc )
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if( this.RecipeCategoryService.Add( rc ) )
                    response = Request.CreateResponse<RecipeCategory>( HttpStatusCode.OK, rc );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;
        }
    }
}
