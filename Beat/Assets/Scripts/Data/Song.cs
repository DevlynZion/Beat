using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
public class Song
{
    public string SongName;
    public List<Bar> Bars;

    public Song()
    {
        Bars = new List<Bar>();
    }   
}
