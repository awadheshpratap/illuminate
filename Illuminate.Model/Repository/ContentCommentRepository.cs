using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminate.Model.Repository
{
    public class ContentCommentRepository : GenericRepository<ContentComment>
    {
        public ContentCommentRepository()
            : base(new IlluminateEntities())
        {
        }
    }
}
