using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Employee
{
    public static class GlobalVariables
    {
        public static HttpClient httpClient = new HttpClient();
        static GlobalVariables()
        {
            httpClient.BaseAddress = new Uri("https://localhost:44386/api");  //eg:http://www.name.com/api
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}