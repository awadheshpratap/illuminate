using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illuminate.Model.Repository
{
    public class UserProfileRepository : GenericRepository<UserProfile>
    {
        public UserProfileRepository()
            : base(new IlluminateEntities())
        {
        }
    }
}
