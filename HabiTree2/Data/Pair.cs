using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabiTree2.Data
{
    public class Pair<T, K>
    {
        public Pair(T val1, K val2)
        {
            Val1 = val1;
            Val2 = val2;
        }

        public T Val1 { get; }
        public K Val2 { get; }
    }

}
