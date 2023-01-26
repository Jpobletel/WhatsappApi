namespace WhatsappApi;

public class App
{
    private MessageSender _messageSender;
    public App()
    {
        var link = View.GetInputString("Ingresa el link proporcionado por meta para enviar los mensajes");
        var token = View.GetInputString("Ingresa el token personal o el temporal");
        _messageSender = new MessageSender(link, token);
        var sender =_messageSender.SendMessage();
        sender.Wait();
    }
}