using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Illuminate.Model
{
    public static class IdGenerator
    {
        private static int _currentId = 0;

        public static int Next()
        {
            Interlocked.Increment(ref _currentId);
            return _currentId;
        }
    }
}