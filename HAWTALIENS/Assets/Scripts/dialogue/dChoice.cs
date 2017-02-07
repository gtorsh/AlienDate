using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class dChoice
{
    [XmlElement("Text")]
    public string dText;

    [XmlElement("destNode")]
    public int destNodeID;
}
