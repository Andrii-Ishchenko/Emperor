using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emperor.Core
{
    public class Utils
    {
        private static Random _random;

        public static Random GetRandomInstance()
        {
            if (_random == null)
                _random = new Random(Guid.NewGuid().GetHashCode());
            return _random;
        }
    }
}
