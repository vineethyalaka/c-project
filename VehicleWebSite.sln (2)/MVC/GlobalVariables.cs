using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Mvc
{
    public static class GlobalVariables
    {
        public static HttpClient VehiclesApiClient = new HttpClient();

        static GlobalVariables()
        {
            VehiclesApiClient.BaseAddress = new Uri("http://localhost:49781/api/");
            VehiclesApiClient.DefaultRequestHeaders.Clear();
            VehiclesApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}