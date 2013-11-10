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
        private ContentCommentRepository _contentCommentsRepository = new ContentCommentRepository();

        public IEnumerable<ContentComment> GetAllComments()
        {
            return _contentCommentsRepository.Get();
        }
        
        // GET api/contentcomment/{contentid}
        public IEnumerable<ContentComment> GetAllCommentsByContentId(int contentId)
        {
            return _contentCommentsRepository.
                GetWithRawSql("select * from contentcomment where contentid={0}", contentId);
        }

        // POST api/contentcomment/{contentid}
        public void Post([FromBody]ContentComment comment)
        {
            if (comment.Id < 0)
            {
                _contentCommentsRepository.Insert(comment);
            }
            else
            {
                _contentCommentsRepository.Update(comment);
            }
        }

        // DELETE api/contentcomment/5
        public void Delete(int id)
        {
        }
    }
}
