using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App_Prueba.Clases
{
    public class RestClient
    {
        public async Task<T> Get<T>()
        {
            try
            {
                HttpClient http = new HttpClient();
                var response = await http.GetAsync(Constants.ApiServiceString);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonstring);
                }

            }
            catch(Exception ex)
            {
                string error = ex.ToString();
            }
            return default(T);
        }
    }
}
