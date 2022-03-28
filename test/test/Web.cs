using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Web
    {

        public static void post_requests(NameValueCollection values, string url)
        {
            using (var client = new WebClient())
            {
                var response = client.UploadValues(url, values);
                var responseString = Encoding.Default.GetString(response);
            }
        }
    
    
    }
}