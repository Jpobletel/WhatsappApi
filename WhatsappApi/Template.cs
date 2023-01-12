using System.Runtime.Serialization;

namespace WhatsappApi;

[DataContract]
public class body
{
    [DataMember]
    public string messaging_product { get; set; }
    [DataMember]
    public string? to { get; set; }
    [DataMember]
    public string type { get; set; }
    [DataMember]
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