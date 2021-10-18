using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_Prueba.Clases
{
    public class RestClient
    {
        public async Task<T> Get<T>(string url_aux = null, string type = "boolean", string amount = "10")
        {
            try
            {
                var _diffculty = "medium";
                switch (((App)Application.Current).Dificultad)
                {
                    case 0:
                        _diffculty = "easy";
                        break;
                    case 2:
                        _diffculty = "hard";
                        break;
                }
                var url = $"{Constants.ApiServiceString}{Constants.param_amount}{amount}{Constants.Param_Difficulty}{_diffculty}{Constants.Param_Type}{type}";
                
                if (!string.IsNullOrEmpty(url_aux))
                    url = url_aux;

                HttpClient http = new HttpClient();
                var response = await http.GetAsync(url);
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
