using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationServiceMAUI.Services
{
    internal class API
    {
        public string GetAPI(string endpoint, string filtro)
        {
            var key = $"?api_key=0ab48f9b431269fc62d293475eee0a68";
           
            var json = string.Empty;
            var builder = new UriBuilder($"https://api.themoviedb.org/3/{endpoint}");
            builder.Query = key + filtro ;

            HttpClient cliente = new HttpClient();
            var result = cliente.GetAsync(builder.Uri).Result;

            using (StreamReader st = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            {
                json = st.ReadToEnd();
            }

            return json;
        }
    }
}
