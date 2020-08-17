using MyService.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T1904EHelloUWP.Entity;

namespace MyService.Service
{
    public class SongService
    {
        public async Task<Song> Create(Song song)
        {
            var songJson = JsonConvert.SerializeObject(song);
            var requestData = new StringContent(songJson, Encoding.UTF8, ApiConfig.MediaType);
            var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.PostAsync(new Uri(ApiConfig.RegisterApi), requestData);
            if (httpResponseMessage.StatusCode != HttpStatusCode.Created)
            {
                return null;
            }
            var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Song>(responseContent);
        }
    }
}
