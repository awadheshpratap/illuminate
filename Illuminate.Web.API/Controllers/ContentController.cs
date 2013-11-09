using Illuminate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Illuminate.Model.Repository;

namespace Illuminate.Web.API.Controllers
{
    public class ContentController : ApiController
    {
        private readonly ContentRepository _contentRepository = new ContentRepository();

        // GET api/content
        [HttpGet]
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

        // GET api/content/mitrukv
        public IEnumerable<Content> GetContentByUserId(string userId)
        {
            if (userId == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var content = _contentRepository.GetWithRawSql("Select * from Content where Author = '{0}'", userId);

            return content;
        }

        // POST contribute/content/{contentId}
        [HttpPost]
        public HttpResponseMessage PostContent([FromBody] Content content, int? contentId)
        {
            if (!contentId.HasValue)
            {
                // set audit fields 
                content.CreationDateTime = DateTime.Now;
                content.UpdateDateTime = DateTime.Now; 

                //TODO: set these as the updating user, once that is available from client
                content.CreatorRef = "system";
                content.UpdaterRef = "system";

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
