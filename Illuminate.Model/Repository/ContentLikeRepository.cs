using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminate.Model.Repository
{
    public class ContentLikeRepository : GenericRepository<ContentLike>
    {
        public ContentLikeRepository()
            : base(new IlluminateEntities())
        {
        }
    }
}
