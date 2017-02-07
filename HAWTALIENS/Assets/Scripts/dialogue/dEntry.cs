using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class dEntry
{
    [XmlAttribute("ID")]
    public int dID;

    [XmlElement("actor")]
    public string actor;

    [XmlElement("text")]
    public string dText;

    [XmlElement("dChoice")]
    public List<dChoice> choices;
}
