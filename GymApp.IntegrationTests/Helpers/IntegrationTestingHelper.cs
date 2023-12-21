using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.IntegrationTests.Helpers
{
    public static class IntegrationTestingHelper
    {
        public static StringContent PrepareContent(object content)
        {
            return new StringContent(JsonConvert.SerializeObject(content, Formatting.Indented), Encoding.UTF8, "application/json");
        }
        public static async Task<string> Login(HttpClient httpClient)
        {
            var content = PrepareContent( new { email = "adm@adm.pl", password = "Password1!" });
            var response = await httpClient.PostAsync("/api/Authentication/login", content);
            var responseBody = JObject.Parse(await response.Content.ReadAsStringAsync());
            return responseBody.GetValue("data").ToString();
        }
    }
}
