using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminate.Model.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository()
            : base(new IlluminateEntities())
        {
        }
    }
   
}
