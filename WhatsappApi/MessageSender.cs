using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WhatsappApi;
using System.Net.Http;

public class MessageSender
{

    private string _link { get; set; }
    private string _token { get; set; }
    public MessageSender(string link, string token)
    {
        _link = link;
        _token = token;
    }
    
    
    public async Task<string> SendMessage(body payload)
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", _token);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        var stringPayload = JsonConvert.SerializeObject(payload);
        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(_link, httpContent);
        string responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
        return responseString;
    }
}

