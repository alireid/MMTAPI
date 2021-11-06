using MMTAPI.Helpers;
using MMTAPI.Models.API;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MMTAPI.Services
{

    /// <summary>
    /// Customer based services for API access
    /// </summary>
    public class CustomerService
    {
        public static async Task<CustomerDetails> GetCustomerDetails(string email)
        {
            string apiKey = "1CrsOooSHlV15C7OYnLY0DHjBHyjzoI8LNHITV04cNCyNCahecPDhw==";
            string url = string.Format("https://customer-account-details.azurewebsites.net/api/GetUserDetails?email={0}&code={1}", email, apiKey);

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("You must obtain an API key from MMT");
            }

            dynamic results = await DataService.GetDataFromService(url).ConfigureAwait(false);

            if (results != null)
            {
                return JsonConvert.DeserializeObject<CustomerDetails>(results);
            }
            else
            {
                return null;
            }
        }
    }
}