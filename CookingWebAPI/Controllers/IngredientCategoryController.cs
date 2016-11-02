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
    public class IngredientCategoryController : ApiController
    {
        private IIngredientCategoryService ingredientCategoryService;

        public IngredientCategoryController( IIngredientCategoryService _iIngredientCategoryService )
        {
            this.ingredientCategoryService = _iIngredientCategoryService;

        }
        // GET: api/IngredientCategory
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                List<IngredientCategory> icats =this.ingredientCategoryService.Get();
                response = Request.CreateResponse<List<IngredientCategory>>( HttpStatusCode.OK, icats );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }

            return response;
        }

        // GET: api/IngredientCategory/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IngredientCategory icat =this.ingredientCategoryService.Get(id);
                response = Request.CreateResponse<IngredientCategory>( HttpStatusCode.OK, icat );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }

            return response;
        }

        // POST: api/IngredientCategory
        public HttpResponseMessage Post([FromBody]IngredientCategory icat)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                if( this.ingredientCategoryService.Add( icat ) )
                    response = Request.CreateResponse<IngredientCategory>( HttpStatusCode.OK, icat );
            }
            catch( Exception e )
            {
                response = Request.CreateResponse<Exception>( HttpStatusCode.InternalServerError, e );
            }
            return response;
        }

        //// PUT: api/IngredientCategory/5
        //public HttpResponseMessage Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/IngredientCategory/5
        //public HttpResponseMessage Delete(int id)
        //{
        //}
    }
}
