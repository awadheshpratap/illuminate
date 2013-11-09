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
        private ContentLikeRepository _contentLikesRepository;

        // GET api/contentlike/{contentid}
        public IEnumerable<ContentLike> GetAllLikes(int contentId)
        {
            return _contentLikesRepository.
                GetWithRawSql("select * from contentlike where contentid={0}", contentId);
        }

        // POST api/contentlike
        public void Post([FromBody]ContentLike value)
        {
        }

        // DELETE api/contentlike/5
        public void Delete(int id)
        {
        }
    }
}
