using System.Net.Http.Headers;
using System.Text;

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
    
    public async Task<string> SendMessage()
    {
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", _token);
        // var stringPayload = JsonConvert.SerializeObject(payload);
        // Console.WriteLine(stringPayload);
        var stringPayload = File.ReadAllText(@"template.json");
        
        var PhoneNumber = View.GetInputString("Indique el numero al que quiere enviar el mensaje");
        stringPayload = stringPayload.Replace("PHONENUMBER", PhoneNumber);
        int numVariable = 0;
        while (stringPayload.Contains("VARIABLE"+ numVariable))
        {
            var variable = View.GetInputString("Indique el valor de la variable " + numVariable);
            stringPayload = stringPayload.Replace("VARIABLE" + numVariable, variable);
            numVariable++;
        }
        Console.WriteLine(stringPayload);
        var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(_link, httpContent);
        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseString);
        return responseString;
    }
}

