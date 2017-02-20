using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[XmlRoot("Save")]
public class progControl
{
    [XmlElement("character")]
    public List<progChar> character;

    public static progControl Load(string path)
    {
        var serializer = new XmlSerializer(typeof(progControl));
        using (var stream = new FileStream(path, FileMode.Open))
        {
            return serializer.Deserialize(stream) as progControl;
        }
    }
    public void Save()
    {
        if (!Directory.Exists(Application.dataPath + "/Saves")){
            Directory.CreateDirectory(Application.dataPath + "/Saves");
        }
        if (!File.Exists(Application.dataPath + "/Saves/saveFile.xml"))
        {
            File.Create(Application.dataPath + "/Saves/saveFile.xml");
        }
        var serializer = new XmlSerializer(typeof(progControl));
        using (var stream = new FileStream(Application.dataPath + "/Saves/saveFile.xml", FileMode.OpenOrCreate))
        {
            serializer.Serialize(stream, this);
        }
    }
}

public class progChar
{
    [XmlElement("arc")]
    public int arc;

    [XmlElement("conversation")]
    public int conversation;
}
