namespace WhatsappApi;
using System.Net.Http;

public class MessageSender
{
    private static readonly HttpClient client = new HttpClient();

    public void Post()
    {
        string url = "https://graph.facebook.com/v15.0/100455386279755/messages";
    }
}

