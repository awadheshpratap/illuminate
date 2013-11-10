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

        [HttpPost]
        public async Task<HttpResponseMessage> PostContent()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string uniqueId = Guid.NewGuid().ToString();
            string root = HttpContext.Current.Server.MapPath("~/App_Data/" + uniqueId);

            Directory.CreateDirectory(root);
            var provider = new MultipartFormDataStreamProvider(root);
            var result = await Request.Content.ReadAsMultipartAsync(provider);
            if (result.FormData["model"] == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

           

            if (provider.FileData.Count > 1)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            string destinationFileUrl = null;
            //get the files
            foreach (var file in result.FileData)
            {
                FileInfo fileInfo = new FileInfo(file.LocalFileName);
                string destinationLocalFile = file.Headers.ContentDisposition.FileName.Replace("\"", "");
                destinationLocalFile = Path.GetFileName(destinationLocalFile);
                destinationFileUrl = "/App_Data/" + uniqueId + "/" + destinationLocalFile;
                File.Move(file.LocalFileName, Path.Combine(fileInfo.Directory.ToString(), destinationLocalFile));
            }

            if (String.IsNullOrEmpty(destinationFileUrl))
            {
                Directory.Delete(root, true);
            }

            //Do something with the json model which is currently a string
            var model = result.FormData["model"];

            Content content = JsonConvert.DeserializeObject<Content>(model);
            content.Uri = destinationFileUrl;
            content.CreationDateTime = DateTime.UtcNow;
            content.UpdateDateTime = DateTime.UtcNow;
            content.CreatorRef = Thread.CurrentPrincipal.Identity.Name;
            content.UpdaterRef = Thread.CurrentPrincipal.Identity.Name;
            _contentRepository.Insert(content);
            return Request.CreateResponse(HttpStatusCode.OK, "success!");
        }
    }
}
