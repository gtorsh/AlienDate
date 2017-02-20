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

public class dContainer
{
    [XmlAttribute("char")]
    public string dChar;

    [XmlElement("dPack")]
    public List<dPack> dPack;
}

public class dPack
{
    [XmlAttribute("ID")]
    public int dID;

    [XmlElement("dEntry")]
    public List<dEntry> entry;
}

public class dEntry
{
    [XmlAttribute("ID")]
    public int dID;

    [XmlElement("textFrag")]
    public List<textFrag> textFrag;

    [XmlElement("dChoice")]
    public List<dChoice> choices;

    [XmlElement("dest")]
    public int dest;
}

public class textFrag
{
    [XmlElement("text")]
    public string text;

    [XmlElement("actor")]
    public string actor;

    [XmlElement("dest")]
    public int dest;
}

public class dChoice
{
    [XmlElement("text")]
    public string text;

    [XmlElement("dest")]
    public int dest;
}


