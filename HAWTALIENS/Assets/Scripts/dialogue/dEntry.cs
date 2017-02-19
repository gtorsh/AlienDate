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

    [XmlElement("textFrag")]
    public List<textFrag> textFrag;

    [XmlElement("dChoice")]
    public List<dChoice> choices;

    [XmlElement("dest")]
    public int dest;
}
