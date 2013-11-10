using Illuminate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Illuminate.Model.Repository;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Threading;

namespace Illuminate.Web.API.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();

        [HttpGet]
        public IEnumerable<Category> GetAllCategory()
        {
            return _categoryRepository.Get();
        }

        public Category GetCategoryById(int categoryId)
        {
            var category = _categoryRepository.GetByID(categoryId);

            if (category == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return category;
        }

    }
}
