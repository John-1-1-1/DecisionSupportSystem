using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
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


        public  string get_requests()
        {

            //var request = WebRequest.Create("http://127.0.0.1:5000/beta_get?" +
            //    "oids=1.3.6.1.4.1.171.12.1.1.6.1.0|1.3.6.1.4.1.171.12.11.1.8.1.2.1&id=1");
            //request.Method = "GET";

            //var webResponse = request.GetResponse();
            //var webStream = webResponse.GetResponseStream();

            //var reader = new StreamReader(webStream);
            //var data = reader.ReadToEnd();
            //return data;
            return "";
        }

    }
}