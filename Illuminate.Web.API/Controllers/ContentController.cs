using Illuminate.Web.API.MockDataGenerator;
using Illuminate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Illuminate.Model.Repository;
using System.Web.Mvc;

namespace Illuminate.Web.API.Controllers
{
    public class ContentController : ApiController
    {
        private readonly ContentRepository _contentRepository = new ContentRepository();

        // GET api/content
        public IEnumerable<Content> GetAllContents()
        {
            return _contentRepository.Get();
        }

        // GET api/content/5
        public Content GetContentById(int contentId)
        {
            var content = _contentRepository.GetByID(contentId);

            if (content == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return content;
        }

        // POST contribute/content/{contentId}
        public HttpResponseMessage PostContent([FromBody] Content content, int? contentId)
        {
            System.Diagnostics.Debugger.Break();
            if (contentId.HasValue == false)
            {
                _contentRepository.Insert(content);
            }
            else
            {
                _contentRepository.Update(content);
            }


            var response = Request.CreateResponse<Content>(HttpStatusCode.Created, content);
            string uri = Url.Link("ConsumeContent", new { contentId = content.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
    }
}
