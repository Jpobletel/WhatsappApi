using System.Runtime.Serialization;
using System.Xml;

namespace WhatsappApi;

// https://youtu.be/GzZu3eYDBmM

public class ContractSerialization
{
    public static void SaveData<T>(T serializableObject, string filepath)
    {
        var serializer = new DataContractSerializer(typeof(T));
        var settings = new XmlWriterSettings()
        {
            Indent = true,
            IndentChars = "\t",
        };
        var writer = XmlWriter.Create(filepath, settings);
        if (serializableObject != null) serializer.WriteObject(writer, serializableObject);
        writer.Close();
    }

    public static T LoadData<T>(string filepath)
    {
        var fileStream = new FileStream(filepath, FileMode.Open);
        var reader = XmlDictionaryReader.CreateTextReader(fileStream, new XmlDictionaryReaderQuotas());
        var serializer = new DataContractSerializer(typeof(T));
        T serializeObject = (T)serializer.ReadObject(reader, true);
        reader.Close();
        fileStream.Close();
        return serializeObject;
    }

}