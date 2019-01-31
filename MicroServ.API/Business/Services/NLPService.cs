using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MicroServ.API.Business.ServiceContracts;
using MicroServ.API.Models;
using Newtonsoft.Json;

namespace MicroServ.API.Services
{
    public class NLPService : INLPService
    {
        public static HttpClient client = new HttpClient();

        public NLPService()
        {
        }

        public async Task<string> GetDepartment(string input)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            var luisAppId = "a6563fac-e91f-4212-9723-22c292a2a610";
            var endpointKey = "3d445d348918465d96fb2e51321e0d92";
            var spellEndpointKey = "2044f96755c546838a5747ffbd9213fe";


            // These optional request parameters are set to their default values
            queryString["staging"] = "true";
            queryString["spellCheck"] = "true";
            queryString["bing-spell-check-subscription-key"] = spellEndpointKey;
            queryString["timezoneOffset"] = "60";
            queryString["verbose"] = "true";
            queryString["subscription-key"] = endpointKey;
            queryString["q"] = input;

            // Call LUIS
            string baseUrl = "https://westeurope.api.cognitive.microsoft.com/luis/v2.0/apps/" + luisAppId + "?" + queryString;
            var result = await client.GetAsync(baseUrl);
            var strResponseContent = await result.Content.ReadAsStringAsync();

            LUISResponse resp = JsonConvert.DeserializeObject<LUISResponse>(strResponseContent);
            if(resp == null || resp.entities == null)
                return "404";

            var department = await GetEntityType(resp.entities);
            return department;
        }

        public async Task<string> GetEntityType(ICollection<Entity> entities)
        {
            // string department = string.Empty;
            var department = entities.FirstOrDefault(e => e.type.Contains("Department"));
            if(department == null)
                return "404";

            var typeDep = department.type;
            var dep = typeDep.Split("::")[1];
            return dep;
        }


    }
}