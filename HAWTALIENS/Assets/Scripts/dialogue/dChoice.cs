﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class dChoice
{
    [XmlElement("text")]
    public string text;

    [XmlElement("dest")]
    public int dest;
}
