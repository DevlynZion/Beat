using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using UnityEngine;

[Serializable]
public class SongData 
{
    public string SongName;
    public int BMP;
    public List<BarData> Bars;

    public SongData()
    {
        Bars = new List<BarData>();
    }
}
