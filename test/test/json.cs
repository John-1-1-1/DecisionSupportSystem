using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class json
    {
        public class JsonPoint
        {
            public int x;
            public int y;
            public string oid;
            public string name;
            public List<int> id;

            public JsonPoint(int x, int y, string oid, string name,
                List<int> id)
            {
                this.x = x;
                this.y = y;
                this.oid = oid;
                this.name = name;
                this.id = id;

            }
        }
    }
}
