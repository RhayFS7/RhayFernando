using RhayFernando.Models;
using Service.Registers;
using Service.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RhayFernando.Controllers.API
{
    public class CategoriesController : ApiController
    {
        private CategoryServices service = new CategoryServices();
        private ProductServices productServices = new ProductServices();

        // GET: api/Categories
        public CategoryListAPIModel Get()
        {
            var apiModel = new CategoryListAPIModel();

            try
            {
                apiModel.Result = service.GetByName();
            }
            catch (System.Exception)
            {
                apiModel.Message = "!OK";
            }
            return apiModel;
      
    }
        // GET: api/Categories/5
        public Category Get(int id)
        {
            return service.GetCategoryById(id);
        }

        // POST: api/Categories
        public void Post([FromBody]Category value)
        {
        }

        // PUT: api/Categories/5
        public void Put(int id, [FromBody]Category value)
        {
        }

        // DELETE: api/Categories/5
        public void Delete(int id)
        {
        }
    }
}
