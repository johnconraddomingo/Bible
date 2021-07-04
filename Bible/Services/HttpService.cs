using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bible.Services
{
    public interface IHttpService 
    {
        Task<T> GetObjectResponse<T>(string requestUrl);
    }

    public class HttpService  : IHttpService
    {  
        public async Task<T> GetObjectResponse<T> (string requestUrl) 
        {
            var httpClient = new HttpClient(); 
            var response = await httpClient.GetAsync(requestUrl) ;
            var contents = await response.Content.ReadAsStringAsync();
             
            var parsed = JsonConvert.DeserializeObject<T>(contents);
            return parsed;
        }
    }
}
