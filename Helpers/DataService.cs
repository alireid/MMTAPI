using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MMTAPI.Helpers
{
    /// <summary>
    /// Utility service class
    /// </summary>
    public class DataService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            dynamic data = null;
            if (response != null)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }

            return data;
        }
    }
}
