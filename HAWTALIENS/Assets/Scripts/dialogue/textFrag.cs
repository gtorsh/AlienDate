using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class textFrag
{
    [XmlElement("text")]
    public string text;

    [XmlElement("actor")]
    public string actor;

    [XmlElement("dest")]
    public int dest;
}

