using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CookingWebAPI.Providers
{
    public class WebApiOutputCacheAttribute : ActionFilterAttribute
    {
        // cache length in seconds
        private int _timespan;
        // client cache length in seconds
        private int _clientTimeSpan;
        // cache for anonymous users only?
        private bool _anonymousOnly;
        // cache key
        private string _cachekey;
        // cache repository
        private static readonly ObjectCache WebApiCache = MemoryCache.Default;

        private const string JSON_DEF = "response-ct";

        private const string ENTITIES_NAMESPACE = "Cooking.Entities";


        private const double DEFAULT_TIMESPAN = 10;

        public WebApiOutputCacheAttribute(int timespan, int clientTimeSpan, bool anonymousOnly)
        {
            _timespan = timespan;
            _clientTimeSpan = clientTimeSpan;
            _anonymousOnly = anonymousOnly;
        }

        private bool _isCacheable(HttpActionContext ac)
        {
            if (_timespan > 0 && _clientTimeSpan > 0)
            {
                if (_anonymousOnly)
                    if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
                        return false;
                if (ac.Request.Method == HttpMethod.Get) return true;
            }
            //else
            //{
            //   // if (ac.Request.Method == HttpMethod.Post) return false;
            //  //  throw new InvalidOperationException("Wrong Arguments");
            //}
            return false;
        }

        private CacheControlHeaderValue setClientCache()
        {
            var cachecontrol = new CacheControlHeaderValue();
            cachecontrol.MaxAge = TimeSpan.FromSeconds(_clientTimeSpan);
            cachecontrol.MustRevalidate = true;
            return cachecontrol;
        }

        public override void OnActionExecuting(HttpActionContext ac)
        {


            if (ac != null)
            {
                string[] urlElemes = ac.Request.RequestUri.AbsolutePath.Split('/');
                string mymodel = urlElemes[2];
                string typeName = String.Format("{0}.{1}, {0}", ENTITIES_NAMESPACE, mymodel);



                if (_isCacheable(ac))
                {
                    _cachekey = string.Join(":", new string[] { ac.Request.RequestUri.AbsolutePath, ac.Request.Headers.Accept.FirstOrDefault().ToString() });
                    if (WebApiCache.Contains(_cachekey))
                    {
                        var val = (string)WebApiCache.Get(_cachekey);
                        if (val != null)
                        {
                            CreateResponseFromCache(ac, val);
                            return;
                        }
                    }
                }
                else
                {
                    List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();

                    foreach (string cacheKey in cacheKeys)
                    {
                        if (cacheKey.Contains(mymodel) && !cacheKey.Contains(JSON_DEF))
                        {
                            if (HttpMethod.Post == ac.Request.Method)
                                AddNewElementOnCache(WebApiCache[cacheKey].ToString(), typeName, ac.ActionArguments,  cacheKey);
                            if (HttpMethod.Get == ac.Request.Method && urlElemes.Count() == 4)
                            {
                                SendSingleElementFromCache(ac, mymodel ,WebApiCache[cacheKey].ToString(),typeName, urlElemes[3]);
                                return;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("actionContext");
            }
        }

        private void SendSingleElementFromCache(HttpActionContext ac,string mymodel, string elements, string typeName, string id)
        {
           
            System.Collections.IList list = GenerateListFromCache(Type.GetType(typeName));
            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(elements);
            string key = String.Format( "\"Id{0}\": {1}", mymodel, id);
            foreach (object o in list)
            {
               if(o.ToString().Contains(key))
                {
                    ac.Response = ac.Request.CreateResponse();
                    ac.Response.Content = new StringContent(o.ToString());
                    ac.Response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }
            }
        }

        private void CreateResponseFromCache(HttpActionContext ac, string val)
        {
            ac.Response = ac.Request.CreateResponse();
            ac.Response.Content = new StringContent(val);
            var contenttype = (MediaTypeHeaderValue)WebApiCache.Get(_cachekey + ":response-ct");
            if (contenttype == null)
                contenttype = new MediaTypeHeaderValue(_cachekey.Split(':')[1]);
            ac.Response.Content.Headers.ContentType = contenttype;
            ac.Response.Headers.CacheControl = setClientCache();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (_cachekey != null && !(WebApiCache.Contains(_cachekey)))
            {
                var t = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cooking.Entities.Recipe>>(actionExecutedContext.Response.Content.ReadAsStringAsync().Result);
                var body = actionExecutedContext.Response.Content.ReadAsStringAsync().Result;
                WebApiCache.Add(_cachekey, body, DateTime.Now.AddSeconds(_timespan));
                WebApiCache.Add(_cachekey + ":response-ct", actionExecutedContext.Response.Content.Headers.ContentType, DateTime.Now.AddSeconds(_timespan));
            }
            if (_isCacheable(actionExecutedContext.ActionContext))
                actionExecutedContext.ActionContext.Response.Headers.CacheControl = setClientCache();
        }


        private void AddNewElementOnCache(string elements,string typeName, Dictionary<string,object> elementAdded, string cacheKey)
        {

            System.Collections.IList list = GenerateListFromCache(Type.GetType(typeName));

            list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(elements);

            foreach (KeyValuePair<string, object> cur in elementAdded)
            {
                if (Type.GetType(typeName) == cur.Value.GetType())
                    list.Add(cur.Value);
            }
            WebApiCache.Remove(cacheKey);
            string body = Newtonsoft.Json.JsonConvert.SerializeObject(elements);
            WebApiCache.Add(cacheKey, body, DateTime.Now.AddSeconds(DEFAULT_TIMESPAN));
        }


        private static System.Collections.IList GenerateListFromCache(Type t)
        {
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(t);
            var instance = Activator.CreateInstance(constructedListType);
            return (System.Collections.IList)instance;
        }

    }
}