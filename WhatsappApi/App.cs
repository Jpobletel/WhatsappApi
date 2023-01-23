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
        // Options();
    }

    public void Options()
    {

        var templates = TemplateLoader.read();
        var index = 0;
        Console.WriteLine("Elija la plantilla que desea utilizar");
        foreach (var template in templates)
        {
            Console.WriteLine($"[{index}]: {template.template.name}");
            index++;
        }
        var templateOption = View.GetIntInput(templates.Count);
        var targetNumber = View.GetInputString("Indique el numero al que quiere enviar el mensaje");
        templates[templateOption].to = targetNumber;
        var sender = _messageSender.SendMessage();
        sender.Wait();
    }
    
    
}