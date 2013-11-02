using Illuminate.Web.API.MockDataGenerator;
using Illuminate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Illuminate.Web.API.Controllers
{
    public class ContentController : ApiController
    {
        private static Dictionary<int, Content> _contentCache = ContentGenerator.GenerateContent();

        // GET api/content
        public IEnumerable<Content> Get()
        {
            return _contentCache.Values;
        }

        // GET api/content/5
        public Content Get(int id)
        {
            if (_contentCache.ContainsKey(id))
            {
                return _contentCache[id];
            }
            else
            {
                return null;
            }
        }

        // POST api/content
        public void Post([FromBody] Content content)
        {
            if (content.Id <= 0)
            {
                content.Id = IdGenerator.Next();
            }
            _contentCache[content.Id] = content;
        }

        // PUT api/content/5
        public void Put(int id, [FromBody]Content content)
        {
            _contentCache[id] = content;
        }

        // DELETE api/content/5
        public void Delete(int id)
        {
            _contentCache.Remove(id);
        }
    }
}
