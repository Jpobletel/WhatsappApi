namespace WhatsappApi;

public class body
{
    public string messaging_product { get; set; }
    public string to { get; set; }
    public string type { get; set; }
    public template template { get; set; }
}

public class template
{
    public string name { get; set; }
    public Dictionary<string, string> language { get; set; }
    public List<components> components { get; set; }
}

public class components
{
    public string type { get; set; }
    public List<Dictionary<string, string>> parameters { get; set; }
}