using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Utilities
{
    public class HTTPWebClient
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> Post(string url, List<QueryParm> queryParms, Dictionary<string, string> body, Dictionary<string, string> headers)
        {
            var fullUrl = url;

            if (queryParms != null && queryParms.Count > 0)
            {
                fullUrl += "?";

                int i = 0;
                foreach (var query in queryParms)
                {
                    string and = i > 0 ? "&" : "";

                    if (query.UseEquals == true)
                    {
                        fullUrl += and + query.Key + "=" + query.Value;
                    }
                    else
                    {
                        fullUrl += and + query.Key + query.Value;
                    }

                    i++;
                }
            }

            if (body == null)
            {
                body = new Dictionary<string, string>();
            }

            if (headers == null)
            {
                headers = new Dictionary<string, string>();
            }

            var content = new FormUrlEncodedContent(body);
            
            foreach (var s in headers)
            {
                content.Headers.Add(s.Key, s.Value);
            }

            var response = await client.PostAsync(fullUrl, content);

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async void Get()
        {
            var responseString = await client.GetStringAsync("http://www.example.com/recepticle.aspx");
        }

        public class QueryParm
        {
            public string Key { get; set; }
            public string Value { get; set; }
            public bool UseEquals { get; set; } = true;
        }
    }
}
