using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WhatsappApi;


using (var httpClient = new HttpClient())
{
    httpClient.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", "EAAJraTZANAS4BACIbcfYOimFTp4ZA65GjCWjvTQTemIGGJBFic8He1rgCrF9kXLBpkpblibToelYzQoTOSokdX3DxUeSaP11HZBVGXGTk28rjrCuUg7bSTlZBoLTaMRXkgDZCuz15CpIU5LhSnp7rPPXwPSBwbNW60eMDYbBjCMSqnaGAcvLzgdFq5OuH5tntpBbI2Wy0YwZDZD");
    // Setup the HttpClient and make the call and get the relevant data.
    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



    var payload = new body
    {
        messaging_product = "whatsapp",
        to = "953065288",
        type = "template",
        template = new template
        {
            name = "sample_issue_resolution",
            language = new Dictionary<string, string>
            {
                {"code", "es"}
            },
            components = new List<components>(){
            {
                new components
                {
                    type = "body",
                    parameters = new List<Dictionary<string, string>>()
                    {
                        new()
                        {
                            {"type", "text"},
                            {"text", "Martin te amooooooooo"}
                        }
                    }
                }
            }
            
            }
        },
    };

    var stringPayload = JsonConvert.SerializeObject(payload);
    Console.WriteLine(stringPayload);
    var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
    

    var response = await httpClient.PostAsync("https://graph.facebook.com/v15.0/100455386279755/messages", httpContent);
    Console.WriteLine(response);
}