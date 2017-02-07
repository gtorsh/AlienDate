using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class dContainer
{
    [XmlAttribute("char")]
    public string dChar;

    [XmlElement("dPack")]
    public List<dPack> dPack;
}





