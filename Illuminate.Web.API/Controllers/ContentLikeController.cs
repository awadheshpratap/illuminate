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
    public class ContentLikeController : ApiController
    {
        private ContentLikeRepository _contentLikesRepository = new ContentLikeRepository();

        public IEnumerable<ContentLike> GetAllLikes()
        {
            return _contentLikesRepository.Get();
        }

        // GET api/contentlike/{contentid}
        public IEnumerable<ContentLike> GetAllLikes(int contentId)
        {
            return _contentLikesRepository.
                GetWithRawSql("select * from contentlike where contentid={0}", contentId);
        }

        // POST api/contentlike/{contenttid}
        public void Post([FromBody]ContentLike like)
        {
            if (like.Id > 0)
            {
                _contentLikesRepository.Insert(like);
            }
            else
            {
                _contentLikesRepository.Update(like);
            }
        }

        // DELETE api/contentlike/5
        public void Delete(int id)
        {
        }
    }
}
