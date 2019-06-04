using System.IO;
using System.Text;
using System.Xml.Serialization;

/// <summary>
/// ''' XMLの読み書き
/// ''' </summary>
/// ''' <typeparam name="T"></typeparam>
public class XmlController<T>
{
    public static bool TryDeserialize(string fname, out T result)
    {
        if (string.IsNullOrEmpty(fname) || !File.Exists(fname))
        {
            result = default(T);
            return false;
        }

        XmlSerializer deserializer = new XmlSerializer(typeof(T));

        using (StreamReader sr = new StreamReader(fname, new UTF8Encoding(false)))
        {
            result = (T)deserializer.Deserialize(sr);
        }

        return true;
    }

    public static bool TrySerialize(string fname, T data)
    {
        if (string.IsNullOrEmpty(fname))
            return false;

        XmlSerializer serializer = new XmlSerializer(typeof(T));

        using (StreamWriter sw = new StreamWriter(fname, false, new UTF8Encoding(false)))
        {
            serializer.Serialize(sw, data);
        }

        return true;
    }
}
