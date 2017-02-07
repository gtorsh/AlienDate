using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class dPack
{
    [XmlAttribute("ID")]
    public int dID;

    [XmlElement("dEntry")]
    public List<dEntry> entry;
}
