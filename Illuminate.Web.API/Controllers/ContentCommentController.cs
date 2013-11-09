using Illuminate.Model;
using Illuminate.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Illuminate.Web.API.Controllers
{
    public class ContentCommentController : ApiController
    {
        private ContentCommentRepository _contentCommentsRepository;

        // GET api/contentcomment/{contentid}
        public IEnumerable<ContentComment> GetAllComments(int contentId)
        {
            return _contentCommentsRepository.
                GetWithRawSql("select * from contentcomment where contentid={0}", contentId);
        }

        // POST api/contentcomment
        public void Post([FromBody]ContentComment value)
        {
        }

        // DELETE api/contentcomment/5
        public void Delete(int id)
        {
        }
    }
}
