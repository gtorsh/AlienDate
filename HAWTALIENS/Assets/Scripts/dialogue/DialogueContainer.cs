using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("DIALOGUE")]
public class DialogueContainer
{
    [XmlElement("dContainer")]
    public List<dContainer> dContainers;

    public static DialogueContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(DialogueContainer));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as DialogueContainer;
        }
    }
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(DialogueContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}